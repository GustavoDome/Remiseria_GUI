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
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Movil.
    /// Implementa la interfaz <see cref="IMovilRepositorio"/>.
    /// </summary>
    public class MovilRepositorio : IMovilRepositorio
    {
        private readonly Conexion.RemiseriaDbContext BD = new Conexion.RemiseriaDbContext();

        /// <summary>
        /// Agrega un nuevo móvil a la base de datos y lo marca como activo.
        /// </summary>
        /// <param name="nuevoMovil">Instancia de <see cref="Movil"/> que representa el nuevo móvil a registrar.</param>
        public void Agregar(Movil nuevoMovil)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                nuevoMovil.Activo = true; // Aseguramos que se registre como activo
                contexto.Moviles.Add(nuevoMovil);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de un móvil existente, incluyendo los datos del dueño asociado.
        /// </summary>
        /// <param name="movilEditado">Instancia de <see cref="Movil"/> con los nuevos datos a actualizar.</param>
        public void Editar(Movil movilEditado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var movilExistente = contexto.Moviles
                    .Include(m => m.Dueno)
                    .FirstOrDefault(m => m.IdMovil == movilEditado.IdMovil);

                if (movilExistente != null)
                {
                    // Actualizar datos del móvil
                    movilExistente.NumeroMovil = movilEditado.NumeroMovil;
                    movilExistente.MarcaAuto = movilEditado.MarcaAuto;
                    movilExistente.ModeloAuto = movilEditado.ModeloAuto;
                    movilExistente.AnoAuto = movilEditado.AnoAuto;
                    movilExistente.ColorAuto = movilEditado.ColorAuto;
                    movilExistente.Activo = movilEditado.Activo;

                    // Actualizar datos del dueño
                    if (movilExistente.Dueno != null)
                    {
                        movilExistente.Dueno.Nombre = movilEditado.Dueno.Nombre;
                        movilExistente.Dueno.Apellido = movilEditado.Dueno.Apellido;
                        movilExistente.Dueno.Telefono = movilEditado.Dueno.Telefono;
                        movilExistente.Dueno.Chofer = movilEditado.Dueno.Chofer;
                    }

                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Realiza un borrado lógico del móvil, marcándolo como inactivo.
        /// </summary>
        /// <param name="id">Identificador del móvil a eliminar.</param>
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

        /// <summary>
        /// Obtiene una lista reducida de móviles activos, con solo identificador y número.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="MovilResumenDTO"/> con los datos básicos de cada móvil.
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

        /// <summary>
        /// Obtiene todos los móviles desde la base de datos incluyendo la relación con el dueño.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="Movil"/> con sus datos completos y dueño asociado.
        /// </returns>
        public IEnumerable<Movil> ObtenerTodosDesdeBD()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Moviles.Include(m => m.Dueno).ToList();
            }
        }

        /// <summary>
        /// Obtiene todos los móviles activos en formato detallado, incluyendo datos del dueño.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="MovilDetalleDTO"/> con los datos completos de cada móvil y su dueño.
        /// </returns>
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
