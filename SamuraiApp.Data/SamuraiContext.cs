using Microsoft.EntityFrameworkCore;
using SamuraiApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Data
{
    internal class SamuraiContext : DbContext
    {
        DbSet<Samurai> Samurais { get; set; }

    }
}
