using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Modificacion.Interfaces
{
    public interface IModificarMovilesVista
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

        event EventHandler modificar;
        event EventHandler volver;
    }
}
