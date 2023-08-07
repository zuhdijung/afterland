using System;
using Afterland.Entity;
using Afterland.Helper;
using Afterland.Scene;

namespace Afterland
{
    class Program
    {
        public static Player currentPlayer = new Player();
        public static GamePlay gamePlay = new GamePlay();
        public static CharacterName character = new CharacterName();
        static void Main(string[] args)
        {
            Start.startNewGame(currentPlayer, gamePlay, character);

            Start.walkAtDesert(currentPlayer, gamePlay, character);
        }
    }
}