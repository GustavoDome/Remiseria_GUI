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
    public class ImporteCiudadRepositorio : IImporteCiudadRepositorio
    {
        public ImporteCiudadDTO ObtenerImportes()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCiudad.Find(1); // Asumiendo que solo hay una fila
                if (entidad == null) return null;

                return new ImporteCiudadDTO
                {
                    Kilometro = entidad.Kilometro,
                    Espera = entidad.Espera
                };
            }
        }
        public void ModificarImportes(ImporteCiudadDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCiudad.Find(1); // Único registro
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
