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





        /*[HttpPut("{IdCarrito}")]
          public async Task<IActionResult> Put(int IdCarrito, [FromBody] CarritoUsuario carritoUsuario)
          {
              Carrito actualaModificar = await _db.Carrito.FirstOrDefaultAsync(x => x.IdCarrito == IdCarrito);
              var carritoqueyatengo = actualaModificar.IdCarrito;
              Prenda prendaquequieroponer = await _db.Prendas.FirstOrDefaultAsync(x => x.Nombre.Equals(prendaUsuario.Nombre));

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


        //nuevos 

            [HttpGet("PorUsuario/{UsuarioidUsuario}")]
            public async Task<IActionResult> GetListaCarrito(int UsuarioidUsuario)
            {
                try
                {
                List<Carrito> ListaCarrito = await _db.Carrito
                .Include(p => p.Usuario)
                .Where(x => x.UsuarioidUsuario == UsuarioidUsuario)
                .ToListAsync();

                return Ok(ListaCarrito);
            }
                catch (Exception ex)
                {
                    return BadRequest();
                }


            }
    }
}
