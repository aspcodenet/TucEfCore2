using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TucEfCore2.Data
{
    internal class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            _context.Database.Migrate();
            //SeedRoles();
            //SeedUsers();
            
            SeedProducts();
            //SeedAgreements();
            //SeedUserAgreements();
        }

        private void SeedProducts()
        {
            if (_context.Products.Any()) return;
            for (int i = 0; i < 10; i++)
            {
                _context.Products.Add(new Product { Name = "namn" + i.ToString() });
            }
            _context.SaveChanges();
        }
    }
}
