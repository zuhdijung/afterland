using Afterland.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Helper
{
    public class Generate
    {
        public static Enemy GenerateMonster(EnumMonsterLevel level, Enemy enemy)
        {
            Random random = new Random();
            switch (level)
            {   
                case EnumMonsterLevel.Bugs:
                    enemy.MonsterAttribute = new Entity.Attribute
                    {
                        Attack = random.Next(3,15),
                        Defense = random.Next(5,10),
                        HealthPower = random.Next(50,120),
                        MagicPower = random.Next(50,120),
                        Speed = random.Next(3, 15),
                        Luck = random.Next(2,10),
                        Magic = random.Next(2,5),
                        MagicFire = random.Next(2,5),
                        MagicThunder = random.Next(2,5),
                        MagicWater = random.Next(2, 5),
                        MagicWind = random.Next(2,5)
                    };
                    break;
                case EnumMonsterLevel.Wolf:
                    enemy.MonsterAttribute = new Entity.Attribute
                    {
                        Attack = random.Next(16, 30),
                        Defense = random.Next(11, 20),
                        HealthPower = random.Next(121, 240),
                        MagicPower = random.Next(121, 240),
                        Speed = random.Next(16, 30),
                        Luck = random.Next(11, 20),
                        Magic = random.Next(6, 10),
                        MagicFire = random.Next(6, 10),
                        MagicThunder = random.Next(6, 10),
                        MagicWater = random.Next(6, 10),
                        MagicWind = random.Next(6, 10)
                    };
                    break;
                default: break;
            }
            return enemy;
        }
        public static int GenerateRandomAttribute(int attribute, GamePlay gamePlay)
        {
            Random random = new Random();
            int randomAttribute = attribute + ((random.Next(gamePlay.ToleranceDown, gamePlay.ToleranceUp)));
            return randomAttribute;
        }
        public static int GenerateGold(int initGold, GamePlay gamePlay, Player player)
        {
            Random random = new Random();
            int randomGold = initGold + (random.Next(gamePlay.ToleranceDown, gamePlay.ToleranceUp));
            if (random.Next(gamePlay.TopLimit - player.PlayerAttribute.Luck) == random.Next(gamePlay.TopLimit - player.PlayerAttribute.Luck))
                randomGold *= 2;

            return randomGold;
        }
    }
}
