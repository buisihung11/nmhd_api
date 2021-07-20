using Microsoft.EntityFrameworkCore;
using NMHD_DataAccess.Models;
using NMHD_DataAccess.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMHD_DataAccess.Repositories
{
    public class ProductRepository
    {
        private readonly NMHDDbContext _context;

        public ProductRepository(NMHDDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts() =>
            _context.Products.ToList();

        public Task<List<ProductDTO>> GetProductsAsync(bool isParent)
        {
            var masterProds = _context.Products.Where((p) => isParent ? p.GeneralProductId == null : p.GeneralProductId != null)
                                                .ToList<Product>();
            var resProds = new List<ProductDTO>();
            foreach (var masterProd in masterProds)
            {
                var childProd = _context.Products.Where((p) => p.GeneralProductId == masterProd.Id)
                                                 .ToList();
                var resP = new ProductDTO(masterProd);
                resP.ChildProducts = childProd;
                resProds.Add(resP);
            }
            return Task.FromResult(resProds);
        }
        public async Task<int> AddProductAsync(Product product)
        {
            _context.Products.Add(product);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var updateProd = await _context.Products.FindAsync(product.Id);
            
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected;
        }
    }
}
