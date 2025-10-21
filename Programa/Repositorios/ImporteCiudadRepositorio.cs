using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    /// <summary>
    /// Repositorio encargado de gestionar la obtención y modificación de importes por kilómetro y espera.
    /// Implementa la interfaz <see cref="IImporteCiudadRepositorio"/>.
    /// </summary>
    public class ImporteCiudadRepositorio : IImporteCiudadRepositorio
    {
        /// <summary>
        /// Obtiene los valores actuales de importe por kilómetro y por espera desde la base de datos.
        /// </summary>
        /// <returns>
        /// Objeto <see cref="ImporteCiudadDTO"/> con los valores de Kilometro y Espera, o null si no existe el registro.
        /// </returns>
        public ImporteCiudadDTO ObtenerImportes()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCiudad.Find(1);
                if (entidad == null) return null;

                return new ImporteCiudadDTO
                {
                    Kilometro = entidad.Kilometro,
                    Espera = entidad.Espera
                };
            }
        }

        /// <summary>
        /// Modifica los valores de importe por kilómetro y espera en el único registro disponible.
        /// </summary>
        /// <param name="dto">Objeto <see cref="ImporteCiudadDTO"/> con los nuevos valores a actualizar.</param>
        public void ModificarImportes(ImporteCiudadDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCiudad.Find(1);
                if (entidad != null)
                {
                    entidad.Kilometro = dto.Kilometro;
                    entidad.Espera = dto.Espera;

                    contexto.SaveChanges();
                }
            }
        }
    }
}
