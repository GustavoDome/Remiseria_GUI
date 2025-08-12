using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class BasesModelo
    {
        private int id;
        private bool estado_base;
        private string fecha_base;
        private bool activo;
        private int id_movil;
        private int id_operador;

        public int Id { get; set; }
        public bool Estado_base { get; set; }
        public string Fecha_base { get; set; }
        public bool Activo { get; set; }
        public int Id_movil { get; set; }
        public int Id_operador { get; set; }
    }
}