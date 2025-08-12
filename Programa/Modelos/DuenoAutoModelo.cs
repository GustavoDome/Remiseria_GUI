using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class DuenoAutoModelo
    {
        private int id;
        private string nombre;
        private string apellido;
        private string direccion;
        private bool chofer;
        private string telefono;
        private bool activo;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public bool Chofer { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }
    }
}
