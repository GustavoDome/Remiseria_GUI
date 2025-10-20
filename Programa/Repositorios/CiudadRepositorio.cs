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
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD sobre la entidad Ciudad.
    /// Implementa la interfaz ICiudadRepositorio.
    /// </summary>
    public class CiudadRepositorio : ICiudadRepositorio
    {
        /// <summary>
        /// Obtiene todas las ciudades registradas en la base de datos y calcula el importe total por kilómetro.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="CiudadDTO"/> que contienen el nombre, kilómetros y el importe calculado.
        /// </returns>
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

        /// <summary>
        /// Agrega una nueva ciudad a la base de datos utilizando los datos del DTO.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CiudadDTO"/> con los datos de la ciudad a agregar.</param>
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

        /// <summary>
        /// Edita los datos de una ciudad existente en la base de datos.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CiudadDTO"/> con los nuevos datos de la ciudad.</param>
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


        /// <summary>
        /// Elimina físicamente una ciudad de la base de datos según su identificador.
        /// </summary>
        /// <param name="id">Identificador de la ciudad a eliminar.</param>
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
