using Npgsql;
using Programa.Conexion;
using Programa.DTOs;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using static Programa.Conexion.RemiseriaDbContext;

namespace Programa.Repositorios
{
    public class OperadorRepositorio : IOperadorRepositorio
    {
        public void Agregar(Operador nuevoOperador)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Operadores.Add(nuevoOperador);
                contexto.SaveChanges();
            }
        }

        public void Editar(Operador operadorEditado)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operadorExistente = contexto.Operadores.Find(operadorEditado.IdOperador);
                if (operadorExistente != null)
                {
                    operadorExistente.RolUsuario = operadorEditado.RolUsuario;
                    operadorExistente.Nombre = operadorEditado.Nombre;
                    operadorExistente.Contrasena = operadorEditado.Contrasena;
                    operadorExistente.Direccion = operadorEditado.Direccion;
                    operadorExistente.Telefono = operadorEditado.Telefono;
                    operadorExistente.Fuente = operadorEditado.Fuente;
                    operadorExistente.TemaSistema = operadorEditado.TemaSistema;
                    operadorExistente.TamanoFuente = operadorEditado.TamanoFuente;
                    operadorExistente.TipoAlarma = operadorEditado.TipoAlarma;

                    contexto.SaveChanges();
                }
            }
        }

        public void Eliminar(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores.Find(id);
                if (operador != null)
                {
                    operador.Activo = false;
                    contexto.SaveChanges();
                }
            }
        }

        public IEnumerable<Operador> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Operadores
                    .Where(o => o.Activo)
                    .ToList();
            }
        }
        public IEnumerable<Operador> MostrarActivos()
        {
            return ObtenerTodos(); // reutiliza el método existente
        }
        public OperadorLoginDTO Autenticar(string nombre, string contrasena)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores
                    .FirstOrDefault(o => o.Nombre == nombre && o.Contrasena == contrasena && o.Activo);

                if (operador != null)
                {
                    return new OperadorLoginDTO
                    {
                        IdOperador = operador.IdOperador,
                        Nombre = operador.Nombre,
                        Contrasena = operador.Contrasena,
                        RolUsuario = operador.RolUsuario
                    };
                }

                return null;
            }
        }
    }
}
