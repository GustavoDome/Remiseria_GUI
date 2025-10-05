using Programa.DTOs;
using Programa.Modelos.Interfaces;
using Programa.Presentadores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Commons
{
    public class GestorAlarmasGlobal
    {
        private readonly IRecordatorioRepositorio repositorio;
        private readonly Timer reloj;
        private readonly HashSet<int> recordatoriosNotificados = new HashSet<int>();
        private readonly HashSet<int> recordatoriosEliminados = new HashSet<int>();
        private readonly int idOperador;
        private readonly string tipoAlarma;
        private InicioPresentador InicioPresentador;

        public GestorAlarmasGlobal(IRecordatorioRepositorio repositorio, int idOperador, InicioPresentador inicioPresentador)
        {
            this.repositorio = repositorio;
            this.idOperador = idOperador;
            this.tipoAlarma = repositorio.ObtenerTipoAlarma(this.idOperador);
            this.InicioPresentador = inicioPresentador;

            this.reloj = new Timer();
            this.reloj.Interval = 60000;
            this.reloj.Tick += VerificarAlarmas;
            this.reloj.Start();
        }

        private void VerificarAlarmas(object sender, EventArgs e)
        {
            var ahora = DateTime.Now;
            var recordatorios = repositorio.ObtenerTodos();

            foreach (var r in recordatorios)
            {
                if (r.FechaDia == null || r.FechaHora == null)
                    continue;

                var fechaCompleta = r.FechaDia.Value.Date + r.FechaHora.Value.TimeOfDay;
                var minutosRestantes = (fechaCompleta - ahora).TotalMinutes;
                int minutos = (int)Math.Round(minutosRestantes);

                if ((minutos == 15 || minutos == 10 || minutos == 5 || minutos == 0) &&
                    !recordatoriosNotificados.Contains(r.IdRecordatorio))
                {
                    MostrarPopup(r);
                    recordatoriosNotificados.Add(r.IdRecordatorio);
                }

                if (minutos <= -5 && !recordatoriosEliminados.Contains(r.IdRecordatorio))
                {
                    MostrarPopup(r);
                    repositorio.Eliminar(r.IdRecordatorio);
                    this.InicioPresentador.cargarRecordatorio();
                    recordatoriosEliminados.Add(r.IdRecordatorio);
                }
            }
        }
        private void ReproducirAlarma()
        {
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Commons", "Alarmas");
            string ruta = Path.Combine(basePath, this.tipoAlarma + ".wav");

            if (File.Exists(ruta))
            {
                using (var player = new System.Media.SoundPlayer(ruta))
                {
                    player.Play();
                }
            }
        }
        private void MostrarPopup(RecordatorioDTO r)
        {
            var mensaje = $" Dirección: {r.Direccion}\n Hora: {r.FechaHora:HH:mm}\n Operador: {r.NombreOperador}";
            ReproducirAlarma();

            Task.Run(() =>
            {
                Form formularioActivo = Form.ActiveForm ?? Application.OpenForms.Cast<Form>().FirstOrDefault();

                if (formularioActivo != null && formularioActivo.InvokeRequired)
                {
                    formularioActivo.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show(formularioActivo, mensaje, "Recordatorio próximo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }));
                }
                else
                {
                    MessageBox.Show(mensaje, "Recordatorio próximo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });
        }
    }
}
