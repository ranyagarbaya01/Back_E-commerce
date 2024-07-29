using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store.Data;
using store.Models;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeFamilleController : ControllerBase
    {
        private readonly storeContext dbcontext;

        public TypeFamilleController(storeContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet("types")]
        public async Task<IActionResult> GetType(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                var types = await dbcontext.Type.ToListAsync();
                return Ok(types);
            }
            else
            {
                var types = await dbcontext.Type
                    .Where(f => f.Name.Contains(search))
                    .ToListAsync();
                return Ok(types);
            }
        }

        [HttpGet("Famille")]
        public async Task<IActionResult> GetFamille(string? search)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                var families = await dbcontext.Famille.ToListAsync();
                return Ok(families);
            }
            else
            {
                var families = await dbcontext.Famille
                    .Where(f => f.Name.Contains(search))
                    .ToListAsync();
                return Ok(families);
            }
        }


        [HttpGet("types/{id:int}")]
        public ActionResult Gettypebyid(int id)
        {
            return Ok(dbcontext.Type.Single(p => p.Id == id));
        }

        [HttpGet("Famille/{id:int}")]
        public ActionResult GetFamillebyid(int id)
        {
            return Ok(dbcontext.Famille.Single(p => p.Id == id));
        }

        [HttpPost("types")]
        public async Task<ActionResult> Posttype(TypeDto obj) {
            var existingType = dbcontext.Type.SingleOrDefault(t => t.Name == obj.Name);

            if (existingType == null)
            {
              
                var newType = new store.Models.Type
                {
                    Name = obj.Name,
                  
                };

                dbcontext.Type.Add(newType);
                await dbcontext.SaveChangesAsync();

                return Ok(newType);
            }
            else
            {
                return Conflict(new { message = "Type exists." });
            }
        }

        [HttpPost("Famille")]
        public async Task<ActionResult> PostFamille(FamilleDto obj)
        {
            var existingFamille = dbcontext.Type.SingleOrDefault(f => f.Name == obj.Name);

            if (existingFamille == null)
            {

                var newFamille = new Famille
                {
                    Name = obj.Name,

                };

                dbcontext.Famille.Add(newFamille);
                await dbcontext.SaveChangesAsync();

                return Ok(newFamille);
            }
            else
            {
                return Conflict(new { message = "Famille exists." });
            }
        }

        [HttpPut]
        [Route("types/{id:int}")]
        public IActionResult UpdateType(int id, TypeDto obj)
        {
            try
            {
                var dbobj = dbcontext.Type.Single(t => t.Id == id);



                dbobj.Name = obj.Name;
               
                dbcontext.Type.Update(dbobj);
                dbcontext.SaveChanges();
                return Ok(dbobj);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("Famille/{id:int}")]
        public IActionResult UpdateFamille(int id, FamilleDto obj)
        {
            try
            {
                var dbobj = dbcontext.Famille.Single(f => f.Id == id);



                dbobj.Name = obj.Name;
               
                dbcontext.Famille.Update(dbobj);
                dbcontext.SaveChanges();
                return Ok(dbobj);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("types/{id:int}")]
        public IActionResult DeleteType(int id)
        {
            try
            {
                var dbobj = dbcontext.Type.Single(t => t.Id == id);
                dbcontext.Type.Remove(dbobj);
                dbcontext.SaveChanges();
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("Famille/{id:int}")]
        public IActionResult DeleteFamille(int id)
        {
            try
            {
                var dbobj = dbcontext.Famille.Single(f => f.Id == id);
                dbcontext.Famille.Remove(dbobj);
                dbcontext.SaveChanges();
                return Ok();
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }

    }

}
