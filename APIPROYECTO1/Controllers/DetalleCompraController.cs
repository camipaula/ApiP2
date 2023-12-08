using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleCompraController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public DetalleCompraController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<DetalleCompra> descripcionCompra = await _db.DetalleCompra
                    .Include(p => p.Compra)
                    .Include(p => p.Prenda)
                    .Include(p => p.Accesorios)
                    .Include(p => p.Promocion)
                    .ToListAsync();

                return Ok(descripcionCompra);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpGet("{IdDetalleCompra}")]
        public async Task<IActionResult> Get(int IdDetalleCompra)
        {
            try
            {

                DetalleCompra dc = await _db.DetalleCompra
                    .Include(p => p.Compra)
                    .Include(p => p.Prenda)
                    .Include(p => p.Accesorios)
                    .Include(p => p.Promocion)

                    .FirstOrDefaultAsync(x => x.IdDetalleCompra == IdDetalleCompra);

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
        public async Task<IActionResult> Post([FromBody] DetalleCompraUsuario detallecompraUsuario)
        {
            DetalleCompra detallecompra2 = await _db.DetalleCompra.FirstOrDefaultAsync(x => x.IdDetalleCompra.Equals(detallecompraUsuario.IdDetalleCompra));
            if (detallecompra2 == null && detallecompraUsuario != null)
            {
                var detallecompra = new DetalleCompra
                {

                    //Status = detallecompraUsuario.Status,
                    Cantidad = detallecompraUsuario.Cantidad,
                    //PrecioTotal = detallecompraUsuario.PrecioTotal,
                    PrendaIdPrenda = detallecompraUsuario.PrendaIdPrenda,
                    AccesorioIdAccesorio = detallecompraUsuario.AccesorioIdAccesorio,
                    PromocionIdPromocion = detallecompraUsuario.PromocionIdPromocion,
                    CompraIdCompra = detallecompraUsuario.CompraIdCompra,

                };
                await _db.DetalleCompra.AddAsync(detallecompra);
                await _db.SaveChangesAsync();
                return Ok(detallecompra);
            }
            return BadRequest("El detallecompra ya existe");
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

        [HttpDelete("{IdDetalleCompra}")]
        public async Task<IActionResult> Delete(int IdDetalleCompra)
        {
            DetalleCompra detallecompra = await _db.DetalleCompra.FirstOrDefaultAsync(x => x.IdDetalleCompra == IdDetalleCompra);
            if (detallecompra != null)
            {
                _db.DetalleCompra.Remove(detallecompra);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
    }
}