using APIPROYECTO1.Data;
using APIPROYECTO1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIPROYECTO1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDBContext _db;

        public UsuarioController(ApplicationDBContext db)
        {
            _db = db;
        }

        // GET: TODA LA LISTA DE USUARIOS
        [HttpGet]
        public async Task<IActionResult> Get()//Se hace el método asincrono 
        {
            List<Usuario> usuarios = await _db.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        //GET SOLO ADMINISTADORES

        [HttpGet("admin")]
        public async Task<IActionResult> GetAdmin()
        {

            try
            {
                List<Usuario> usuarioAdmin = await _db.Usuarios
                    .Where(x => x.tipo == true)
                    .ToListAsync();

                return Ok(usuarioAdmin);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

        }




        // GET CADA USUARIO POR SU ID 
        [HttpGet("{IdUsuario}")]
        public async Task<IActionResult> Get(int IdUsuario)
        {
            Usuario usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == IdUsuario);
            if (usuario == null)
            {
                return BadRequest();
            }
            return Ok(usuario);
        }



        // POST CRAR USUARIOS EN GENARAL 
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == usuario.idUsuario);
            if (usuario2 == null && usuario != null)
            {
                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("El usuario ya existe");
        }
        

        //CREAR USUARIOS COMO ADMINISTRADOR O CLIENTE

        // POST CREAR SOLO ADMIN
        [HttpPost("admin")]
        public async Task<IActionResult> PostAdmin([FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == usuario.idUsuario);
            if (usuario2 == null && usuario != null)
            {

                usuario.tipo = true;
                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("El usuario ya existe");
        }


        // POST CREAR SOLO CLIENTES
        [HttpPost("cliente")]
        public async Task<IActionResult> PostClientes([FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == usuario.idUsuario);
            if (usuario2 == null && usuario != null)
            {

                usuario.tipo = false;
                await _db.Usuarios.AddAsync(usuario);
                await _db.SaveChangesAsync();
                return Ok(usuario);
            }
            return BadRequest("El usuario ya existe");
        }







        // EDITAR USUARIOS

        [HttpPut("{IdUsuario}")]
        public async Task<IActionResult> Put(int IdUsuario, [FromBody] Usuario usuario)
        {
            Usuario usuario2 = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == IdUsuario);
            if (usuario2 != null)
            {
                usuario2.usuario = usuario.usuario != null ? usuario.usuario : usuario2.usuario;
                usuario2.contrasena = usuario.contrasena != null ? usuario.contrasena : usuario2.contrasena;
                _db.Usuarios.Update(usuario2);
                await _db.SaveChangesAsync();
                return Ok(usuario2);
            }
            return BadRequest("El usuario no existe");
        }

        // D ELIMINAR USUARIOS
        [HttpDelete("{IdUsuario}")]
        public async Task<IActionResult> Delete(int IdUsuario)
        {
            Usuario usuario = await _db.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == IdUsuario);
            if (usuario != null)
            {
                _db.Usuarios.Remove(usuario);
                await _db.SaveChangesAsync();
                return NoContent();
            }
            return BadRequest();
        }


        // LOGIN ADMINISTRADORES

        [HttpGet("{usuario}/{contrasena}")] //admin
        public async Task<IActionResult> GetCredenciales(string usuario, string contrasena)
        {
            Usuario usuarios = await _db.Usuarios.FirstOrDefaultAsync(x => x.usuario.Equals(usuario) && x.contrasena.Equals(contrasena));
            if (usuarios == null)
            {
                return BadRequest();
            }
            else
            {
                if (usuarios.tipo == true)
                {
                    return Ok(usuarios);
                }
                else 
                {
                    return BadRequest();
                }
            }
        }

        // LOGIN CLIENTES

        [HttpGet("porcliente/{usuario}/{contrasena}")] //cliente
        public async Task<IActionResult> GetCredencialesCliente(string usuario, string contrasena)
        {
            Usuario usuarios = await _db.Usuarios.FirstOrDefaultAsync(x => x.usuario.Equals(usuario) && x.contrasena.Equals(contrasena));
            if (usuarios == null)
            {
                return BadRequest();
            }
            else
            {
                if (usuarios.tipo == false)
                {
                    return Ok(usuarios);
                }
                else
                {
                    return BadRequest();
                }
            }
        }

    }
}