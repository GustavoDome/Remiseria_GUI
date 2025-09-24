using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("importeciudad", Schema = "public")]
    public class ImporteCiudad
    {
        [Key]
        [Column("id_importe_ciudad")]
        public int IdImporteCiudad { get; set; }

        [Column("kilometro")]
        public int Kilometro { get; set; }

        [Column("espera")]
        public int Espera { get; set; }
    }
}