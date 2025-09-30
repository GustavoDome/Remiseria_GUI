using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    public class CiudadRepositorio : ICiudadRepositorio
    {
        public IEnumerable<CiudadDTO> ObtenerTodas()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var precioKm = contexto.ImportesCiudad.Find(1)?.Kilometro ?? 0;

                return contexto.Ciudades
                    .Select(c => new CiudadDTO
                    {
                        IdCiudad = c.IdCiudad,
                        NombreCiudad = c.NombreCiudad,
                        Kilometros = c.Importe, // este campo representa los KM
                        Importe = c.Importe * precioKm
                    })
                    .ToList();
            }
        }

        public void Agregar(CiudadDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = new Ciudad
                {
                    NombreCiudad = dto.NombreCiudad,
                    Importe = dto.Kilometros
                };

                contexto.Ciudades.Add(entidad);
                contexto.SaveChanges();
            }
        }

        public void Editar(CiudadDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var ciudad = contexto.Ciudades.Find(dto.IdCiudad);
                if (ciudad != null)
                {
                    ciudad.NombreCiudad = dto.NombreCiudad;
                    ciudad.Importe = dto.Kilometros;

                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var ciudad = contexto.Ciudades.Find(id);
                if (ciudad != null)
                {
                    contexto.Ciudades.Remove(ciudad);
                    contexto.SaveChanges();
                }
            }
        }
    }
}
