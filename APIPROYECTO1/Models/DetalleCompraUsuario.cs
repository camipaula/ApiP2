using System.ComponentModel.DataAnnotations;

namespace APIPROYECTO1.Models
{
    public class DetalleCompraUsuario
    {
        public int IdDetalleCompra { get; set; }
        //public bool Status { get; set; }
        public int Cantidad { get; set; }
        //public float PrecioTotal { get; set; }
        public int PrendaIdPrenda { get; set; }
        
        public int AccesorioIdAccesorio { get; set; }
        
        public int PromocionIdPromocion { get; set; }
        public int CompraIdCompra { get; set; }
    }
}
