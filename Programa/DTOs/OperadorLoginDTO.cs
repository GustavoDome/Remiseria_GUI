using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class OperadorLoginDTO
    {
        public int IdOperador { get; set; }
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
        public string RolUsuario { get; set; }
    }
}
