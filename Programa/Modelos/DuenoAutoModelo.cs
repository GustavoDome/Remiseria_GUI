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

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nombre 
        { 
            get { return nombre; }
            set { nombre = value; } 
        }

        public string Apellido
        {
            get { return apellido; }
            set {  apellido = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public bool Chofer
        {
            get { return chofer; }
            set { chofer = value; }
        }
        public string Telefono
        {
            get { return telefono; }
            set {  telefono = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }
    }
}
