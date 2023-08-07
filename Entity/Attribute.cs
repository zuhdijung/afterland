using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class Attribute
    {
        public int Id { get; set; }
        public int HealthPower { get; set; } = 100;
        public int MagicPower { get; set; } = 100;
        public int Attack { get; set; } = 1;
        public int Defense { get; set; } = 1;
        public int Magic { get; set; } = 1;
        public int Speed { get; set; } = 1;
        public int Luck { get; set; } = 1;
        public int MagicFire { get; set; } = 1;
        public int MagicWater { get; set; } = 1;
        public int MagicThunder { get; set; } = 1;
        public int MagicWind { get; set; } = 1;
    }
}
