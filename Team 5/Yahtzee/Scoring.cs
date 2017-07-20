using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{



    public class Scoring
    {

        public static bool isYahtzee(Die[] dice, out Side side)
        {
            for (int i = 1; i < 7; i++)
            {
                Side testSide = (Side)i;
                if (isXOfAKind(testSide, dice, 5))
                {
                    side = testSide;
                    return true;
                }
            }
            side = Side.None;
            return false;
        }
        //String representation of if we have a full house or not. Returns "Full House" or ""
        public static string getFullHouse(Side[] sides, Die[] dice)
        {
            if (isFullHouse(sides, dice))
                return "Full House\n";
            return "";
        }

        //String representation of the type of runs we have. Only 4 and 5 or Small and Large repectively
        public static string getAllRuns(Side[] sides)
        {
            string returnString = "";
            if (isXStraight(sides, 5))
            {
                returnString += "Small Straight\n";
                returnString += "Large Straight\n";
            }
            else if (isXStraight(sides, 4))
            {
                returnString += "Small Straight\n";
            }
            return returnString;
        }

        //Simple bubble sort using the value behind dice
        //Could be changed to a better type of sorting
        public static void Sort(Die[] dice)
        {
            for (int i = 1; i <= dice.Length - 1; ++i)

                for (int j = 0; j < dice.Length - i; ++j)

                    if (dice[j].getTop > dice[j + 1].getTop)


                        Swap(ref dice[j], ref dice[j + 1]);


        }

        static void Swap(ref Die x, ref Die y)
        {
            Die temp = x;
            x = y;
            y = temp;
        }
        //Given a specifc run, check to see if there are sides that match that number.
        //For instance if we have run = 4 and sides = {One, Two, Three, Four, Five} isXStraight returns true
        public static bool isXStraight(Side[] sides, int run)
        {
            if (sides.Length < 4) return false; //It can't be a straight
            int count = 1;

            for (int i = 1; i < sides.Length; i++)
            {

                if (sides[i - 1] == (sides[i] - 1))
                    count += 1;
            }
            if (count >= run)
                return true;
            return false;
        }
        public static bool isXStraight(Die[] dice, int run)
        {
            Die[] newDice = new Die[dice.Length];
            dice.CopyTo(newDice, 0);
            Sort(newDice);
            Side[] sides = getSidesPossible(newDice);
            return isXStraight(sides, run);
        }

        


        //Goes through every side in sides, and checks if three of a kind, and four of a kind is possible
        //NEEDS REFINEMENT -- COULD BE MUCH QUICKER
        public static String getAllPossibleXOfAKind(Side[] sides, Die[] dice)
        {
            string returnString = "";
            foreach (Side side in sides)
            {
                returnString += getAllPossibleXOfAKindOfSide(side, dice);
            }
            return returnString;
        }
       


        //Returns each side as a string. If we have {One, Two, Three} it returns "One Two Three"
        public static string getSidesAsString(Side[] sides)
        {
            string sidesString = "";
            foreach (Side side in sides)
                sidesString += side.ToString() + "\n";
            return sidesString;
        }

        //for each side, check to see if there is two of a kind or three of a kind for it. 
        //If there is two of a kind of one side, and three of a kind of another, it's a full house
        public static bool isFullHouse(Side[] sides, Die[] dice)
        {
            bool threeOfAKind = false;
            bool twoOfAKind = false;
            foreach (Side side in sides)
            {
                if (!threeOfAKind)
                {
                    if (isXOfAKind(side, dice, 3))
                    {
                        threeOfAKind = true;
                        if (twoOfAKind)
                            return true;
                        continue;

                    }
                }
                if (!twoOfAKind)
                {
                    if (isXOfAKind(side, dice, 2))
                    {
                        twoOfAKind = true;
                        if (threeOfAKind)
                            return true;
                    }
                }


            }
            return false;
        }
        
        public static bool isFullHouse(Die[] dice)
        {
            Side[] sides = getSidesPossible(dice);
            return isFullHouse(sides, dice);
        }


        //For a particular side, check to see if it is four of a kind, three of a kind, or both
        public static String getAllPossibleXOfAKindOfSide(Side sideToTest, Die[] dice)
        {
            string kinds = "";
            bool Yahtzee = isXOfAKind(sideToTest, dice, 5);
            if (Yahtzee)
            {
                kinds += "Three of a Kind for " + sideToTest.ToString() + "\n";
                kinds += "Four of a kind for " + sideToTest.ToString() + "\n";
                kinds += "Yahtzee for " + sideToTest.ToString();
            }
            else
            {
                bool FourOfAKind = isXOfAKind(sideToTest, dice, 4);

                if (FourOfAKind)
                {
                    kinds += "Three of a Kind for " + sideToTest.ToString() + "\n";
                    kinds += "Four of a kind for " + sideToTest.ToString() + "\n";
                }
                else
                {
                    bool ThreeOfAKind = isXOfAKind(sideToTest, dice, 3);
                    if (ThreeOfAKind)
                    {
                        kinds += "Three of a Kind for " + sideToTest.ToString() + "\n";
                    }
                }
            }

            return kinds;
        }

        //Checks to see if there is a specific number of a particular side in dice.
        public static bool isXOfAKind(Side sideToLookFor, Die[] dice, int x)
        {
            int numSides = getNumOfSide(dice, sideToLookFor);
            if (numSides >= x)
                return true;
            return false;


        }
        
        public static bool hasXOfAKind(Die[] dice, int x, out Side side)
        {


            if (isXOfAKind(Side.One, dice, x))
            {
                side = Side.One;
                return true;
            }
            if (isXOfAKind(Side.Two, dice, x))
            {
                side = Side.Two;
                return true;
            }
            if (isXOfAKind(Side.Three, dice, x))
            {
                side = Side.Three;
                return true;
            }
            if (isXOfAKind(Side.Four, dice, x))
            {
                side = Side.Four;
                return true;
            }
            if (isXOfAKind(Side.Five, dice, x))
            {
                side = Side.Five;
                return true;
            }
            if (isXOfAKind(Side.Six, dice, x))
            {
                side = Side.Six;
                return true;
            }
            side = Side.None;
            return false;
        }
        // Total value of dice that were rolled
        public static int getTotalDiceValue(Die[] dice)
        {
            int total = 0;
            foreach (Die i in dice)
                total += (int)i.getTop;
            return total;
        }



        //Given the dice, and a specific side, it will count the total number of that side
        //NEEDS REFINEMENT -- COULD BE QUICKER
        public static int getNumOfSide(Die[] dice, Side sideToCheck)
        {
            int count = 0;
            foreach (Die die in dice)
            {
                if (die.getTop == sideToCheck)
                    count += 1;
            }
            return count;
        }

        /*Removes any repeats from dice, and prints out each side possible. 
        EX: dice = {One, Two, Four, Two, Five} getSidesPossible(dice) returns "One  Two Four    Five"*/
        public static Side[] getSidesPossible(Die[] dice)
        {
            List<Side> possibleSides = new List<Side>();
            foreach (Die die in dice)
            {
                bool newSide = true;
                foreach (Side side in possibleSides)
                {
                    if (die.getTop == side)
                    {
                        newSide = false;
                        break;
                    }
                }
                if (newSide) possibleSides.Add(die.getTop);
            }
            return possibleSides.ToArray();
        }

        //Iterates through diceToDiplay and returns each dice's ToString method with tabs in between
        public static String GetDiceValue(Die[] diceToDisplay)
        {
            string diceString = "";
            foreach (Die die in diceToDisplay)
                diceString += die + "\t";
            return diceString;
        }



        //Rolls dice by iterating through diceToRoll and calling the Roll() method
        public static Die[] RollDice(Die[] diceToRoll)
        {
            //Roll each die
            foreach (Die die in diceToRoll)
            {
                die.Roll();
            }
            return diceToRoll;
        }



    }




}
