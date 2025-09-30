using Programa.Modelos.Interfaces;
using Programa.Vistas;
using Programa.Vistas.Alta.Interfaces;
using Programa.Vistas.Interfaces;
using System;
using Programa.Modelos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Programa.Vistas.Modificacion.Interfaces;
using Programa.DTOs;

namespace Programa.Presentadores.CUPresentador
{
    public class CUInicioPresentador
    {
        public class CUAgregarRecordatorio
        {
            private IRecordatorioRepositorio recordatorio;
            private IAgregarInicioVistaRecordatorio agregarvista;
            private int id;
            private InicioPresentador inicio;

            public CUAgregarRecordatorio(IRecordatorioRepositorio recordatorio, IAgregarInicioVistaRecordatorio vista, int id, InicioPresentador inicio)
            {
                this.recordatorio = recordatorio;
                this.agregarvista = vista;
                this.id = id;
                this.inicio = inicio;

                this.agregarvista.volver += volver_menu;
                this.agregarvista.agregar += agregar_viaje;
            }
            private void agregar_viaje(object sender, EventArgs e)
            {
                if (this.agregarvista.fecha != DateTime.MinValue && this.agregarvista.hora != DateTime.MinValue && !string.IsNullOrWhiteSpace(this.agregarvista.direccion))
                {
                    Recordatorio Arecordatorio = new Recordatorio
                    {
                        FechaDia = this.agregarvista.fecha,
                        FechaHora = this.agregarvista.hora,
                        Ubicacion = this.agregarvista.direccion,
                        IdOperador = this.id,
                    };
                    this.recordatorio.Agregar(Arecordatorio);
                    this.inicio.cargarRecordatorio();

                    IInicioVista inicio = InicioVista.ObtenerInstancia();
                    ((Form)agregarvista).Close();
                }
                else
                {
                    MessageBox.Show("Por favor ingrese en todos los campos");
                }
            }
            private void volver_menu(object sender, EventArgs e)
            {
                IInicioVista inicio = InicioVista.ObtenerInstancia();
                ((Form)agregarvista).Close();
            }
        }

        public class CUModificarRecordatorio
        {
            private IModificarInicioVistaRecordatorio modificarRecordatorio;
            private IRecordatorioRepositorio repositorio;
            private int? idrecordatorio;
            private int id;
            private InicioPresentador inicioPresentador;
            public CUModificarRecordatorio(IModificarInicioVistaRecordatorio modificarRecordatorio, IRecordatorioRepositorio repositorio, int? idrecordatorio, int id, InicioPresentador inicioPresentador)
            {
                this.modificarRecordatorio = modificarRecordatorio;
                this.repositorio = repositorio;
                this.idrecordatorio = idrecordatorio;
                this.id = id;
                this.inicioPresentador = inicioPresentador;

                RecordatorioDTO recordatorio = this.repositorio.ObtenerPorId(this.idrecordatorio.Value);
                if (recordatorio == null)
                {
                    MessageBox.Show("No se encontró el recordatorio en la base de datos.");
                    return;
                }

                // ✅ Precargar los datos en la vista
                this.modificarRecordatorio.fecha = recordatorio.FechaDia.Value;
                this.modificarRecordatorio.hora = recordatorio.FechaHora.Value;
                this.modificarRecordatorio.direccion = recordatorio.Direccion;

                // Suscripción a eventos
                this.modificarRecordatorio.modificar += modificar_recordatorio;
                this.modificarRecordatorio.volver += volver_inicio;

            }

            private void modificar_recordatorio(object sender, EventArgs e) 
            {
                RecordatorioDTO recordatorio = this.repositorio.ObtenerPorId(this.idrecordatorio.Value);
                if (recordatorio == null)
                {
                    MessageBox.Show("No se encontró el recordatorio en la base de datos.");
                    return;
                }
                Recordatorio recordatorioModificado = new Recordatorio
                {
                    IdRecordatorio = recordatorio.IdRecordatorio,
                    FechaDia = this.modificarRecordatorio.fecha,
                    FechaHora = this.modificarRecordatorio.hora,
                    Ubicacion = this.modificarRecordatorio.direccion,
                    IdOperador = this.id,
                };
                if(this.modificarRecordatorio.fecha != null || this.modificarRecordatorio.hora != null || this.modificarRecordatorio.direccion != null)
                {
                    this.repositorio.Editar(recordatorioModificado);
                    this.inicioPresentador.cargarRecordatorio();
                    IInicioVista inicio = InicioVista.ObtenerInstancia();
                    ((Form)modificarRecordatorio).Close();
                }
                else 
                {
                    MessageBox.Show("Porfavor complete todos los campos, no puede modificar para que quede vacio");
                }
            }
            private void volver_inicio(object sender, EventArgs e) 
            {
                IInicioVista inicio = InicioVista.ObtenerInstancia();
                ((Form)modificarRecordatorio).Close();
            }
        }
    }
}
