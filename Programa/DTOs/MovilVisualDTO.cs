using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programa.DTOs
{
    public class MovilVisualDTO
    {
        public int IdMovil { get; set; }
        public string Texto { get; set; }

        public override string ToString()
        {
            return Texto;
        }

    }
}
