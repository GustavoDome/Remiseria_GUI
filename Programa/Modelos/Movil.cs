using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa un móvil registrado en el sistema.
    /// </summary>
    [Table("movil", Schema = "public")]
    public class Movil
    {
        [Key]
        [Column("id_movil")]
        public int IdMovil { get; set; }

        [Column("numero_movil")]
        public int NumeroMovil { get; set; }

        [Column("marca_auto")]
        public string MarcaAuto { get; set; }

        [Column("modelo_auto")]
        public string ModeloAuto { get; set; }

        [Column("ano_auto")]
        public string AnoAuto { get; set; }

        [Column("color_auto")]
        public string ColorAuto { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        [Column("id_dueno")]
        public int IdDueno { get; set; }

        [ForeignKey("IdDueno")]
        public virtual DuenoAuto Dueno { get; set; }
    }
}
