using Programa.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa un viaje registrado en el sistema.
    /// </summary>
    [Table("viajes", Schema = "public")]
    public class Viaje
    {
        [Key]
        [Column("id_viajes")]
        public int IdViajes { get; set; }

        [Column("hora_viaje")]
        public TimeSpan HoraViaje { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("comentario")]
        public string Comentario { get; set; }

        [Column("estado_viaje")]
        public string EstadoViaje { get; set; }

        [Column("id_operador")]
        public int IdOperador { get; set; }

        [Column("numero_viaje")]
        public int NumeroViaje { get; set; }

        [ForeignKey("IdOperador")]
        public virtual Operador Operador { get; set; }

        public virtual ICollection<Vuelta> Vueltas { get; set; }
    }
}
