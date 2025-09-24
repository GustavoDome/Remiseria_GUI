using Programa.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IImporteCiudadRepositorio
    {
        ImporteCiudadDTO ObtenerImportes();
        void ModificarImportes(ImporteCiudadDTO dto);
    }
}