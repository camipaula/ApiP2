using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public CarritoController(ApplicationDBContext db)
        {
            _db = db;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<Carrito> usuariosCarrito = await _db.Carrito
                    .Include(p => p.Usuario)
                    .ToListAsync();

                return Ok(usuariosCarrito);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpGet("{IdCarrito}")]
        public async Task<IActionResult> Get(int IdCarrito)
        {
            try
            {

                Carrito tipo = await _db.Carrito
                    .Include(p => p.Usuario)
                    .FirstOrDefaultAsync(x => x.IdCarrito == IdCarrito);

                if (tipo == null)
                {
                    return BadRequest();
                }

                return Ok(tipo);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }





        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CarritoUsuario carritoUsuario)
        {
            Carrito carrito2 = await _db.Carrito.FirstOrDefaultAsync(x => x.IdCarrito.Equals(carritoUsuario.IdCarrito));
            if (carrito2 == null && carritoUsuario != null)
            {
                var carrito = new Carrito
                {
                    UsuarioidUsuario = carritoUsuario.UsuarioidUsuario,
                    Fecha = carritoUsuario.Fecha,

                };
                await _db.Carrito.AddAsync(carrito);
                await _db.SaveChangesAsync();
                return Ok(carrito);
            }
            return BadRequest("El carrito ya existe");
        }

        [HttpDelete("{IdCarrito}")]
        public async Task<IActionResult> Delete(int IdCarrito)
        {
            Carrito carrito = await _db.Carrito.FirstOrDefaultAsync(x => x.IdCarrito == IdCarrito);
            if (carrito != null)
            {
                _db.Carrito.Remove(carrito);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }





        [HttpPost("GenerarCompra/")]
        public async Task<IActionResult> PostComprar([FromBody] int carritoIdCarrito)
        {
            Carrito carrito2 = await _db.Carrito.FirstOrDefaultAsync(x => x.IdCarrito == carritoIdCarrito);
            if (carrito2 != null)
            {
                var Compra = new Compra
                {
                    Fecha = carrito2.Fecha,
                    UsuarioidUsuario = carrito2.UsuarioidUsuario,

                };
                await _db.Compra.AddAsync(Compra);
                await _db.SaveChangesAsync();
                return Ok(Compra);

            }

            return BadRequest("No existe la intencion de compra");
        }




    }
}
