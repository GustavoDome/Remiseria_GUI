using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa una ciudad y su importe asociado para viajes.
    /// </summary>
    [Table("ciudad", Schema = "public")]
    public class Ciudad
    {
        [Key]
        [Column("id_ciudad")]
        public int IdCiudad { get; set; }

        [Column("ciudad")]
        public string NombreCiudad { get; set; }

        [Column("importe")]
        public int Importe { get; set; }
    }
}
