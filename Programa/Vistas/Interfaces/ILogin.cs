using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Interfaces
{
    public interface ILogin
    {
        //Propiedades
        string txtUsuarios { get; set; }
        string txtContrasenas { get; set; }

        //Eventos
        event EventHandler buscarUsuario;
    }
}
