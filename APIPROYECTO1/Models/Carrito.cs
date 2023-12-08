using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class Carrito
    {
        [Key]
        public int IdCarrito { get; set; }
        public int UsuarioidUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
        public string Fecha { get; set; }


    }
}
