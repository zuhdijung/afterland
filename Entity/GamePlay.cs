using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class GamePlay
    {
        public string choiceNow { get; set; }
        public string varInput { get; set; }
        public List<string> triggerEvent { get; set; }
        public int ToleranceDown { get; set; } = -5;
        public int ToleranceUp { get; set; } = 5;
        public int TopLimit { get; set; } = 1000;
    }
}
