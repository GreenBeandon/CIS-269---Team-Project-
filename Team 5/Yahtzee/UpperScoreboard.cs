using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public class UpperScoreboard : Scoreboard
    {
        #region Constants
        private const int UPPER_BONUS_VALUE = 35;
        private const int UPPER_BONUS_MIN = 63;
        private const int HIGHEST_NUM_OF = 5;
        private const int YAHTZEE_IDENTIFIER = -25;
        #endregion

        #region Scoring Vars
        private int numOnes = -1;
        private int numTwos = -1;
        private int numThrees = -1;
        private int numFours = -1;
        private int numFives = -1;
        private int numSixes = -1;
        #endregion

      
        #region Properties
        public int NumOnes
        {
            
            set
            {
                if (numOnes < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numOnes = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numOnes = value;                    
              
            }
            get
            {
                if (numOnes == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numOnes < 0)
                    return -1;
                else
                    return numOnes;
               
            }
        }
        public int NumTwos
        {

            set
            {
                if (numTwos < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numTwos = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numTwos = value;

            }
            get
            {

                if (numTwos == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numTwos < 0)
                    return -1;
                else
                    return numTwos * 2;
            }
        }
        public int NumThrees
        {

            set
            {
                if (numThrees < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numThrees = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numThrees = value;

            }
            get
            {

                if (numThrees == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numThrees < 0)
                    return -1;
                else
                    return numThrees * 3;
            }
        }
        public int NumFours
        {

            set
            {
                if (numFours < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numFours = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numFours = value;

            }
            get
            {

                if (numFours == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numFours < 0)
                    return -1;
                else
                    return numFours * 4;
            }
        }
        public int NumFives
        {

            set
            {
                if (numFives < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numFives = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numFives = value;

            }
            get
            {

                if (numFives == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numFives < 0)
                    return -1;
                else
                    return numFives * 5;
            }
        }
        public int NumSixes
        {

            set
            {
                if (numSixes < 0)
                    if (value < HIGHEST_NUM_OF && value >= 0)
                        numSixes = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        numSixes = value;
            }
            get
            {
                if (numSixes == YAHTZEE_IDENTIFIER)
                    return YAHTZEE_IDENTIFIER;
                if (numSixes < 0)
                    return -1;
                else
                    return numSixes * 6;
            }
        }
        #endregion
       

        #region Constructors
        public UpperScoreboard() 
        {
            //Constructor for the Upper portion of the score board
            total = 0;
            
        }
        #endregion

        #region Methods
        
        protected override int calcTotalScore() 
        {
            //Adds all the values together and if there should be a bonus, add it
            int newTotal = getValueOf(numOnes, Side.One) + getValueOf(numTwos, Side.Two) + getValueOf(numThrees, Side.Three) + getValueOf(numFours, Side.Four) + getValueOf(numFives, Side.Five) + getValueOf(numSixes, Side.Six);
            newTotal += calcBonus();
            return newTotal;
        }
        protected override int calcBonus()
        {
            int newTotal = getValueOf(numOnes, Side.One) + getValueOf(numTwos, Side.Two) + getValueOf(numThrees, Side.Three) + getValueOf(numFours, Side.Four) + getValueOf(numFives, Side.Five) + getValueOf(numSixes, Side.Six);
            if (newTotal > UPPER_BONUS_MIN)
                return UPPER_BONUS_VALUE;
            return 0;
        }

        protected override void Score(PlacesToScore place, int value)
        {

            
            switch(place)
            {
                case PlacesToScore.Ones:
                    NumOnes = value;
                    break;
                case PlacesToScore.Twos:
                    NumTwos = value;
                    break;
                case PlacesToScore.Threes:
                    NumThrees = value;
                    break;
                case PlacesToScore.Fours:
                    NumFours = value;
                    break;
                case PlacesToScore.Fives:
                    NumFives = value;
                    break;
                case PlacesToScore.Sixes:
                    NumSixes = value;
                    break;
                default:
                    break;
            }

        }
        public int getValueOf(int valueToCheck, Side side)
        {
            if (isYahtzee(valueToCheck))
                return ((int)side) * 5;
            if (valueToCheck == -1)
                return 0;
            return valueToCheck * ((int)side);
        }

       
        #endregion

    }
}
