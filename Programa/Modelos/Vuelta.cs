using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("vuelta", Schema = "public")]
    public class Vuelta
    {
        [Key]
        [Column("id_vuelta")]
        public int IdVuelta { get; set; } // Nueva clave primaria única

        [ForeignKey("Viaje")]
        [Column("id_viaje")]
        public int? IdViaje { get; set; } // Nullable para vueltas manuales

        [ForeignKey("Movil")]
        [Column("id_movil")]
        public int IdMovil { get; set; }

        [Column("vuelta")]
        public int NumeroVuelta { get; set; }

        [Column("vuelta_fecha")]
        public DateTime VueltaFecha { get; set; }

        [Column("estado_vuelta")]
        public string EstadoVuelta { get; set; }

        public virtual Viaje Viaje { get; set; }
        public virtual Movil Movil { get; set; }
    }
}