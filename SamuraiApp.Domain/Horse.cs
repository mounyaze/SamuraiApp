using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamuraiApp.Domain
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("SamuraiId")]
        public int SamuraiId { get; set; }

    }
}
