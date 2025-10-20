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
    /// <summary>
    /// Presentador encargado de gestionar la configuración visual y de alarmas del operador.
    /// Coordina entre la vista de configuración y el repositorio de operadores.
    /// </summary>
    public class ConfiguracionesPresentador
    {
        private readonly IOperadorRepositorio repositorio;
        private readonly IConfiguracionesVista vista;
        private readonly int idOperador;

        /// <summary>
        /// Inicializa el presentador con la vista, el repositorio, el rol del operador y su identificador.
        /// </summary>
        /// <param name="vista">Vista que implementa <see cref="IConfiguracionesVista"/>.</param>
        /// <param name="repositorio">Repositorio que implementa <see cref="IOperadorRepositorio"/>.</param>
        /// <param name="rol">Rol del operador (por ejemplo: "Gerente").</param>
        /// <param name="id">Identificador del operador actual.</param>
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

            BindingSource alarmas = new BindingSource();
            alarmas.DataSource = new List<string> { "base", "fuerte", "tranquila", "constante", "reloj"};
            vista.SetTipoAlarmaBindingSource(alarmas);

            cargar_configuracion();
        }

        /// <summary>
        /// Carga la configuración actual del operador desde el repositorio y la aplica a la vista.
        /// </summary>
        private void cargar_configuracion()
        {
            var config = repositorio.ObtenerConfiguracion(idOperador);
            if (config != null)
            {
                vista.tipoFuente = config.Fuente;
                vista.tamanoFuente = config.TamanoFuente.ToString();
                vista.temaSistema = config.TemaColor;
                vista.tipoAlarma = config.TipoAlarma;
                // Reproducir preview de la alarma seleccionada
                ((ConfiguracionesVista)vista).ReproducirAlarmaPreview(config.TipoAlarma);
            }
        }

        /// <summary>
        /// Guarda la configuración modificada por el operador y aplica los estilos visuales en tiempo real.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
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

        /// <summary>
        /// Cierra la vista de configuración y retorna al menú de inicio.
        /// </summary>
        /// <param name="sender">Origen del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void volver_menu(object sender, EventArgs e)
        {
            IInicioVista inicio = InicioVista.ObtenerInstancia();
            ((Form)vista).Close();
        }
    }
}
