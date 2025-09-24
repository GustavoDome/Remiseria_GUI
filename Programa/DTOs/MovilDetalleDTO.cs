using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class MovilDetalleDTO
    {
        public int IdMovil { get; set; }
        public int NumeroMovil { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Color { get; set; }

        // Datos del dueño
        public int IdDueno { get; set; }
        public string NombreDueno { get; set; }
        public string ApellidoDueno { get; set; }
        public string TelefonoDueno { get; set; }
        public bool EsChofer { get; set; }
    }
}
