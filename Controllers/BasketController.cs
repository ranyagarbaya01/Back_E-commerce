using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Models;
using store.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly storeContext _context;

        public BasketController(storeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerBasket>>> GetBaskets()
        {
            return await _context.CustomerBasket.Include(b => b.Items)
.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerBasket>> GetBasket(string id)
        {
            var basket = await _context.CustomerBasket
                .Include(b => b.Items)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basket == null)
            {
                return NotFound();
            }

            return basket;
        }

        [HttpPost]
        public async Task<ActionResult<CustomerBasket>> CreateBasket(CustomerBasket basket)
        {
            _context.CustomerBasket.Add(basket);
            await _context.SaveChangesAsync();

            return Ok(basket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBasket(string id, CustomerBasket updatedBasket)
        {
            if (id != updatedBasket.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedBasket).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
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
        public async Task<IActionResult> DeleteBasket(string id)
        {
            var basket = await _context.CustomerBasket.FindAsync(id);
            if (basket == null)
            {
                return NotFound();
            }

            _context.CustomerBasket.Remove(basket);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BasketExists(string id)
        {
            return _context.CustomerBasket.Any(e => e.Id == id);
        }
    }
}
