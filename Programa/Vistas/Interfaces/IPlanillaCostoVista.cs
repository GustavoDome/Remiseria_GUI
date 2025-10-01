using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programa.Vistas.Interfaces
{
    public interface IPlanillaCostoVista
    {
        // Eventos
        event EventHandler modificarCuadrasCosto;
        event EventHandler modificarCuadrasCostoMandado;
        event EventHandler modificarCuadrasEspera;
        event EventHandler modificarCiudadCosto;
        event EventHandler modificarCiudadEspera;
        event EventHandler agregarCiudad;
        event EventHandler modificarCiudad;
        event EventHandler eliminarCiudad;
        event EventHandler volver;

        // Métodos
        void MostrarCiudadesEnLayout(List<CiudadDTO> ciudades);
        void MostrarCuadrasEnLayout(CuadrasImporteDTO dto);
        int? ObtenerCuadraSeleccionada();
        int? ObtenerCiudadSeleccionada();

        // Labels
        void MostrarImportesCuadras(int minimo, int espera, int mandado);
        void MostrarImportesCiudad(int kilometro, int espera);

    }
}
