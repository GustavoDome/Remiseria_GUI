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
    /// <summary>
    /// Repositorio encargado de gestionar operaciones CRUD y autenticación sobre la entidad Operador.
    /// Implementa la interfaz <see cref="IOperadorRepositorio"/>.
    /// </summary>
    public class OperadorRepositorio : IOperadorRepositorio
    {
        /// <summary>
        /// Agrega un nuevo operador al contexto de datos y guarda los cambios.
        /// </summary>
        /// <param name="nuevoOperador">Instancia de <see cref="Operador"/> que representa el nuevo operador a registrar.</param>
        public void Agregar(Operador nuevoOperador)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                contexto.Operadores.Add(nuevoOperador);
                contexto.SaveChanges();
            }
        }

        /// <summary>
        /// Edita los datos de un operador existente en la base de datos.
        /// </summary>
        /// <param name="operadorEditado">Instancia de <see cref="Operador"/> con los nuevos datos a actualizar.</param>
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

        /// <summary>
        /// Realiza un borrado lógico del operador, marcándolo como inactivo.
        /// </summary>
        /// <param name="id">Identificador del operador a eliminar.</param>
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

        /// <summary>
        /// Obtiene todos los operadores activos desde la base de datos.
        /// </summary>
        /// <returns>
        /// Lista de objetos <see cref="Operador"/> que representan los operadores activos.
        /// </returns>
        public IEnumerable<Operador> ObtenerTodos()
        {
            using (var contexto = new RemiseriaDbContext())
            {
                return contexto.Operadores
                    .Where(o => o.Activo)
                    .ToList();
            }
        }

        /// <summary>
        /// Muestra todos los operadores activos reutilizando el método <see cref="ObtenerTodos"/>.
        /// </summary>
        /// <returns>
        /// Lista de operadores activos.
        /// </returns>
        public IEnumerable<Operador> MostrarActivos()
        {
            return ObtenerTodos(); // reutiliza el método existente
        }

        /// <summary>
        /// Obtiene la configuración visual y de alarma de un operador activo.
        /// </summary>
        /// <param name="id">Identificador del operador.</param>
        /// <returns>
        /// Objeto <see cref="ConfiguracionDTO"/> con los valores de fuente, tamaño, tema y tipo de alarma.
        /// </returns>
        public ConfiguracionDTO ObtenerConfiguracion(int id)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores
                    .FirstOrDefault(ID => ID.IdOperador == id && ID.Activo);

                if (operador != null)
                {
                    return new ConfiguracionDTO
                    {
                        Fuente = operador.Fuente,
                        TamanoFuente = operador.TamanoFuente,
                        TemaColor = operador.TemaSistema,
                        TipoAlarma = operador.TipoAlarma
                    };
                }

                return null;
            }
        }

        /// <summary>
        /// Edita la configuración visual y de alarma de un operador activo.
        /// </summary>
        /// <param name="id">Identificador del operador.</param>
        /// <param name="config">Objeto <see cref="ConfiguracionDTO"/> con los nuevos valores de configuración.</param>
        public void EditarConfiguracion(int id, ConfiguracionDTO config)
        {
            using (var contexto = new RemiseriaDbContext())
            {
                var operador = contexto.Operadores.FirstOrDefault(o => o.IdOperador == id && o.Activo);

                if (operador != null)
                {
                    operador.Fuente = config.Fuente;
                    operador.TamanoFuente = config.TamanoFuente;
                    operador.TemaSistema = config.TemaColor;
                    operador.TipoAlarma = config.TipoAlarma;

                    contexto.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Autentica a un operador activo mediante nombre de usuario y contraseña.
        /// </summary>
        /// <param name="nombre">Nombre de usuario del operador.</param>
        /// <param name="contrasena">Contraseña del operador.</param>
        /// <returns>
        /// Objeto <see cref="OperadorLoginDTO"/> con los datos básicos del operador autenticado, o null si no se encuentra.
        /// </returns>
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
