using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class UsuarioModelo
    {
        private int id;
        private string rolUsuario;
        private string nombre;
        private string direccion;
        private string telefono;
        private string fuente;
        private bool activo;
        private string tamanoFuente;
        private string temaSistema;
        private string tipoAlarma;

        public int Id
        {
            get {return Id;}
            set {Id = value;}
        }
        public string RolUsuario
        {
            get { return RolUsuario; }
            set {  RolUsuario = value;}
        }

        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string Direccion
        {
            get { return Direccion; }
            set { Direccion = value; }
        }

        public string Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        public string Fuente
        {
            get { return Fuente; }
            set { Fuente = value; }
        }

        public bool Activo
        {
            get { return Activo; }
            set { Activo = value; }
        }

        public string TamanoFuente
        {
            get { return TamanoFuente; }
            set { TamanoFuente = value; }
        }

        public string TemaSistema
        {
            get { return TemaSistema; }
            set { TemaSistema = value; }
        }

        public string TipoAlarma
        {
            get { return TipoAlarma; }
            set { TipoAlarma = value; }
        }
    }
}
