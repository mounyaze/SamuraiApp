﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Battle
    {
        public Battle()
        {
            samuraiBattles = new List<SamuraiBattle>();
        }        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<SamuraiBattle> samuraiBattles { get; set; }
    }
}
