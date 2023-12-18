using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public CompraController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<Compra> comprai = await _db.Compra
                    .Include(p => p.Usuario)

                    .ToListAsync();

                return Ok(comprai);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }


        }

        [HttpGet("{IdCompra}")]
        public async Task<IActionResult> Get(int IdCompra)
        {
            try
            {

                Compra tipo = await _db.Compra
                .Include(p => p.Usuario)

                .FirstOrDefaultAsync(x => x.IdCompra == IdCompra);

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
        public async Task<IActionResult> Post([FromBody] CompraUsuario compraUsuario)
        {
            Compra compra2 = await _db.Compra.FirstOrDefaultAsync(x => x.IdCompra.Equals(compraUsuario.IdCompraUsuario));
            if (compra2 == null && compraUsuario != null)
            {
                var compra = new Compra
                {
                    UsuarioidUsuario = compraUsuario.UsuarioidUsuario,
                    Fecha = compraUsuario.Fecha,

                };
                await _db.Compra.AddAsync(compra);
                await _db.SaveChangesAsync();
                return Ok(compra);
            }
            return BadRequest("La compra ya existe");
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

        [HttpDelete("{IdCompra}")]
        public async Task<IActionResult> Delete(int IdCompra)
        {
            Compra compra = await _db.Compra.FirstOrDefaultAsync(x => x.IdCompra == IdCompra);
            if (compra != null)
            {
                _db.Compra.Remove(compra);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }


        [HttpGet("PorCliente/{UsuarioIdUsuario}")]
        public async Task<IActionResult> GetListaIntencionCompra(int UsuarioIdUsuario)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<Compra> compras = await _db.Compra
                    .Include(p => p.Usuario)  // Incluir la propiedad de navegación TipoProducto
                    .Where(x => x.UsuarioidUsuario == UsuarioIdUsuario)
                    .ToListAsync();

                if (compras == null || compras.Count == 0)
                {
                    return NotFound(); // Cambiado a NotFound cuando no se encuentran resultados
                }

                return Ok(compras);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



        }


        [HttpGet("TotalCompra/{CompraIdCompra}")]
        public async Task<IActionResult> GetTotalPrecioC(int CompraIdCompra)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<DetalleCompra> descripciones = await _db.DetalleCompra
                    .Include(pcl => pcl.Compra)
                    .Include(pct => pct.Prenda)
                    .Where(x => x.CompraIdCompra == CompraIdCompra)
                    .ToListAsync();
                if (descripciones.Count != 0 || descripciones != null)
                {
                    double totalPrecio = 0.0;

                    foreach (var descripcion in descripciones)
                    {

                        totalPrecio += descripcion.PrecioTotal;
                    }


                    return Ok(totalPrecio);

                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return BadRequest();
            }




        }
    }

}