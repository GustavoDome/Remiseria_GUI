using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    [Table("respuesta", Schema = "public")]
    public class Respuesta
    {
        [Key]
        [Column("id_respuesta")]
        public int IdRespuesta { get; set; }

        [Column("respuesta_texto")]
        public string TextoRespuesta { get; set; }

        [Column("respuesta_audio_video")]
        public byte[] AudioVideo { get; set; }

        [Column("id_pregunta")]
        public int IdPregunta { get; set; }

        [ForeignKey("IdPregunta")]
        public virtual Pregunta Pregunta { get; set; }
    }
}
