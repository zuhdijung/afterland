using Afterland.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool? IsIncrease { get; set; }
        public bool? IsDecrease { get; set; }
        public EnumAttributeEffect? AttributeEffect { get; set; }
        public EnumPlayerStatus? PlayerStatus { get; set; }
    }
}
