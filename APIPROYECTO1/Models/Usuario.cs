using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public string usuario { get; set; }
        public string contrasena { get; set; }

        public bool tipo { get; set; }
    }
}
