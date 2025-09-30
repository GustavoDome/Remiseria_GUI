using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    public class MovilRepositorio : IMovilRepositorio
    {
        private readonly Conexion.RemiseriaDbContext BD = new Conexion.RemiseriaDbContext();

        public void Agregar(Movil nuevoMovil)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                nuevoMovil.Activo = true; // Aseguramos que se registre como activo
                contexto.Moviles.Add(nuevoMovil);
                contexto.SaveChanges();
            }
        }

        public void Editar(Movil movilEditado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var movilExistente = contexto.Moviles.Find(movilEditado.IdMovil);
                if (movilExistente != null)
                {
                    movilExistente.NumeroMovil = movilEditado.NumeroMovil;
                    movilExistente.MarcaAuto = movilEditado.MarcaAuto;
                    movilExistente.ModeloAuto = movilEditado.ModeloAuto;
                    movilExistente.AnoAuto = movilEditado.AnoAuto;
                    movilExistente.ColorAuto = movilEditado.ColorAuto;
                    movilExistente.IdDueno = movilEditado.IdDueno;
                    movilExistente.Activo = movilEditado.Activo;

                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var movil = contexto.Moviles.Find(id);
                if (movil != null)
                {
                    movil.Activo = false;
                    contexto.SaveChanges();
                } 
                else if (movil == null) 
                {
                    return;
                }
            }
        }

        public IEnumerable<MovilResumenDTO> ObtenerMovilesReducidos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Moviles
                    .Where(m => m.Activo)
                    .Select(m => new MovilResumenDTO
                    {
                        IdMovil = m.IdMovil,
                        NumeroMovil = m.NumeroMovil
                    })
                    .ToList();
            }
        }
        public IEnumerable<Movil> ObtenerTodosDesdeBD()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Moviles.Include(m => m.Dueno).ToList();
            }
        }
        public IEnumerable<MovilDetalleDTO> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Moviles
                    .Include(m => m.Dueno) // Asegura que se cargue la relación
                    .Where(m => m.Activo)
                    .Select(m => new MovilDetalleDTO
                    {
                        IdMovil = m.IdMovil,
                        NumeroMovil = m.NumeroMovil,
                        Marca = m.MarcaAuto,
                        Modelo = m.ModeloAuto,
                        Ano = m.AnoAuto,
                        Color = m.ColorAuto,
                        IdDueno = m.Dueno.IdDueno,
                        NombreDueno = m.Dueno.Nombre,
                        ApellidoDueno = m.Dueno.Apellido,
                        TelefonoDueno = m.Dueno.Telefono,
                        EsChofer = m.Dueno.Chofer
                    })
                    .ToList();
            }
        }
    }
}
