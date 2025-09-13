using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Vistas.Alta.Interfaces
{
    public interface IAgregarViajesVista
    {
        string txtDirecciones { get; set; }
        string rtbComentarios { get; set; }

        string rbtnAfueras { get; set; }
        string rbtnDerivados { get; set; }
        string rbtnDesignados { get; set; }
        string rbtnOtros { get; set; }

    }
}
