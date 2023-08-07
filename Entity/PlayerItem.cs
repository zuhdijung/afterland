using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Entity
{
    public class PlayerItem
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int? PlayerId { get; set; }
        public int? EnemyId { get; set; }
        public int Qty { get; set; }
        public int? Durability { get; set; }
    }
}
