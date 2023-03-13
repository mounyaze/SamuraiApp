

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


            //AddSamurai();
            //GetSamurais("After Add:");
            //InsertMultipleSamurais();
            //QueryFilter();
            //RetrieveAndUpdateSamurai();
            //RetrieveAndUpdateMultupleSamurais();
            //RetrieveAndDeleteASamurai();
            //InsertBattle();
            //QueryAndUpdateBattle_Disconnected();
            //InsertNewSamuraiWithQuotes();
            //InsertSamuraiWithManyQuotes();
            //AddQuoteToExistingSamuraiWhileTracked();
            //AddQuoteToExistingSamuraiNotTracked(8);
            //EagerLoadSamuraiWithQuotes();
            //ProjectSomeProperties();
            //ProjectSamuraisWithQuotes();
            FilteringWithRelatedData();

            

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
        private static void RetrieveAndDeleteASamurai()
        {
            var samurai = _context.Samurais.Find(2);
            
            _context.Samurais.Remove(samurai);
            _context.SaveChanges();
        }
        private static void InsertBattle()
        {
            _context.Battles.Add(new Battle
            {
                Name = "Battle of PFE",
                StatDate = new DateTime(2023, 03, 01),
                EndDate = new DateTime(2023, 07, 31)
            });
            _context.SaveChanges();
        }
        private static void QueryAndUpdateBattle_Disconnected()
        
        { 
            var battle = _context.Battles.AsNoTracking().FirstOrDefault();
            battle.EndDate = new DateTime(2024, 05, 12);
            using (var newContextInstance = new SamuraiContext())
            {
                newContextInstance.Battles.Update(battle);
                newContextInstance.SaveChanges();
            }
        }
        private static void InsertNewSamuraiWithQuotes()
        {
            var clan = new Clan { ClanName = "konoha" };
            var horse = new Horse { Name = "kurama" };
            var samurai = new Samurai
            {
                Name = "Mounya Zekraoui",
                Clan = clan,
                Horse = horse,
                Quotes= new List<Quote> { 
                    new Quote {Text="Nari u nsheddek naklek"} 
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();
        }
        private static void InsertSamuraiWithManyQuotes()
        {
            var clan = new Clan { ClanName = "bahuba" };
            var horse = new Horse { Name = "cherry" };
            var samurai = new Samurai
            {
                Name = "Hafsa Mehdioui",
                Clan = clan,
                Horse = horse,
                Quotes = new List<Quote> {
                    new Quote {Text="yal medlula"},
                    new Quote {Text="narii mounya crushi galiya salam"}
                }
            };
            _context.Samurais.Add(samurai);
            _context.SaveChanges();

        }
        private static void AddQuoteToExistingSamuraiWhileTracked()
        {
            var samurai = _context.Samurais.FirstOrDefault();
            samurai.Quotes.Add(new Quote { Text = "hey there please keep me !!" });
            _context.SaveChanges();
        }
        private static void AddQuoteToExistingSamuraiNotTracked(int samuraiId)
        {
            var samurai = _context.Samurais.Find(samuraiId);
            samurai.Quotes.Add(new Quote
            {
                Text = "Now that i saved, you will feed me dinner ?",
                SamuraiId = samuraiId
            });
            using (var newContext = new SamuraiContext()) 
            {
                newContext.Samurais.Update(samurai);
                //newContext.Samurais.Attach(samurai);
                newContext.SaveChanges();
            }
        }
        private static void EagerLoadSamuraiWithQuotes()
        { 
            var samuraiQuotes = _context.Samurais.Where(s=> s.Name.Contains("Lekbedbed"))
                                                 .Include(s => s.Quotes).ToList();
        }
        private static void ProjectSomeProperties()
        {
            var someproperties = _context.Samurais.Select(s=> new { s.Id, s.Name}).ToList();
            var idsAndNames = _context.Samurais.Select(s => new IdAndName(s.Id, s.Name)).ToList();
        }
        private struct IdAndName 
        {
            public IdAndName(int id, string name)
            { 
                Id = id;
                Name= name;

            }
            public int Id;
            public string Name;
        }
        private static void  ProjectSamuraisWithQuotes()
        {
            //var somePropertiesWithQuotes = _context.Samurais.Select(s => new { s.Id, s.Name, s.Quotes.Count })
            //                                                .ToList();


            /* var somePropertiesWithQuotes = _context.Samurais
                 .Select(s => new { s.Id, s.Name, HappyQuotes = s.Quotes.Where(q => q.Text.Contains("nakelek"))})
                .ToList();
             var sam = _context.Samurais.Find(somePropertiesWithQuotes[0].Id);
             sam.Name += " MONSTER";*/



            var samuraiWithHappyQuotes = _context.Samurais
                 .Select( s => new {
                     Samurai = s,
                     HappyQuotes = s.Quotes.Where(q => q.Text.Contains("yal") )
                     
                 })
                  .ToList();
            samuraiWithHappyQuotes.Reverse();
           
            foreach (var i in samuraiWithHappyQuotes)
            {
                Console.WriteLine(i.Samurai.Name);
                Console.WriteLine(" ");
                foreach (var j in i.HappyQuotes)
                {
                    Console.WriteLine(j.Text);
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }




            //var firstsamurai = samuraiWithHappyQuotes[0].samurai.Name += " the most medlula";
            

        }
        private static void ExplicitLoadQuotes()
        {
             var samurai = _context.Samurais.FirstOrDefault(s => s.Name.Contains("Mounya"));
            _context.Entry(samurai).Collection(s => s.Quotes).Load();
            _context.Entry(samurai).Reference(s => s.Horse).Load();
            

        }
        private static void FilteringWithRelatedData()
        {

            var samuraiWithHappyQuotes = _context.Samurais
                 .Where(s => s.Quotes.Any(q => q.Text.Contains("naklek")))
                 .Select(s => new {
                     samurai = s,
                     HappyQuotes = s.Quotes.Where(q => q.Text.Contains("naklek"))})
                  .ToList();

            //var samurais = _context.Samurais
              //       .Where(s => s.Quotes.Any(q => q.Text.Contains("naklek")))
                //     .ToList();
            foreach (var i in samuraiWithHappyQuotes)
            {
                Console.WriteLine(i.samurai.Name);
                Console.WriteLine(" ");
                foreach (var j in i.HappyQuotes)
                {
                    Console.WriteLine(j.Text);
                }
                Console.WriteLine(" ");
                Console.WriteLine(" ");
            }

        }
    }
}
 