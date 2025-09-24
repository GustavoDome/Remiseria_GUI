using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("vuelta", Schema = "public")]
    public class Vuelta
    {
        [Key, Column("id_viaje", Order = 0)]
        [ForeignKey("Viaje")]
        public int IdViaje { get; set; }

        [Key, Column("id_movil", Order = 1)]
        [ForeignKey("Movil")]
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