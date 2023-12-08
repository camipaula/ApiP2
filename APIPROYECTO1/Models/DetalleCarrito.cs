using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class DetalleCarrito
    {
        [Key]
        public int IdDetalleCarrito { get; set; }
        public bool Status {  get; set; }
        public int Cantidad { get; set; }
        public float PrecioTotal {  get; set; }

        public int PrendaIdPrenda { get; set; }
        public virtual Prenda Prenda { get; set; }
        public int AccesorioIdAccesorio { get; set; }
        public virtual Accesorios Accesorios { get; set; }
        public int PromocionIdPromocion { get; set; }
        public virtual Promocion Promocion { get; set; }
        public int CarritoIdCarrito { get; set; }
        public virtual Carrito Carrito { get; set; }


    }
}
