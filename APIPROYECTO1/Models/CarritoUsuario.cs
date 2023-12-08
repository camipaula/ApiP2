using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPROYECTO1.Models
{
    public class CarritoUsuario
    {
        [Key]
        public int IdCarrito { get; set; }
        
        public int UsuarioidUsuario { get; set; }      
        public string Fecha { get; set; }
    }
}
