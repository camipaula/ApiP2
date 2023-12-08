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
                    .Include(p => p.Accesorios)
                    .Include(p => p.Promocion)
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
                    .Include(p => p.Accesorios)
                    .Include(p => p.Promocion)

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
        public async Task<IActionResult> Post([FromBody] DetalleCarritoUsuario detallecarritoUsuario)
        {
            DetalleCarrito detallecarrito2 = await _db.DetalleCarrito.FirstOrDefaultAsync(x => x.IdDetalleCarrito.Equals(detallecarritoUsuario.IdDetalleCarrito));
            if (detallecarrito2 == null && detallecarritoUsuario != null)
            {
                var detallecarrito = new DetalleCarrito
                {

                    //Status = detallecarritoUsuario.Status,
                    Cantidad = detallecarritoUsuario.Cantidad,
                    //PrecioTotal =  detallecarritoUsuario.PrecioTotal,
                    PrendaIdPrenda = detallecarritoUsuario.PrendaIdPrenda,
                    AccesorioIdAccesorio = detallecarritoUsuario.AccesorioIdAccesorio,
                    PromocionIdPromocion = detallecarritoUsuario.PromocionIdPromocion,
                    CarritoIdCarrito = detallecarritoUsuario.CarritoIdCarrito,

                };
                await _db.DetalleCarrito.AddAsync(detallecarrito);
                await _db.SaveChangesAsync();
                return Ok(detallecarrito);
            }
            return BadRequest("El detallecarrito ya existe");
        }

        /*  [HttpPut("{IdPrenda}")]
          public async Task<IActionResult> Put(int IdPrenda, [FromBody] PrendaUsuario prendaUsuario)
          {
              Prenda actualaModificar = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);
              var nombrequeyatengo = actualaModificar.Nombre;
              Prenda tallaquequieroponer = await _db.Prendas.FirstOrDefaultAsync(x => x.Nombre.Equals(prendaUsuario.Nombre));

              if ((tallaquequieroponer == null || tallaquequieroponer.Nombre.Equals(nombrequeyatengo)) && prendaUsuario != null)
              {
                  actualaModificar.Nombre = prendaUsuario.Nombre != null ? prendaUsuario.Nombre : actualaModificar.Nombre;
                  actualaModificar.Descripcion = prendaUsuario.Descripcion != null ? prendaUsuario.Descripcion : actualaModificar.Descripcion;
                  actualaModificar.Precio = prendaUsuario.Precio != null ? prendaUsuario.Precio : actualaModificar.Precio;
                  actualaModificar.Cantidad = prendaUsuario.Cantidad != null ? prendaUsuario.Cantidad : actualaModificar.Cantidad;
                  _db.Prendas.Update(actualaModificar);
                  await _db.SaveChangesAsync();
                  return Ok(actualaModificar);
              }
              return BadRequest("La prenda ya existe");
          }*/

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
    }
}