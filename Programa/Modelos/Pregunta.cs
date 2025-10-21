using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Programa.Modelos;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa una pregunta registrada en el sistema.
    /// </summary>
    [Table("pregunta", Schema = "public")]
    public class Pregunta
    {
        [Key]
        [Column("id_pregunta")]
        public int IdPregunta { get; set; }

        [Column("pregunta")]
        public string TextoPregunta { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        public virtual ICollection<Respuesta> Respuestas { get; set; }
    }
}
