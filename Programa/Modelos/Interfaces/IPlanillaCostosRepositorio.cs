using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos.Interfaces
{
    public interface IPlanillaCostosRepositorio
    {
        IEnumerable<CuadrasImporteModelo> mostrarImporteCuadras();
        IEnumerable<CuadrasMinimoImporteModelo> mostrarImporteMinimoCuadras();
        IEnumerable<CuadrasEsperaModelo> mostrarEsperaCuadras();
        IEnumerable<CuadrasMandadoModelo> mostrarMandadoCuadras();
        void modificarImporteCuadras(CuadrasImporteModelo cuadras);
        void modificarImporteCuadrasMandado(CuadrasMandadoModelo mandado);
        void modificarImporteCuadrasEspera(CuadrasEsperaModelo espera);

        IEnumerable<ImporteCiudadModelo> mostrarImporteCiudad();
        IEnumerable<ImporteCiudadEspera> mostrarEsperaCiudad();
        void modificarImporteCiudad(ImporteCiudadModelo kilometros);
        void modificarImporteCIudadEspera(ImporteCiudadEspera espera);

        IEnumerable<CiudadesModelo> mostrarCiudades();
        void agregarCiudades(CiudadesModelo ciudad);
        void editarCiudades(CiudadesModelo ciudades);
        void eliminarCiudades(int id);
    }
}
