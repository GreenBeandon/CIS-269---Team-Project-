using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    class Program
    {
        static void Main(string[] args)
        {
            // variables
            bool playGame = true;
            string menuCommand = "";

            // game loop
            while (playGame)
            {
                menuCommand = DisplayMenu();

                switch (menuCommand.ToUpper())
                {
                    case "X":
                        playGame = false;
                        break;
                    case "D":
                        DebugGame.PlayGame();
                        break;
                    default:
                        PlayYahtzee();
                        break;
                }

            }

        }   //how to reference C# in ASPX

        static void TestNewDice()
        {
            Die[] gameDice = new Die[5];
            for (int i = 0; i < gameDice.Length; i++)
            {
                gameDice[i] = new Die();
                gameDice[i].Roll();
                Console.WriteLine(gameDice[i]);
            }
            Console.ReadLine();

        }
        static string DisplayMenu()
        {
            string menuCommand = "";

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("YAHTZEE");
            Console.WriteLine("");
            Console.WriteLine("- roll the 5 dice to start the round");
            Console.WriteLine("- display only those fields/values greater than 0");
            Console.WriteLine("- press 'Enter' to play");
            Console.WriteLine("- press 'X' to exit");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");

            menuCommand = Console.ReadLine();
            return menuCommand;
        }

        static void PlayYahtzee()
        {
            // variables
            int fieldValue = 0;
            Random rnd = new Random();

            Console.Clear();
            
            // make dice
            Dice dice = new Dice();

            // roll dice - using a random value to facilitate a loop of rolling the dice to effectively simulate the "rolling" of the dice
            for (int i = 0; i < rnd.Next(5, 15); i++)
            {
                System.Threading.Thread.Sleep(100);
                Console.Clear();
                dice.RollDice(rnd);
                for (int j = 0; j < dice.GameDice.Length; j++)
                {
                    Console.Write("{0, 5}", dice.GameDice[j]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.WriteLine("--------------------------------------------------");
            // calculate and show total of 1s, if applicable
            fieldValue = dice.CalcX(1);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 1s = {0}", fieldValue);
            }
            // calculate and show total of 2s, if applicable
            fieldValue = dice.CalcX(2);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 2s = {0}", fieldValue);
            }
            // calculate and show total of 3s, if applicable
            fieldValue = dice.CalcX(3);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 3s = {0}", fieldValue);
            }
            // calculate and show total of 4s, if applicable
            fieldValue = dice.CalcX(4);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 4s = {0}", fieldValue);
            }
            // calculate and show total of 5s, if applicable
            fieldValue = dice.CalcX(5);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 5s = {0}", fieldValue);
            }
            // calculate and show total of 6s, if applicable
            fieldValue = dice.CalcX(6);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 6s = {0}", fieldValue);
            }
            Console.WriteLine("");
            // calculate and show total of 3 of a kind, if applicable
            fieldValue = dice.CalcXOfAKind(3);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 3 of a kind = {0}", fieldValue);
            }
            // calculate and show total of 4 of a kind, if applicable
            fieldValue = dice.CalcXOfAKind(4);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for 4 of a kind = {0}", fieldValue);
            }
            // calculate and show total of full house, if applicable
            fieldValue = dice.CalcFullHouse();
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for full house = {0}", fieldValue);
            }
            // calculate and show total of small straight, if applicable
            fieldValue = dice.CalcStraight(false);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for small straight = {0}", fieldValue);
            }
            // calculate and show total of large straight, if applicable
            fieldValue = dice.CalcStraight(true);
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for large straight = {0}", fieldValue);
            }
            // calculate and show total of yahtzee (5 of a kind), if applicable
            fieldValue = dice.CalcXOfAKind(5);
            if (fieldValue > 0)
            {
                Console.WriteLine("YAHTZEE!!! = {0}", fieldValue);
            }
            // calculate and show total of chance (total of all dice)
            fieldValue = dice.CalcChance();
            if (fieldValue > 0)
            {
                Console.WriteLine("Value for chance = {0}", fieldValue);
            }

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("[ press enter to continue ... ]");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
