using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Models;
using NMHD_DataAccess.Repositories;
using NMHD_DataAccess.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NuocMamHongDuc_Web_App.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NMHDDbContext _context;
        public ProductController(NMHDDbContext context)
        {
            _context = context;
        }

        // [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts([FromQuery] bool isParent, [FromQuery] String sku, [FromQuery] String tag,
                                                                                [FromQuery] int id = -1)
        {
            var masterProds =  _context.Products.Where((p) => (isParent ? p.GeneralProductId == null : p.GeneralProductId != null)
                                                    && p.Active == true)
                                                .Include((p) => p.GeneralProduct)
                                                .AsQueryable();
                                                
            if(id != -1)
            {
                masterProds = masterProds.Where((p) => p.Id== id);
            }
            if(sku != null)
            {
                masterProds = masterProds.Where((p) => p.SKU == sku);
            }

            if(tag != null)
            {
                masterProds = masterProds.Where((p) => p.Tags.Contains(tag));
            }

                
            var resProds = new List<ProductDTO>();
            foreach (var masterProd in masterProds)
            {
                var childProd = _context.Products.Where((p) => p.GeneralProductId == masterProd.Id && p.Active == true)
                                                 .ToList();
                var resP = new ProductDTO(masterProd);
                resP.ChildProducts = childProd;
                resProds.Add(resP);
            }
            return Ok(resProds);
        }

        [Authorize]
        [HttpPost]
        public async Task<int> AddProduct(Product product)
        {
            product.Active = true;
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = _context.Products.FirstOrDefault((p) => p.Id == id && p.Active == true);
            if (product == null)
            {
                return NotFound();
            }


            return Ok(product);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            product.Active = true;

            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault((p) => p.Id == id && p.Active == true);
            if (product == null)
            {
                return BadRequest();
            }
            List<Product> childProd;
            if (product.GeneralProductId == null)
            {
                childProd = await _context.Products.Where((p) => p.GeneralProductId == product.Id && p.Active == true)
                    .ToListAsync();
                foreach (var child in childProd)
                {
                    child.Active = false;
                }
            }

            product.Active = false;
            _context.Update(product);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
