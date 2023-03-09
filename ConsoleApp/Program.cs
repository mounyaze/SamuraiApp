

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
            
            AddSamurai();
            GetSamurais("After Add:"); 
            Console.Write("Press any key...");
            Console.ReadKey();
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
