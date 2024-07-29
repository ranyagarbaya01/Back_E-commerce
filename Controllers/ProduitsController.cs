using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using store.Data;
using store.Models;

namespace store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduitController : ControllerBase
    {
        private readonly storeContext dbcontext;
        public ProduitController(storeContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ShopParams shopParams)
        {
            var query = dbcontext.Produit.AsQueryable();

            if (shopParams.BrandId > 0)
                query = query.Where(p => p.FamilleId == shopParams.BrandId);

            if (shopParams.TypeId >= 0)
                query = query.Where(p => p.TypeId == shopParams.TypeId);

            if (!string.IsNullOrEmpty(shopParams.Search))
                query = query.Where(p => p.Name.Contains(shopParams.Search) || p.Description.Contains(shopParams.Search));

            switch (shopParams.Sort)
            {
                case "priceAsc":
                    query = query.OrderBy(p => p.PrixTTC);
                    break;
                case "priceDesc":
                    query = query.OrderByDescending(p => p.PrixTTC);
                    break;
                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            var count = await query.CountAsync();

            var products = await query
                .Skip((shopParams.PageNumber - 1) * shopParams.PageSize)
                .Take(shopParams.PageSize)
                .ToListAsync();

            // Set the ImageUrl for each product
            foreach (var product in products)
            {
                product.ImageUrl = Url.Action("GetProductImage", new { id = product.Id });
            }

            var pagination = new Pagination<Produit>
            {
                PageIndex = shopParams.PageNumber,
                PageSize = shopParams.PageSize,
                Count = count,
                Data = products
            };

            return Ok(pagination);
        }

        [HttpGet("{id}/image")]
        public IActionResult GetProductImage(int id)
        {
            var product = dbcontext.Produit.Find(id);

            if (product == null || product.image == null)
            {
                return NotFound();
            }

            return File(product.image, "image/jpeg");
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetallProduct(string? serch)
        { if (serch == null)
            {
                var products = await dbcontext.Produit
                .Include(p => p.Famille)
                .Include(p => p.Type).ToListAsync();

                return Ok(products);
            }
            else {
                var products = await dbcontext.Produit
                .Include(p => p.Famille)
                    .Include(p => p.Type).Where(p => p.Name.Contains( serch) )
                    .ToListAsync();

                return Ok(products);
            }
            
        }


        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            var dbobj = dbcontext.Produit.Single(p => p.Id == id);
            return Ok(dbobj);
        }


        [HttpPost]
        public async Task<IActionResult> AddItem([FromForm] ProduitDto obj)
        {
            var existingProduct = dbcontext.Produit.SingleOrDefault(p => p.Name == obj.Name);

            if (existingProduct == null)
            {
                byte[]? imageBytes = null;
                if (obj.imageFile != null && obj.imageFile.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        await obj.imageFile.CopyToAsync(ms);
                        imageBytes = ms.ToArray();
                    }
                }

                var newProduct = new Produit
                {
                    Name = obj.Name,
                    Description = obj.Description,
                    PrixHT = obj.PrixHT,
                    PrixTTC = obj.PrixTTC,
                    TVA = obj.TVA,
                    FamilleId = obj.FamilleId,
                    image = imageBytes,
                    TypeId = obj.TypeId
                };

                dbcontext.Produit.Add(newProduct);
                await dbcontext.SaveChangesAsync();

                return Ok(newProduct);
            }
            else
            {
                return Conflict(new { message = "Product exists." });
            }
        }


        //[HttpPut]
        //[Route("{id:int}")]
        //public IActionResult Update(int id, ProduitDto obj)
        //{
        //    try
        //    {
        //        var dbobj = dbcontext.Produit.Single(p => p.Id == id);



        //        dbobj.Name = obj.Name;
        //        dbobj.Description = obj.Description;
        //        dbobj.Prix = obj.Prix;
        //        dbobj.FamilleId = obj.FamilleId;
        //        dbobj.TypeId = obj.TypeId;
        //        dbcontext.Produit.Update(dbobj);
        //        dbcontext.SaveChanges();
        //        return Ok(dbobj);
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        return NotFound();
        //    }
        //}


        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var dbobj = dbcontext.Produit.Single(p => p.Id == id);
                dbcontext.Produit.Remove(dbobj);
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
