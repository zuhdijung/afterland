using Afterland.Entity;
using Afterland.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afterland.Scene
{
    public class Start
    {
        public static void startNewGame(Player currentPlayer, GamePlay gamePlay, CharacterName character)
        {
            string choice = "";
            Display.characterBuble(ConsoleColor.Red, "???", "Hello, there..");
            Display.characterBuble(ConsoleColor.Red, "???", "Do you know me? ofcourse not.");
            Display.characterBuble(ConsoleColor.Red, "???", $"Just call me {character.VoidName}");
            Display.characterBuble(ConsoleColor.Red, character.VoidName, "And who are you, Unknown Soldier?");
            Display.showChoice(ConsoleColor.Yellow, "???", "I remember nothing", "My name is ...", "", "", gamePlay);

            if (gamePlay.choiceNow == "A")
            {
                Display.characterBuble(ConsoleColor.Red, character.VoidName, "So you loss all memory", "How poor are you");
                Display.characterBuble(ConsoleColor.Red, character.VoidName, "Then, I just call you Unknown Soldier");
                currentPlayer.Name = "Unknown Soldier";
            }
            else if (gamePlay.choiceNow == "B")
            {
                Display.characterBuble(ConsoleColor.Red, character.VoidName, "What's your name?");
                Display.showInput("Input your name: ", gamePlay);
                currentPlayer.Name = gamePlay.varInput;
            }

            Display.characterBuble(ConsoleColor.Red, character.VoidName, $"Hey {currentPlayer.Name}, I have a good news and bad news", "What do you want to hear first?");

            Display.showChoice(ConsoleColor.Yellow, $"{currentPlayer.Name}", "Good News", "Bad News", "", "", gamePlay);

            while (!gamePlay.choiceNow.Equals("B"))
            {
                if (gamePlay.choiceNow.Equals("A"))
                {
                    Display.characterBuble(ConsoleColor.Red, character.VoidName, $"I'm Lied. There's no Good News. There's only Bad News");
                    gamePlay.choiceNow = "B";
                }
            }
            Display.characterBuble(ConsoleColor.Red, character.VoidName, $"The bad news is.. you're dead. Congratulation!");
            Display.characterBuble(ConsoleColor.Red, character.VoidName, $"Welcome to Afterland, {currentPlayer.Name}");

            // reset choice variable
            gamePlay.choiceNow = "";
        }

        public static void walkAtDesert(Player currentPlayer, GamePlay gamePlay, CharacterName character)
        {

            while (gamePlay.choiceNow != "B")
            {
                Display.characterBuble(ConsoleColor.Red, "", "You wake up");
                Display.characterBuble(ConsoleColor.Red, "", "In the middle dessert", "you stare to all the directions");
                Display.characterBuble(ConsoleColor.Red, "", "There's nothing but sand");
                Display.characterBuble(ConsoleColor.Red, "", "What do you want to do?");
                Display.showChoice(ConsoleColor.Yellow, currentPlayer.Name, "Wait here", "Going around", "", "", gamePlay);
            }

            Display.characterBuble(ConsoleColor.Red, "", "The crow just land to stone near you");
            Display.characterBuble(ConsoleColor.Red, "???", $"Hello there, {currentPlayer.Name}");
            Display.characterBuble(ConsoleColor.Red, "", "The bird just talk to you");
            Display.characterBuble(ConsoleColor.Yellow, currentPlayer.Name, $"!!!");
            Display.characterBuble(ConsoleColor.Red, character.VoidName, $"Don't be startled!", $"I am {character.VoidName}, Mr. {currentPlayer.Name}", "I'm just possesed to this Crow");
            Display.characterBuble(ConsoleColor.Red, character.VoidName, "Follow my lead");

            // reset choice variable
            gamePlay.choiceNow = "";

            Display.showChoice(ConsoleColor.Yellow, currentPlayer.Name, $"Follow {character.VoidName}", "Ignore. Just trust your instinct", "", "", gamePlay);

            if (gamePlay.choiceNow == "B")
            {
                Display.characterBuble(ConsoleColor.Red, "", "You just trust your instinct");
                Display.characterBuble(ConsoleColor.Red, "", "Unfortunately, there's big giant centipede monster in front of you");
                Display.characterBuble(ConsoleColor.Red, "", "What do you want?");

                // reset choice variable
                gamePlay.choiceNow = "";

                Display.showChoice(ConsoleColor.Yellow, currentPlayer.Name, $"Run!!!", "Fight!", "", "", gamePlay);

                if (gamePlay.choiceNow == "A")
                {
                    Display.characterBuble(ConsoleColor.Red, "", "You try to run");
                    Display.characterBuble(ConsoleColor.Red, "", "But you can't");
                    Display.characterBuble(ConsoleColor.Red, "", "You just die eaten alive by Centipede");
                }
                else if (gamePlay.choiceNow == "B")
                {
                    Enemy centipede = new Enemy()
                    {
                        Name = "Centipede",
                        Description = "Centipede monster. Live in Desert."
                    };
                    // give value to player attribute
                    currentPlayer = new Player()
                    {
                        Name = currentPlayer.Name,
                        Experience = currentPlayer.Experience,
                        Gold = currentPlayer.Gold,
                        Level = currentPlayer.Level,
                        PlayerAttribute = new Entity.Attribute()
                        {
                            Attack = 1,
                            Defense = 1,
                            Luck = 1,
                            HealthPower = 100,
                            MagicPower = 100,
                            Magic = 1,
                            MagicFire = 1,
                            MagicThunder = 1,
                            MagicWater = 1,
                            MagicWind = 1,
                            Speed = 1
                        }
                    };

                    // generate attribute monster
                    centipede = Generate.GenerateMonster(EnumMonsterLevel.Wolf, centipede);

                    // reset choice variable
                    gamePlay.choiceNow = "";

                    // BattlePhase
                    Display.BattlePhase(currentPlayer, centipede, gamePlay);
                }
            }
        }
    }
}
