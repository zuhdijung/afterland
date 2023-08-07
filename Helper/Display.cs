using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Afterland.Entity;

namespace Afterland.Helper
{
    public class Display
    {
        public static void drawLine()
        {
            Console.WriteLine("[]================================================================================[]");
        }
        public static void characterBuble(ConsoleColor textColor = ConsoleColor.White, string characterName = "Unknown", string message = "", string message2 = "", string message3 = "")
        {
            drawLine();
            Console.ForegroundColor = textColor;
            Console.WriteLine($"   {characterName}");

            // set text color to white again
            Console.ForegroundColor = ConsoleColor.White;

            // write message. first message is mandatory
            Console.WriteLine($"   {message}");
            if (message2 != "")
                Console.WriteLine($"   {message2}");
            if (message3 != "")
                Console.WriteLine($"   {message3}");
            drawLine();
            Console.Write("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void characterBubleNoClear(ConsoleColor textColor = ConsoleColor.White, string characterName = "Unknown", string message = "", string message2 = "", string message3 = "")
        {
            drawLine();
            Console.ForegroundColor = textColor;
            Console.WriteLine($"   {characterName}");

            // set text color to white again
            Console.ForegroundColor = ConsoleColor.White;

            // write message. first message is mandatory
            Console.WriteLine($"   {message}");
            if (message2 != "")
                Console.WriteLine($"   {message2}");
            if (message3 != "")
                Console.WriteLine($"   {message3}");
            drawLine();
        }
        public static void showChoice(ConsoleColor textColor = ConsoleColor.White, string characterName = "", string optionA = "", string optionB = "", string optionC = "", string optionD = "", GamePlay gamePlay = null)
        {
            GamePlay gp = new GamePlay() { choiceNow = "" };

            drawLine();
            Console.ForegroundColor = textColor;
            Console.WriteLine($"   {characterName}");
            // set text color to white again
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"   A : {optionA}");
            if (optionB != "") Console.WriteLine($"   B : {optionB}");
            if (optionC != "") Console.WriteLine($"   C : {optionC}");
            if (optionD != "") Console.WriteLine($"   D : {optionD}");

            if (optionB == "")
            {
                while (gp.choiceNow != "A")
                {
                    Console.Write("   Your Choice [A]: ");
                    gp.choiceNow = Console.ReadLine();
                }
            }
            else if (optionC == "")
            {
                while (gp.choiceNow != "A" && gp.choiceNow != "B")
                {
                    Console.Write("   Your Choice [A/B]: ");
                    gp.choiceNow = Console.ReadLine();
                }
            }
            else if (optionD == "")
            {
                while (gp.choiceNow != "A" && gp.choiceNow != "B" && gp.choiceNow != "C")
                {
                    Console.Write("   Your Choice [A/B/C]: ");
                    gp.choiceNow = Console.ReadLine();
                }
            }
            else if (optionD != "")
            {
                while (gp.choiceNow != "A" && gp.choiceNow != "B" && gp.choiceNow != "C" && gp.choiceNow != "D")
                {
                    Console.Write("   Your Choice [A/B/C/D]: ");
                    gp.choiceNow = Console.ReadLine();
                }
            }
            drawLine();
            gamePlay.choiceNow = gp.choiceNow;
            Console.Write("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void showChoiceMany(ConsoleColor textColor = ConsoleColor.White, string characterName = "", List<string> choices = null, GamePlay gamePlay = null)
        {
            GamePlay gp = new GamePlay() { choiceNow = "1" };

            drawLine();
            Console.ForegroundColor = textColor;
            Console.WriteLine($"   {characterName}");
            // set text color to white again
            Console.ForegroundColor = ConsoleColor.White;
            char choice = 'A';
            List<char> choiceOption = new List<char>();

            foreach (var item in choices)
            {
                Console.WriteLine($"   {choice} : {item}");
                choiceOption.Add(choice);
                choice++;
            }

            while (!choiceOption.Contains(gp.choiceNow[0]))
            {
                choice = 'A';
                int totalChoice = 1;
                Console.Write("You Choice [");
                foreach (var item in choices)
                {
                    if (totalChoice != choices.Count)
                        Console.Write($"{choice}/");
                    else
                        Console.Write($"{choice}]: ");
                    totalChoice++;
                    choice++;
                }
                gp.choiceNow = Console.ReadLine();
            }

            gamePlay.choiceNow = gp.choiceNow;
            Console.Write("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        public static void showInput(string instruction, GamePlay gamePlay)
        {
            drawLine();
            while (gamePlay.varInput == null || gamePlay.varInput == "")
            {
                Console.Write(instruction);
                gamePlay.varInput = Console.ReadLine();
            }
            drawLine();
            Console.WriteLine();
            Console.Write("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        // Battle Phase if 1 vs 1
        public static EnumBattleResult BattlePhase(Player currentPlayer, Enemy enemy, GamePlay gamePlay)
        {
            // generate random
            Random random = new Random();
            int enemyHp = enemy.MonsterAttribute.HealthPower;
            int playerHP = currentPlayer.PlayerAttribute.HealthPower;
            int randomAttack = 0;
            int randomDefend = 0;
            int diffAttDef = 0;
            string message = "";
            List<string> optionBattlePhase = new List<string>()
            {
                "Attack","Defense","Skill","Item","Run"
            };

            characterBuble(ConsoleColor.DarkRed, "", $"{enemy.Name} appeared");

            while (enemy.MonsterAttribute.HealthPower > 0 && currentPlayer.PlayerAttribute.HealthPower > 0)
            {
                characterBubleNoClear(ConsoleColor.Red, enemy.Name, $"HP {enemy.MonsterAttribute.HealthPower}/{enemyHp}");
                characterBubleNoClear(ConsoleColor.Blue, currentPlayer.Name, $"HP {currentPlayer.PlayerAttribute.HealthPower}/{playerHP}");

                //showChoice(ConsoleColor.Blue, $"Battle Phase: {enemy.Name}", "Attack", "Defense", "Item", "Run", gamePlay);

                showChoiceMany(ConsoleColor.Blue, $"Battle Phase: {enemy.Name}", optionBattlePhase, gamePlay);
                #region Attack
                if (gamePlay.choiceNow == "A")
                {
                    if (currentPlayer.PlayerAttribute.Speed >= enemy.MonsterAttribute.Speed)
                    {
                        #region player attack enemy
                        // algorithm to get value of player's attack and enemy's defense
                        randomAttack = Generate.GenerateRandomAttribute(currentPlayer.PlayerAttribute.Attack, gamePlay);
                        randomDefend = Generate.GenerateRandomAttribute(enemy.MonsterAttribute.Defense, gamePlay);

                        diffAttDef = randomAttack - randomDefend;

                        characterBuble(ConsoleColor.Blue, "", $"{currentPlayer.Name} try to Attack {enemy.Name}!");

                        if (diffAttDef > 0) // player serang
                        {
                            // algorithm critical hit based on luck and difference of tolerance
                            if (diffAttDef > gamePlay.ToleranceUp && (currentPlayer.PlayerAttribute.Luck > (enemy.MonsterAttribute.Luck + gamePlay.ToleranceUp)
                                || random.Next(gamePlay.TopLimit - currentPlayer.PlayerAttribute.Luck) == random.Next(gamePlay.TopLimit - currentPlayer.PlayerAttribute.Luck)))
                            {
                                diffAttDef *= 2;
                                message = "Critical Hit!";
                            }
                            else
                            {
                                message = "Your attack success!";
                            }

                            characterBuble(ConsoleColor.White, "", message, $"HP of {enemy.Name} decreased by {diffAttDef}");
                            enemy.MonsterAttribute.HealthPower -= diffAttDef;
                        }
                        else if (diffAttDef == 0 || diffAttDef >= gamePlay.ToleranceDown)
                        {
                            characterBuble(ConsoleColor.White, "", $"{enemy.Name} defend it well!");
                        }
                        else if (diffAttDef < (0 - gamePlay.ToleranceDown))
                        {
                            characterBuble(ConsoleColor.White, "", $"{enemy.Name} Evade and attack {currentPlayer.Name} back!", $"Your HP decreased by {Math.Abs(diffAttDef)}");
                            currentPlayer.PlayerAttribute.HealthPower -= Math.Abs(diffAttDef);
                        }
                        #endregion

                        #region enemy attack player
                        // algorithm to get value of attack of enemy and defense of player
                        randomAttack = Generate.GenerateRandomAttribute(enemy.MonsterAttribute.Attack, gamePlay);
                        randomDefend = Generate.GenerateRandomAttribute(currentPlayer.PlayerAttribute.Defense, gamePlay);
                        diffAttDef = randomAttack - randomDefend;
                        characterBuble(ConsoleColor.Blue, "", $"{enemy.Name} try to Attack {currentPlayer.Name}!");
                        if (diffAttDef > 0)
                        {
                            // algorithm critical hit based on luck and difference of tolerance
                            if (diffAttDef > gamePlay.ToleranceUp && (enemy.MonsterAttribute.Luck > (currentPlayer.PlayerAttribute.Luck + gamePlay.ToleranceUp)
                                || random.Next(gamePlay.TopLimit - enemy.MonsterAttribute.Luck) == random.Next(gamePlay.TopLimit - enemy.MonsterAttribute.Luck)))
                            {
                                diffAttDef *= 2;
                                message = "Critical Hit!";
                            }
                            else
                            {
                                message = $"{enemy.Name} attack success!";
                            }

                            characterBuble(ConsoleColor.White, "", message, $"HP of {currentPlayer.Name} decreased by {diffAttDef}");
                            currentPlayer.PlayerAttribute.HealthPower -= diffAttDef;
                        }
                        else if (diffAttDef == 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{currentPlayer.Name} defend it well!");
                        }
                        else if (diffAttDef < 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{currentPlayer.Name} Evade and attack {enemy.Name} back!", $"{enemy.Name} HP decreased by {Math.Abs(diffAttDef)}");
                            enemy.MonsterAttribute.HealthPower -= Math.Abs(diffAttDef);
                        }
                        #endregion
                    }
                    else if (currentPlayer.PlayerAttribute.Speed < enemy.MonsterAttribute.Speed)
                    {
                        #region enemy attack player
                        // algorithm to get value of attack of enemy and defense of player
                        randomAttack = Generate.GenerateRandomAttribute(enemy.MonsterAttribute.Attack, gamePlay);
                        randomDefend = Generate.GenerateRandomAttribute(currentPlayer.PlayerAttribute.Defense, gamePlay);

                        diffAttDef = randomAttack - randomDefend;
                        if (diffAttDef > 0)
                        {
                            // algorithm critical hit based on luck and difference of tolerance
                            if (diffAttDef > gamePlay.ToleranceUp && (enemy.MonsterAttribute.Luck > (currentPlayer.PlayerAttribute.Luck + gamePlay.ToleranceUp)
                                || random.Next(gamePlay.TopLimit - enemy.MonsterAttribute.Luck) == random.Next(gamePlay.TopLimit - enemy.MonsterAttribute.Luck)))
                            {
                                diffAttDef *= 2;
                                message = "Critical Hit!";
                            }
                            else
                            {
                                message = $"{enemy.Name} attack success!";
                            }

                            characterBuble(ConsoleColor.White, "", message, $"HP of {currentPlayer.Name} decreased by {diffAttDef}");
                            currentPlayer.PlayerAttribute.HealthPower -= diffAttDef;
                        }
                        else if (diffAttDef == 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{currentPlayer.Name} defend it well!");
                        }
                        else if (diffAttDef < 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{currentPlayer.Name} Evade and attack {enemy.Name} back!", $"{enemy.Name} HP decreased by {Math.Abs(diffAttDef)}");
                            enemy.MonsterAttribute.HealthPower -= Math.Abs(diffAttDef);
                        }
                        #endregion

                        #region player attack enemy
                        // algorithm to get value of attack of player and defense of enemy
                        randomAttack = Generate.GenerateRandomAttribute(currentPlayer.PlayerAttribute.Attack, gamePlay);
                        randomDefend = Generate.GenerateRandomAttribute(enemy.MonsterAttribute.Defense, gamePlay);

                        diffAttDef = randomAttack - randomDefend;
                        if (diffAttDef > 0)
                        {
                            // algorithm critical hit based on luck and difference of tolerance
                            if (diffAttDef > gamePlay.ToleranceUp && (currentPlayer.PlayerAttribute.Luck > (enemy.MonsterAttribute.Luck + gamePlay.ToleranceUp)
                                || random.Next(gamePlay.TopLimit - currentPlayer.PlayerAttribute.Luck) == random.Next(gamePlay.TopLimit - currentPlayer.PlayerAttribute.Luck)))
                            {
                                diffAttDef *= 2;
                                message = "Critical Hit!";
                            }
                            else
                            {
                                message = "Your attack success!";
                            }

                            characterBuble(ConsoleColor.White, "", message, $"HP of {enemy.Name} decreased by {diffAttDef}");
                            enemy.MonsterAttribute.HealthPower -= diffAttDef;
                        }
                        else if (diffAttDef == 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{enemy.Name} defend it well!");
                        }
                        else if (diffAttDef < 0)
                        {
                            characterBuble(ConsoleColor.White, "", $"{enemy.Name} Evade and attack {currentPlayer.Name} back!", $"Your HP decreased by {Math.Abs(diffAttDef)}");
                            currentPlayer.PlayerAttribute.HealthPower -= Math.Abs(diffAttDef);
                        }
                        #endregion
                    }
                }
                #endregion
            } // end of while
            
            
            // if ...
            if(enemy.MonsterAttribute.HealthPower <= 0)
            {
                characterBuble(ConsoleColor.White, "", $"{enemy.Name} has fainted!");
                if(enemy.Level == EnumMonsterLevel.Bugs)
                {
                    int getGold = 10;
                    getGold += Generate.GenerateGold(getGold, gamePlay, currentPlayer);
                    characterBuble(ConsoleColor.Blue, "Battle Phase", $"You got {getGold} Gold");
                }
                else
                {
                    characterBuble(ConsoleColor.Red, "Battle Phase", $"You just died. Game Over!");
                }
            }
        }
    }
}
