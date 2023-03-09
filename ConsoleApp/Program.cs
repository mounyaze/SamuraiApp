

using SamuraiApp.Data;
using SamuraiApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            
           // AddSamurai();
            //GetSamurais("After Add:");
            InsertMultipleSamurais();
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
            context.AddRange(samurai, samurai1,samurai2,samurai3);
            context.SaveChanges();
        }
        private static void AddSamurai()
        {
            var horse = new Horse { Name = "pferd" };
            var clan = new Clan { ClanName = "shi clan" };
            var samurai = new Samurai { Name = "Lekbedbed" , Clan = clan, Horse=horse};
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
