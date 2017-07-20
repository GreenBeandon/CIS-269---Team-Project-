using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public class DebugGame
    {

        public static void PlayGame()
        {
            //GAME INIT
            Die[] dice = new Die[] { new Die(), new Die(), new Die(), new Die(), new Die() };


            //ROUND LOGIC
            string roundString = "";

            //Get Dice
           // dice = Scoring.Sort(Scoring.RollDice(dice));
            //Test For Large Straight
            //dice = Sort(createLGStraight());
            //Test For Small Straight
            //dice = Sort(createSMStraight());
            //Test For Yahtzee
            //dice = createYahtzee();
            //Test for Full House
            //dice = Sort(createFullHouse());
            string diceString = Scoring.GetDiceValue(dice);

            //Get Possible Sides
            Side[] possibleSides = Scoring.getSidesPossible(dice);
            string possibleSideString = "Possible Choices: \n" + Scoring.getSidesAsString(possibleSides) + Scoring.getAllPossibleXOfAKind(possibleSides, dice) + Scoring.getAllRuns(possibleSides) + Scoring.getFullHouse(possibleSides, dice);



            roundString += diceString + "\n" + possibleSideString;
            Console.WriteLine(roundString);
            Console.ReadLine();


        }

        public static string getChoiceString(Die[] dice)
        {
            string roundString = "";
            string diceString = Scoring.GetDiceValue(dice);

            //Get Possible Sides
            Side[] possibleSides = Scoring.getSidesPossible(dice);
            string possibleSideString = "Possible Choices: \n" + Scoring.getSidesAsString(possibleSides) + Scoring.getAllPossibleXOfAKind(possibleSides, dice) + Scoring.getAllRuns(possibleSides) + Scoring.getFullHouse(possibleSides, dice);
            roundString += diceString + "\n" + possibleSideString;
            return roundString;

        }

        public static int round(int roundNum)
        {
            //1. Roll dice
            Die[] dice = new Die[] { new Die(), new Die(), new Die(), new Die(), new Die() };
            //dice = Scoring.Sort(Scoring.RollDice(dice));
            //2. Get possible places
            Console.WriteLine(getChoiceString(dice));

            //3A. Select dice to re roll

            //3B. Score - Set roundNumber to 4

            //4. Return round number
            return ++roundNum;
        }


        //Test for a Yahtzee of 6's
        public static Die[] createYahtzee()
        {
            return new Die[] { new Die(Side.Six), new Die(Side.Six), new Die(Side.Six), new Die(Side.Six), new Die(Side.Six) };
        }
        //Test for Large Straight 2-6
        public static Die[] createLGStraight()
        {
            return new Die[] { new Die(Side.Six), new Die(Side.Two), new Die(Side.Three), new Die(Side.Four), new Die(Side.Five) };
        }
        //Test for Small Straight 1,6,3,4,5 should take 3-6
        public static Die[] createSMStraight()
        {
            return new Die[] { new Die(Side.One), new Die(Side.Six), new Die(Side.Three), new Die(Side.Four), new Die(Side.Five) };

        }
        //Test for FullHouse 1,1,1,3,3
        public static Die[] createFullHouse()
        {
            return new Die[] { new Die(Side.One), new Die(Side.One), new Die(Side.One), new Die(Side.Three), new Die(Side.Three) };
        }

    }
}
