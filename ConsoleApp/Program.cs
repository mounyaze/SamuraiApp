

using Microsoft.EntityFrameworkCore;
using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext _context = new SamuraiContext();

        private static void Main(string[] args)
        {

            // AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //QueryFilter();
            //RetrieveAndUpdateSamurai();
            RetrieveAndUpdateMultupleSamurais();

            
            Console.Write("Press any key...");
            Console.ReadKey();

        }

        private static void InsertMultipleSamurais()
        {
            var horse = new Horse { Name = "pferd" };
            var clan = new Clan { ClanName = "shi clan" };
            var samurai = new Samurai { Name = "Lekbedbed", Clan = clan, Horse = horse };
            var horse1 = new Horse { Name = "ein pferd" };
            var clan1 = new Clan { ClanName = "shi clan 3awd" };
            var samurai1 = new Samurai { Name = "Zbida", Clan = clan1, Horse = horse1 };
            var horse2 = new Horse { Name = "ein schon pferd" };
            var samurai2 = new Samurai { Name = "Hbiba", Clan = clan1, Horse = horse2 };
            var horse3 = new Horse { Name = "ein sehr schon pferd" };
            var samurai3 = new Samurai { Name = "Mama", Clan = clan1, Horse = horse2 };
            _context.AddRange(samurai, samurai1, samurai2, samurai3);
            _context.SaveChanges();
        }
        private static void AddSamurai()
        {
            var horse = new Horse { Name = "pferd" };
            var clan = new Clan { ClanName = "shi clan" };
            var samurai = new Samurai { Name = "Lekbedbed", Clan = clan, Horse = horse };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void GetSamuraisSimpler()
        {
            //var samurais = context.Samurais.ToList();
            var query = _context.Samurais;
            //var samurais = query.ToList();
            foreach (var samurai in query)
            {
                Console.WriteLine(samurai.Name);
            }
        }
        private static void GetSamurais(string text)
        {
            var samurais = _context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
        private static void QueryFilter()
        {
            var name = "Lekbedbed";
            //var samurais = _context.Samurais.FirstOrDefault(s => s.Name==name);
            //var samurais = _context.Samurais.Find(2);
            //var filter = "J%";
            //var samurais = _context.Samurais.Where(s => EF.Functions.Like(s.Name, filter));
            var last = _context.Samurais.OrderBy(s => s.Id).LastOrDefault(s => s.Name == name);
        }

        private static void RetrieveAndUpdateSamurai ()
        {
            var horse = new Horse { Name = "aserdun" };
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += "richard";
            samurai.Horse = horse;

            _context.SaveChanges();
        }
        private static void RetrieveAndUpdateMultupleSamurais()
        {
            //var samurais = _context.Samurais.Skip(1).Take(7).ToList();
            //samurais.ForEach(s => s.Name += " san");
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Name += " sama";
            var clan = new Clan { ClanName = "shi clan 3awd" };
            var horse = new Horse { Name = "horsu" };
            _context.Samurais.Add(new Samurai { Name = "Kikuchiyo", Clan= clan , Horse=horse});
            _context.SaveChanges();
        }
    }
}
