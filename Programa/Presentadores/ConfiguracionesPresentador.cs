using Programa.Commons;
using Programa.DTOs;
using Programa.Estilos;
using Programa.Modelos;
using Programa.Modelos.Interfaces;
using Programa.Repositorios;
using Programa.Vistas;
using Programa.Vistas.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Presentadores
{
    public class ConfiguracionesPresentador
    {
        private readonly IOperadorRepositorio repositorio;
        private readonly IConfiguracionesVista vista;
        private readonly int idOperador;

        public ConfiguracionesPresentador(IConfiguracionesVista vista, IOperadorRepositorio repositorio, string rol, int id)
        {
            this.vista = vista;
            this.repositorio = repositorio;
            this.idOperador = id;

            this.vista.guardar += guardar_configuracion;
            this.vista.volver += volver_menu;

            BindingSource temas = new BindingSource();
            temas.DataSource = new List<string> { "Claro", "Oscuro", "Azul", "Verde", "Rojo", "Gris","Rosa","Celeste","Turquesa","Purpura" };
            vista.SetTemaSistemaBindingSource(temas);

            BindingSource fuentes = new BindingSource();
            var disponibles = FontFamily.Families.Select(f => f.Name).OrderBy(n => n).ToList();
            fuentes.DataSource = disponibles;
            vista.SetTipoFuenteBindingSource(fuentes);

            cargar_configuracion();
        }

        private void cargar_configuracion()
        {
            var config = repositorio.ObtenerConfiguracion(idOperador);
            if (config != null)
            {
                vista.tipoFuente = config.Fuente;
                vista.tamanoFuente = config.TamanoFuente.ToString();
                vista.temaSistema = config.TemaColor;
                vista.tipoAlarma = config.TipoAlarma;
            }
        }

        private void guardar_configuracion(object sender, EventArgs e)
        {
            var config = new ConfiguracionDTO
            {
                Fuente = vista.tipoFuente,
                TamanoFuente = int.TryParse(vista.tamanoFuente, out int tamaño) ? Math.Max(7, Math.Min(tamaño, 13)) : 12,
                TemaColor = vista.temaSistema,
                TipoAlarma = vista.tipoAlarma
            };

            repositorio.EditarConfiguracion(idOperador, config);

            // Aplicar visualmente si ya tenés el singleton definido
            GestorEstilosGlobal.Instance.AplicarConfiguracion(config);

            // 🔄 Aplicar en tiempo real
            vista.RefrescarEstilos(); // ← actualiza la vista de configuración
            InicioVista.ObtenerInstancia().RefrescarEstilos(); // ← actualiza la vista de inicio
            ConfiguracionesVista.ObtenerInstancia();
        }

        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
