using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa los importes configurados por cuadras, mínimo, mandado y espera.
    /// </summary>
    [Table("importescuadras", Schema = "public")]
    public class ImporteCuadras
    {
        [Key]
        [Column("id_importe_cuadra")]
        public int IdImporteCuadra { get; set; }

        [Column("minimo")]
        public int Minimo { get; set; }

        [Column("cuadras")]
        public int Cuadras { get; set; }

        [Column("mandado")]
        public int Mandado { get; set; }

        [Column("espera")]
        public int Espera { get; set; }
    }
}
