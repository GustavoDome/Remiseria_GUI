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
        private string contrasena;
        private string direccion;
        private string telefono;
        private string fuente;
        private bool activo;
        private string tamanoFuente;
        private string temaSistema;
        private string tipoAlarma;

        public int Id
        {
            get {return id;}
            set {id = value;}
        }
        public string RolUsuario
        {
            get { return rolUsuario; }
            set {  rolUsuario = value;}
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Contrasena 
        {
            get { return contrasena; }
            set { contrasena = value;}
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public string Fuente
        {
            get { return fuente; }
            set { fuente = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public string TamanoFuente
        {
            get { return tamanoFuente; }
            set { tamanoFuente = value; }
        }

        public string TemaSistema
        {
            get { return temaSistema; }
            set { temaSistema = value; }
        }

        public string TipoAlarma
        {
            get { return tipoAlarma; }
            set { tipoAlarma = value; }
        }
    }
}
