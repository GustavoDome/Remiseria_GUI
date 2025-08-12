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

        public int Id { get; set; }
        public string RolUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Fuente { get; set; }
        public bool Activo { get; set; }
        public string TamanoFuente { get; set; }
        public string TemaSistema { get; set; }
        public string TipoAlarma { get; set; }
    }
}