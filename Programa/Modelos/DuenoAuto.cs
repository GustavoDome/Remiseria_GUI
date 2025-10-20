using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa un dueño de móvil, incluyendo si también es chofer.
    /// </summary>
    [Table("dueno_auto", Schema = "public")]
    public class DuenoAuto
    {
        [Key]
        [Column("id_dueno")]
        public int IdDueno { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellido")]
        public string Apellido { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("chofer")]
        public bool Chofer { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }

        // Relación con Movil (1 a muchos)
        public virtual ICollection<Movil> Moviles { get; set; }
    }
}

