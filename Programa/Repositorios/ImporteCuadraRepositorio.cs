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
