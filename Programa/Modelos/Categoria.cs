using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Programa.Modelos;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa una categoría de preguntas.
    /// </summary>
    [Table("categoria", Schema = "public")]
    public class Categoria
    {
        [Key]
        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("categoria_pregunta")]
        public string CategoriaPregunta { get; set; }

        // Relación con Pregunta (1 a muchos)
        public virtual ICollection<Pregunta> Preguntas { get; set; }
    }
}

