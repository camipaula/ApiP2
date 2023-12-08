using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class CompraUsuario
    {
        [Key]
        public int IdCompraUsuario { get; set; }
        public int UsuarioidUsuario { get; set; }
        public string Fecha { get; set; }
    }
}
