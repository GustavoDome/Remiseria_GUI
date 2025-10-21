using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    /// <summary>
    /// Contrato de la vista para agregar un nuevo móvil.
    /// Permite ingresar datos del vehículo y del remisero, incluyendo si es chofer.
    /// </summary>
    public interface IAgregarMovilesVista
    {
        int NumeroMovil { get; set; }
        string Marca { get; set; }
        string Modelo { get; set; }
        string Anio { get; set; }
        string Color { get; set; }

        string NombreDueno { get; set; }
        string ApellidoDueno { get; set; }
        string TelefonoDueno { get; set; }
        bool EsChofer { get; }

        event EventHandler agregar;
        event EventHandler volver;
    }
}
