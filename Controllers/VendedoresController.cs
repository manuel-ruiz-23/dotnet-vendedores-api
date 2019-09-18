using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendedores.Models;

namespace Vendedores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        private readonly VendedoresContext _context;

        public VendedoresController(VendedoresContext context)
        {
            _context = context;

            if(_context.Vendedores.Count() == 0)
            {
                _context.Vendedores.Add(new Vendedor {Name = "Lalito"});
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedores()
        {
            return await _context.Vendedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedor(int id)
        {

            var vendedor = await _context.Vendedores
                .Include("Productos")
                .Where(s => s.VendedorId == id)
                .FirstOrDefaultAsync<Vendedor>();
                

            // var vendedor = await _context.Vendedores.FindAsync(id);

            if(vendedor == null)
            {
                return NotFound();
            }

            return vendedor;
        }

        [HttpPost]
        public async Task<ActionResult<Vendedor>> PostVendedor(Vendedor vendedor)
        {   
            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVendedor), new {id = vendedor.VendedorId}, vendedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendedor(int id, Vendedor vendedor)
        {
            if(id != vendedor.VendedorId)
            {
                return BadRequest();
            }

            _context.Entry(vendedor).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DelteteVendedor(int id)
        {
            var vendedor = await _context.Vendedores.FindAsync(id);
            
            if(vendedor == null)
            {
                return NotFound();
            }

            _context.Vendedores.Remove(vendedor);
            await _context.SaveChangesAsync();
            
            return NoContent();
        }

    }
}