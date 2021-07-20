using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Models;
using NMHD_DataAccess.Repositories;
using NMHD_DataAccess.ViewModels;
using System;
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
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(bool isParent)
        {
            var masterProds = await _context.Products.Where((p) => (isParent ? p.GeneralProductId == null : p.GeneralProductId != null)
                                                    && p.Active == true)
                                                .ToListAsync<Product>();
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

        [HttpPost]
        public async Task<int> AddProduct(Product product)
        {
            product.Active = true;
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Update(product);
            await _context.SaveChangesAsync();

            return product;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault((p) => p.Id == id && p.Active == true);
            if (product == null)
            {
                return BadRequest();
            }
            product.Active = false;
            _context.Update(product);
            await _context.SaveChangesAsync();

            return id;
        }
    }
}
