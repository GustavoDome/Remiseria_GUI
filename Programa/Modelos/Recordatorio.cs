using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("recordatorio", Schema = "public")]
    public class Recordatorio
    {
        [Key]
        [Column("id_recordatorio")]
        public int IdRecordatorio { get; set; }

        [Column("ubicacion")]
        public string Ubicacion { get; set; }

        [Column("fecha_dia")]
        public DateTime? FechaDia { get; set; }

        [Column("fecha_hora")]
        public DateTime? FechaHora { get; set; }

        [Column("comentario")]
        public string Comentario { get; set; }

        [Column("id_operador")]
        public int IdOperador { get; set; }

        [ForeignKey("IdOperador")]
        public virtual Operador Operador { get; set; }
    }
}