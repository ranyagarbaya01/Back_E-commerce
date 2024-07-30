using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Data;
using store.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandesController : ControllerBase
    {

        private readonly storeContext _context;

        public CommandesController(storeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Commande>>> GetCommandes()
        {
            return await _context.Commande.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Commande>> GetCommande(int id)
        {
            var commande = await _context.Commande
                .FirstOrDefaultAsync(b => b.Id == id);

            if (commande == null)
            {
                return NotFound();
            }

            return commande;
        }


        [HttpPost]
        public async Task<ActionResult<Commande>> CreateCommande(Commande commande)
        {
            _context.Commande.Add(commande);
            await _context.SaveChangesAsync();
            return Ok(commande);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommande(int id, Commande updatedCommande)
        {
            if (id != updatedCommande.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedCommande).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommandeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommande(int id)
        {
            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }

            _context.Commande.Remove(commande);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.Id == id);
        }
    }
}
