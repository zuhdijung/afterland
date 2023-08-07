using Afterland.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class Enemy
    {
        public Enemy()
        {
            Item = new HashSet<PlayerItem>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public EnumMonsterElement Element { get; set; }
        public EnumMonsterLevel Level { get; set; }
        public Attribute? MonsterAttribute { get; set; }
        public virtual ICollection<PlayerItem> Item { get; set; }
    }
}
