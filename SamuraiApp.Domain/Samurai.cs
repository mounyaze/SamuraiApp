﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Samurai
    {
        public Samurai() 
        {
            Quotes = new List<Quote>();
            SamuraiBattles = new List<SamuraiBattle>();   
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Quote> Quotes { get; set; }

        public  Clan Clan { get; set; } 
        public List<SamuraiBattle> SamuraiBattles { get; set; }
        public Horse Horse { get; set; }
    }
} 
