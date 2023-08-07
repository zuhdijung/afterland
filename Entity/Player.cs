using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class Player
    {
        public Player()
        {
            Item = new HashSet<PlayerItem>();
            PlayerSkill = new HashSet<Skill>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gold { get; set; }
        public int Experience { get; set; }
        public int Level { get; set; }
        public Attribute PlayerAttribute { get; set; }
        public virtual ICollection<PlayerItem> Item { get; set; }
        public virtual ICollection<Skill> PlayerSkill { get; set; }
    }
}
