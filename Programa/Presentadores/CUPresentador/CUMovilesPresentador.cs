using Programa.DTOs;
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
    public class CUMovilesPresentador
    {
        public class CUAgregarMovilesPresentador
        {
            private readonly IAgregarMovilesVista vista;
            private readonly IMovilRepositorio repositorio;
            private readonly MovilesPresentador presentador;

            public CUAgregarMovilesPresentador(
                IAgregarMovilesVista vista,
                IMovilRepositorio repositorio,
                MovilesPresentador presentador)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.presentador = presentador;

                vista.agregar += agregar_movil;
                vista.volver += volver;
            }

            private void agregar_movil(object sender, EventArgs e)
            {
                if (vista.NumeroMovil <= 0 ||
                    string.IsNullOrWhiteSpace(vista.Marca) ||
                    string.IsNullOrWhiteSpace(vista.Modelo) ||
                    string.IsNullOrWhiteSpace(vista.Anio) ||
                    string.IsNullOrWhiteSpace(vista.Color) ||
                    string.IsNullOrWhiteSpace(vista.NombreDueno) ||
                    string.IsNullOrWhiteSpace(vista.ApellidoDueno) ||
                    string.IsNullOrWhiteSpace(vista.TelefonoDueno))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                DuenoAuto nuevoDueno = new DuenoAuto
                {
                    Nombre = vista.NombreDueno,
                    Apellido = vista.ApellidoDueno,
                    Telefono = vista.TelefonoDueno,
                    Chofer = vista.EsChofer
                };

                Movil nuevoMovil = new Movil
                {
                    NumeroMovil = vista.NumeroMovil,
                    MarcaAuto = vista.Marca,
                    ModeloAuto = vista.Modelo,
                    AnoAuto = vista.Anio,
                    ColorAuto = vista.Color,
                    Dueno = nuevoDueno,
                    Activo = true
                };

                repositorio.Agregar(nuevoMovil);
                presentador.Recargar();
                ((Form)vista).Close();
            }

            private void volver(object sender, EventArgs e)
            {
                ((Form)vista).Close();
            }
        }
        public class CUModificarMovilPresentador
        {
            private readonly IModificarMovilesVista vista;
            private readonly IMovilRepositorio repositorio;
            private readonly MovilDetalleDTO movilOriginal;
            private readonly MovilesPresentador presentador;

            public CUModificarMovilPresentador(
                IModificarMovilesVista vista,
                IMovilRepositorio repositorio,
                MovilDetalleDTO movilOriginal,
                MovilesPresentador presentador)
            {
                this.vista = vista;
                this.repositorio = repositorio;
                this.movilOriginal = movilOriginal;
                this.presentador = presentador;

                // Precarga de datos
                vista.NumeroMovil = movilOriginal.NumeroMovil;
                vista.Marca = movilOriginal.Marca;
                vista.Modelo = movilOriginal.Modelo;
                vista.Anio = movilOriginal.Ano;
                vista.Color = movilOriginal.Color;
                vista.NombreDueno = movilOriginal.NombreDueno;
                vista.ApellidoDueno = movilOriginal.ApellidoDueno;
                vista.TelefonoDueno = movilOriginal.TelefonoDueno;

                if (movilOriginal.EsChofer)
                    ((Form)vista).Controls.OfType<RadioButton>().First(r => r.Name == "rbtnRemisero").Checked = true;
                else
                    ((Form)vista).Controls.OfType<RadioButton>().First(r => r.Name == "rbtnChofer").Checked = true;

                vista.modificar += modificar_movil;
                vista.volver += volver;
            }

            private void modificar_movil(object sender, EventArgs e)
            {
                if (vista.NumeroMovil <= 0 ||
                    string.IsNullOrWhiteSpace(vista.Marca) ||
                    string.IsNullOrWhiteSpace(vista.Modelo) ||
                    string.IsNullOrWhiteSpace(vista.Anio) ||
                    string.IsNullOrWhiteSpace(vista.Color) ||
                    string.IsNullOrWhiteSpace(vista.NombreDueno) ||
                    string.IsNullOrWhiteSpace(vista.ApellidoDueno) ||
                    string.IsNullOrWhiteSpace(vista.TelefonoDueno))
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                    return;
                }

                var todos = repositorio.ObtenerTodos().ToList(); // solo activos
                var inactivos = repositorio.ObtenerTodosDesdeBD().Where(m => !m.Activo).ToList(); // método nuevo

                bool numeroDuplicado = todos.Any(m =>
                    m.NumeroMovil == vista.NumeroMovil &&
                    m.IdMovil != movilOriginal.IdMovil);

                if (numeroDuplicado)
                {
                    MessageBox.Show("Ya existe un móvil con ese número. Por favor elija otro.");
                    return;
                }

                Movil movilEditado = new Movil
                {
                    IdMovil = movilOriginal.IdMovil,
                    NumeroMovil = vista.NumeroMovil,
                    MarcaAuto = vista.Marca,
                    ModeloAuto = vista.Modelo,
                    AnoAuto = vista.Anio,
                    ColorAuto = vista.Color,
                    IdDueno = movilOriginal.IdDueno,
                    Dueno = new DuenoAuto
                    {
                        IdDueno = movilOriginal.IdDueno,
                        Nombre = vista.NombreDueno,
                        Apellido = vista.ApellidoDueno,
                        Telefono = vista.TelefonoDueno,
                        Chofer = vista.EsChofer
                    },
                    Activo = true
                };
                var confirmacion = MessageBox.Show("¿Está seguro que desea guardar los cambios?","Confirmar modificación",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (confirmacion != DialogResult.Yes) { return; }
                repositorio.Editar(movilEditado);
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
