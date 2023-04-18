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
            //SeedProducts();
            //SeedAgreements();
            //SeedUserAgreements();
        }
    }
}
