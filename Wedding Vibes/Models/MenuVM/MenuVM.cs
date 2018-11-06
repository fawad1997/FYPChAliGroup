using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wedding_Vibes.Models.Menu;

namespace Wedding_Vibes.Models.MenuVM
{
    public class MenuVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<MenuItem> Items { get; set; }
        public double Price { get; set; }
    }
}
