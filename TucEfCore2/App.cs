using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TucEfCore2.Data;

namespace TucEfCore2
{
    public class App
    {
        private readonly ApplicationDbContext _context;

        public App(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Run()
        {
            while (true)
            {
                Console.WriteLine("1. Lista alla");
                Console.WriteLine("11. Sök");
                Console.WriteLine("2. Skapa");
                Console.WriteLine("3. Uppdatera");
                Console.WriteLine("4. Avsluta");
                var action = Console.ReadLine();
                if (action == "1") ListAll();
                if (action == "11") Search();
                if (action == "2") Create();
                if (action == "3") Update();
                if (action == "4") break;

            }
        }

        private void Update()
        {
            Console.WriteLine("Uppdatera");
            Console.WriteLine("Ange id:");
            var id = Convert.ToInt32(Console.ReadLine());

            var p = _context.Products.FirstOrDefault(p => p.Id == id);

            Console.WriteLine($"Ange nytt namn för {p.Name}:");
            var namn = Console.ReadLine();
            p.Name = namn;
            _context.SaveChanges();
        }

        private void Create()
        {
            Console.WriteLine("Skapa ny");
            Console.WriteLine("Ange namn:");
            var namn = Console.ReadLine();
            var p = new Product();
            p.Name = namn;
            _context.Products.Add(p);
            _context.SaveChanges();

        }

        private void ListAll()
        {
            Console.WriteLine("Lista alla");
            foreach (var p in _context.Products)
            {
                Console.WriteLine($"{p.Id} {p.Name}");
            }
        }

        private void Search()
        {
            Console.WriteLine("Sök efter namn:");
            var namn = Console.ReadLine();
            foreach (var p in _context.Products.Where(e=>e.Name.Contains(namn)))
            {
                Console.WriteLine($"{p.Id} {p.Name}");
            }
        }

    }
}
