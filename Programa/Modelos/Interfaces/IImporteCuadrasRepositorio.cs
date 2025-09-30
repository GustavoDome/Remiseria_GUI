using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IImporteCuadrasRepositorio
    {
        CuadrasImporteDTO ObtenerImportes();
        void ModificarMinimo(int nuevoMinimo);
        void ModificarCuadras(int nuevoValor);
        void ModificarMandado(int nuevoValor);
        void ModificarEspera(int nuevoValor);
    }
}
