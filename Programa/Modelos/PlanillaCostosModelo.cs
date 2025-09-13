using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Programa.Modelos
{
    public class CuadrasImporteModelo
    {
        private int cuadras;

        public int Cuadras { get; set; }
    }

    public class CuadrasMinimoImporteModelo 
    {
        private int minimo;

        public int Minimo { get; set; }
    }

    public class CuadrasMandadoModelo 
    {
        private int mandado;

        public int Mandado { get; set; }
    }

    public class CuadrasEsperaModelo 
    {
        private int espera;
        public int Espera { get; set; }
    }

    public class ImporteCiudadModelo
    {
        private int kilometro;

        public int Kilometro { get; set; }
    }

    public class ImporteCiudadEspera 
    {
        private int espera;
        public int Espera { get; set; }
    }

    public class CiudadesModelo
    {
        private int id;
        private string ciudad;
        private int importe;

        public int Id { get; set; }
        public string Ciudad { get; set; }
        public int Importe { get; set; }
    }
}
