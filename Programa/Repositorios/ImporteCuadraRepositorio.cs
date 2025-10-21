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
    /// Repositorio encargado de gestionar los valores de importes por cuadras, espera, mandado y mínimo.
    /// Implementa la interfaz <see cref="IImporteCuadrasRepositorio"/>.
    /// </summary>
    public class ImporteCuadraRepositorio : IImporteCuadrasRepositorio
    {
        /// <summary>
        /// Obtiene los valores actuales de importes por cuadras, mínimo, espera y mandado desde la base de datos.
        /// </summary>
        /// <returns>
        /// Objeto <see cref="CuadrasImporteDTO"/> con los valores configurados, o null si no existe el registro.
        /// </returns>
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

        /// <summary>
        /// Modifica el valor mínimo configurado en el único registro de importes por cuadras.
        /// </summary>
        /// <param name="nuevoMinimo">Nuevo valor mínimo a establecer.</param>
        public void ModificarMinimo(int nuevoMinimo)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.Find(1);
                if (entidad != null)
                {
                    entidad.Minimo = nuevoMinimo;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Modifica el valor de cuadras en el único registro de importes por cuadras.
        /// </summary>
        /// <param name="nuevoValor">Nuevo valor de cuadras a establecer.</param>
        public void ModificarCuadras(int nuevoValor)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.Find(1);
                if (entidad != null)
                {
                    entidad.Cuadras = nuevoValor;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Modifica el valor de mandado en el único registro de importes por cuadras.
        /// </summary>
        /// <param name="nuevoValor">Nuevo valor de mandado a establecer.</param>
        public void ModificarMandado(int nuevoValor)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.Find(1);
                if (entidad != null)
                {
                    entidad.Mandado = nuevoValor;
                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Modifica el valor de espera en el único registro de importes por cuadras.
        /// </summary>
        /// <param name="nuevoValor">Nuevo valor de espera a establecer.</param>
        public void ModificarEspera(int nuevoValor)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var entidad = contexto.ImportesCuadras.Find(1);
                if (entidad != null)
                {
                    entidad.Espera = nuevoValor;
                    contexto.SaveChanges();
                }
            }
        }
    }
}
