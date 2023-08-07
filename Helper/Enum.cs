using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Helper
{
    public enum EnumAttributeEffect
    {
        Nothing,
        Health,
        Attack,
        Defense,
        Magic,
        Speed,
        Luck,
        MagicFire,
        MagicWater,
        MagicThunder,
        MagicWind
    }
    public enum EnumPlayerStatus
    {
        Nothing,
        Poison,
        Paralyzed,
        Sleep,
        Burn,
        Cold,
        Silence
    }
    public enum EnumMonsterElement
    {
        Water,
        Fly,
        Fire,
        Ice,
        Ground,
        Spirit,
        Leaf,
        Thunder
    }
    public enum EnumMonsterLevel
    {
        Bugs,
        Wolf,
        Lion,
        Demon,
        Dragon
    }
}
