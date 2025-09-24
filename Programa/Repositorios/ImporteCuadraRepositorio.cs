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
    public class ImporteCuadraRepositorio : IImporteCuadrasRepositorio
    {
        public CuadrasImporteDTO ObtenerImportes()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.FirstOrDefault();
                if (entidad == null) return null;

                return new CuadrasImporteDTO
                {
                    Cuadras = entidad.Cuadras,
                    Minimo = entidad.Minimo,
                    Espera = entidad.Espera,
                    Mandado = entidad.Mandado
                };
            }
        }

        public void ModificarImportesCuadras(CuadrasImporteDTO dto)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.Find(1); // Asumiendo que siempre modificás la fila con ID 1
                if (entidad != null)
                {
                    entidad.Cuadras = dto.Cuadras;
                    entidad.Mandado = dto.Mandado;
                    entidad.Espera = dto.Espera;
                    entidad.Minimo = dto.Minimo;

                    contexto.SaveChanges();
                }
            }
        }
    }
}
