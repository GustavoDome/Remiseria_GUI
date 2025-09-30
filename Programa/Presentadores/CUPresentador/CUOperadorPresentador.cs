using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Modificacion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores.CUPresentador
{
    public class CUOperadorPresentador
    {
        public class CUAgregarOperadorPresentador
        {
            private readonly IAgregarOperadoresVista vista;
            private readonly IOperadorRepositorio repositorio;
            private readonly OperadoresPresentador presentador;

            public CUAgregarOperadorPresentador(
                IAgregarOperadoresVista vista,
                IOperadorRepositorio repositorio,
                OperadoresPresentador presentador)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.presentador = presentador;

                vista.agregar += agregar_operador;
                vista.volver += volver;
            }

            private void agregar_operador(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(vista.Nombre) ||
                    string.IsNullOrWhiteSpace(vista.Direccion) ||
                    string.IsNullOrWhiteSpace(vista.Telefono) ||
                    string.IsNullOrWhiteSpace(vista.Contrasena))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                Operador nuevo = new Operador
                {
                    Nombre = vista.Nombre,
                    Direccion = vista.Direccion,
                    Telefono = vista.Telefono,
                    Contrasena = vista.Contrasena,
                    RolUsuario = vista.Rol,
                    Fuente = "calibri",
                    TamanoFuente = 11,
                    TemaSistema = "claro",
                    TipoAlarma = "base",
                    Activo = true
                };

                var existentes = repositorio.ObtenerTodos().ToList();

                bool nombreDuplicado = existentes.Any(o => o.Nombre == vista.Nombre);
                bool contrasenaDuplicada = existentes.Any(o => o.Contrasena == vista.Contrasena);

                if (nombreDuplicado || contrasenaDuplicada)
                {
                    MessageBox.Show("Ya existe un operador con ese nombre o contraseña. Por favor elija otros valores.");
                    return;
                }

                repositorio.Agregar(nuevo);
                presentador.Recargar(); // método que refresca la grilla
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarOperadorPresentador
        {
            private readonly IModificarOperadorVista vista;
            private readonly IOperadorRepositorio repositorio;
            private readonly Operador operadorOriginal;
            private readonly OperadoresPresentador presentador;

            public CUModificarOperadorPresentador(
                IModificarOperadorVista vista,
                IOperadorRepositorio repositorio,
                Operador operadorOriginal,
                OperadoresPresentador presentador)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.operadorOriginal = operadorOriginal;
                this.presentador = presentador;

                // Precargar datos
                vista.Nombre = operadorOriginal.Nombre;
                vista.Direccion = operadorOriginal.Direccion;
                vista.Telefono = operadorOriginal.Telefono;
                vista.Contrasena = operadorOriginal.Contrasena;
                if (operadorOriginal.RolUsuario == "Gerente")
                    ((Form)vista).Controls.OfType<RadioButton>().First(r => r.Text == "Gerente").Checked = true;
                else
                    ((Form)vista).Controls.OfType<RadioButton>().First(r => r.Text == "Operador").Checked = true;

                vista.modificar += modificar_operador;
                vista.volver += volver;
            }

            private void modificar_operador(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(vista.Nombre) ||
                    string.IsNullOrWhiteSpace(vista.Direccion) ||
                    string.IsNullOrWhiteSpace(vista.Telefono) ||
                    string.IsNullOrWhiteSpace(vista.Contrasena))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                Operador operadorEditado = new Operador
                {
                    IdOperador = operadorOriginal.IdOperador,
                    Nombre = vista.Nombre,
                    Direccion = vista.Direccion,
                    Telefono = vista.Telefono,
                    Contrasena = vista.Contrasena,
                    RolUsuario = vista.Rol,

                    // Mantener configuración original
                    Fuente = operadorOriginal.Fuente,
                    TamanoFuente = operadorOriginal.TamanoFuente,
                    TemaSistema = operadorOriginal.TemaSistema,
                    TipoAlarma = operadorOriginal.TipoAlarma,
                    Activo = true
                };

                repositorio.Editar(operadorEditado);
                presentador.Recargar();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
    }
}
