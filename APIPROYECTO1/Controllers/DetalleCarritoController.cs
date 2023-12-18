using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCarritoController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public DetalleCarritoController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<DetalleCarrito> descripcionCarrito = await _db.DetalleCarrito
                    .Include(p => p.Carrito)
                    .Include(p => p.Prenda)
                    //.Include(p => p.Accesorios)
                    //.Include(p => p.Promocion)
                    .ToListAsync();

                return Ok(descripcionCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpGet("{IdDetalleCarrito}")]
        public async Task<IActionResult> Get(int IdDetalleCarrito)
        {
            try
            {

                DetalleCarrito dc = await _db.DetalleCarrito
                    .Include(p => p.Carrito)
                    .Include(p => p.Prenda)
                    //.Include(p => p.Accesorios)
                    //.Include(p => p.Promocion)

                    .FirstOrDefaultAsync(x => x.IdDetalleCarrito == IdDetalleCarrito);

                if (dc == null)
                {
                    return BadRequest();
                }

                return Ok(dc);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetalleCarritoUsuario detallecarritoUsuario) // cuando selecciona el producto
        {
            float total = 0;
            DetalleCarrito detallecarrito2 = await _db.DetalleCarrito.FirstOrDefaultAsync(x => x.IdDetalleCarrito == detallecarritoUsuario.IdDetalleCarrito);
            if (detallecarrito2 == null && detallecarritoUsuario != null)
            {
                Prenda prendaComprada = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == detallecarritoUsuario.PrendaIdPrenda);
                if (prendaComprada != null)
                {
                    var precio = prendaComprada.Precio;
                    total = precio * detallecarritoUsuario.Cantidad;
                }
                var detallecarrito = new DetalleCarrito
                {

                    //Status = detallecarritoUsuario.Status,
                    Cantidad = detallecarritoUsuario.Cantidad,
                    PrecioTotal = total,
                    PrendaIdPrenda = detallecarritoUsuario.PrendaIdPrenda,
                    //AccesorioIdAccesorio = detallecarritoUsuario.AccesorioIdAccesorio,
                    //PromocionIdPromocion = detallecarritoUsuario.PromocionIdPromocion,
                    CarritoIdCarrito = detallecarritoUsuario.CarritoIdCarrito,

                };
                await _db.DetalleCarrito.AddAsync(detallecarrito);
                await _db.SaveChangesAsync();
                return Ok(detallecarrito);
            }
            return BadRequest("El detallecarrito ya existe");
        }




        [HttpPost("GenerarDetalleCarrito/")]
        public async Task<IActionResult> PostComprarDescripcion([FromBody] MandarDescripcion mandarDescripcion)
        {
            List<DetalleCarrito> carritodetalle = await _db.DetalleCarrito
                    .Include(pcl => pcl.Carrito)
                    .Include(pct => pct.Prenda)
                    .Where(x => x.CarritoIdCarrito == mandarDescripcion.CarritoIdCarrito)
                    .ToListAsync();
            if (carritodetalle.Count > 0)
            {
                foreach (var carritod in carritodetalle)
                {
                    Prenda prenda = carritod.Prenda;
                    var cantidadactual = prenda.Cantidad - carritod.Cantidad;
                    carritod.Prenda.Cantidad = cantidadactual;
                    var descripcion = new DetalleCompra
                    {
                        Cantidad = carritod.Cantidad,
                        PrecioTotal = carritod.PrecioTotal,
                        Status = carritod.Status,
                        PrendaIdPrenda = carritod.PrendaIdPrenda,
                        CompraIdCompra = mandarDescripcion.CompraIdCompra
                    };
                    await _db.DetalleCompra.AddAsync(descripcion);
                    await _db.SaveChangesAsync();
                }
                return Ok();
            }

            return BadRequest("No existe la intencion de compra");
        }



        [HttpDelete("{IdDetalleCarrito}")]
        public async Task<IActionResult> Delete(int IdDetalleCarrito)
        {
            DetalleCarrito detallecarrito = await _db.DetalleCarrito.FirstOrDefaultAsync(x => x.IdDetalleCarrito == IdDetalleCarrito);
            if (detallecarrito != null)
            {
                _db.DetalleCarrito.Remove(detallecarrito);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }

        //metodos nuevos
        // metodo que me retorna la lista de productos por carrito.
        [HttpGet("porCarrito/{CarritoIdCarrito}")]
        public async Task<IActionResult> GetDetalleCarrito(int CarritoIdCarrito)
        {

            try
            {
                List<DetalleCarrito> detalleCarrito = await _db.DetalleCarrito
                    .Include(p => p.Carrito)
                    .Include(p => p.Prenda)
                    //.Include(p => p.Accesorios)
                    //.Include(p => p.Promocion)
                    .Where(x => x.CarritoIdCarrito == CarritoIdCarrito)
                    .ToListAsync();

                return Ok(detalleCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }


        //[HttpPost("CrearNuevoDetalle/")]
        //public async Task<IActionResult> PostCompra([FromBody]MandarDescripcion mandar)
        //{

        //    List<DetalleCarrito> detalleCarrito = await _db.DetalleCarrito
        //            .Include(p => p.Carrito)
        //            .Include(p => p.Prenda)
        //            //.Include(p => p.Accesorios)
        //            //.Include(p => p.Promocion)
        //            .Where(x => x.CarritoIdCarrito == mandar.carritoIdCarrito)
        //            .ToListAsync();

        //    if (detalleCarrito.Count >0)
        //    {
        //        foreach (var viejoDetalleCarrito in detalleCarrito)
        //        {
        //            Prenda prenda = viejoDetalleCarrito.Prenda;
        //            var cantidadActual = prenda.Cantidad - viejoDetalleCarrito.Cantidad;
        //            viejoDetalleCarrito.Prenda.Cantidad = cantidadActual;

        //            var descripcionNueva = new DetalleCompra
        //            {
        //                Cantidad = viejoDetalleCarrito.Cantidad,
        //                PrecioTotal = viejoDetalleCarrito.PrecioTotal,
        //                PrendaIdPrenda = viejoDetalleCarrito.PrendaIdPrenda,
        //                AccesorioIdAccesorio = viejoDetalleCarrito.AccesorioIdAccesorio,
        //                PromocionIdPromocion = viejoDetalleCarrito.PromocionIdPromocion,
        //                CompraIdCompra = mandar.compraIdCompra,

        //            };

        //            await _db.DetalleCompra.AddAsync(descripcionNueva);
        //            await _db.SaveChangesAsync();

        //        }

        //        return Ok();
        //    }

        //    return BadRequest("La lista estaba vacia");

        //}

    }
}