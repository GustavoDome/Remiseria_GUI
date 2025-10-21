using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Programa.Modelos
{
    /// <summary>
    /// Modelo que representa un operador del sistema, incluyendo configuración visual y estado.
    /// </summary>
    [Table("operador", Schema = "public")]
    public class Operador
    {
        [Key]
        [Column("id_operador")]
        public int IdOperador { get; set; }

        [Column("rolusuario")]
        public string RolUsuario { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("contrasena")]
        public string Contrasena { get; set; }

        [Column("direccion")]
        public string Direccion { get; set; }

        [Column("telefono")]
        public string Telefono { get; set; }

        [Column("tipo_fuente")]
        public string Fuente { get; set; }

        [Column("color_sistema")]
        public string TemaSistema { get; set; }

        [Column("tamanofuente")]
        public int TamanoFuente { get; set; }

        [Column("tipoalarma")]
        public string TipoAlarma { get; set; }

        [Column("activo")]
        public bool Activo { get; set; }
    }
}
