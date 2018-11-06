using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Wedding_Vibes.Models.Menu
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 100), Display(Name = "Menu Name"), Required]
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
        public ICollection<MenuItem> MenuItems { get; set; }
    }
}
