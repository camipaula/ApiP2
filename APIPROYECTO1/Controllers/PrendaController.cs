using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrendaController : ControllerBase
    {
        private readonly ApplicationDBContext _db; //cuando se pone guion bajo es porque es solo de lectura solo notacion

        public PrendaController(ApplicationDBContext db)
        {
            _db = db;
        }
        // GET: api/<ColorProducto>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                List<Prenda> productos = await _db.Prendas
                    .Include(p => p.Marca)  
                    .Include(p => p.Categoria)
                    .ToListAsync();

                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

       
        }

        [HttpGet("{IdPrenda}")]
        public async Task<IActionResult> Get(int IdPrenda)
        {
            try
            {
                // Incluye la información del TipoProducto en la consulta
                Prenda tipo = await _db.Prendas
                    .Include(p => p.Marca)
                    .Include(p => p.Categoria)
                    .FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);

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
        public async Task<IActionResult> Post([FromBody] PrendaUsuario prendaUsuario)
        {
            Prenda prenda2 = await _db.Prendas.FirstOrDefaultAsync(x => x.Nombre.Equals(prendaUsuario.Nombre));
            if (prenda2 == null && prendaUsuario != null)
            {
                var prenda = new Prenda
                {
                    Nombre = prendaUsuario.Nombre,
                    Descripcion = prendaUsuario.Descripcion,
                    CategoriaIdCategoria = prendaUsuario.CategoriaIdCategoria,
                    MarcaIdMarca = prendaUsuario.MarcaIdMarca,
                    Precio = prendaUsuario.Precio,
                    Cantidad = prendaUsuario.Cantidad

                };
                await _db.Prendas.AddAsync(prenda);
                await _db.SaveChangesAsync();
                return Ok(prenda);
            }
            return BadRequest("La prenda ya existe");
        }

        [HttpPut("{IdPrenda}")]
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
        }

        [HttpDelete("{IdPrenda}")]
        public async Task<IActionResult> Delete(int IdPrenda)
        {
            Prenda prenda = await _db.Prendas.FirstOrDefaultAsync(x => x.IdPrenda == IdPrenda);
            if (prenda != null)
            {
                _db.Prendas.Remove(prenda);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }
        //metodos nuevos
        // calcular el precio total 
       

    }
}
