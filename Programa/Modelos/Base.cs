using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("bases", Schema = "public")]
    public class Base
    {
        [Key]
        [Column("id_base")]
        public int IdBase { get; set; }

        [Column("estado_base")]
        public bool EstadoBase { get; set; }

        [Column("fecha_base")]
        public DateTime Fecha_base { get; set; }

        [Column("comentario")]
        public string Comentario { get; set; }

        [Column("id_movil")]
        public int IdMovil { get; set; }

        [Column("id_operador")]
        public int IdOperador { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [ForeignKey("IdMovil")]
        public virtual Movil Movil { get; set; }

        [ForeignKey("IdOperador")]
        public virtual Operador Operador { get; set; }
    }
}