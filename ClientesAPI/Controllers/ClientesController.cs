using ClientesAPI.Data;
using ClientesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ClientesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<ClientesController>
        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByCliente(int id)
        {
            var cliente = _context.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> GuardarCliente([FromBody] Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cliente guardado con exito" });
        }

        // PUT api/<ClientesController>/5
        [HttpPut]
        public async Task<IActionResult> ActualizarCliente([FromBody] Clientes clientes)
        {
            var cliente = await _context.Clientes.FindAsync(clientes.ClienteID);
            
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Nombre = clientes.Nombre;
            cliente.Apellido = clientes.Apellido;
            cliente.Email = clientes.Email;
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cliente actualizado con exito" });
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Cliente eliminado con exito" });
        }
    }
}
