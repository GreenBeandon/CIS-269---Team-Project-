using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public class LowerScoreboard : Scoreboard
    {

        #region Constant Vars
        private const int YAHTZEE_VALUE = 50;
        private const int BONUS_YAHTZEE_VALUE = 100;
        private const int FULL_HOUSE_VALUE = 25;
        private const int SM_STRAIGHT_VALUE = 30;
        private const int LG_STRAIGHT_VALUE = 40;
        private const int YAHTZEE_IDENTIFIER = -25;
        #endregion

        #region Scoring Vars

        //Value of
        private int valueThreeOfAKind = -1;
        private int valueFourOfAKind = -1;
        private int valueChance = -1;

        //Number of
        private int numBonusYahtzees = 0;

        //Has scored this way;
        private int hasFullHouse = -1;
        private int hasSmallStraight = -1;
        private int hasLargeStraight = -1;
        private int hasYahtzee = -1;


        #endregion


        /*STILL NEED TO DO THESE*/
        #region Scoring Properties

        //VALUE OF
        public int ValueThreeOfAKind
        {
            set
            {
                if (valueThreeOfAKind < 0)
                    if (value >= 0)
                        valueThreeOfAKind = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        valueThreeOfAKind = value;


            }
            get
            {
                return valueThreeOfAKind;
            }
        }
        public int ValueFourOfAKind
        {
            set
            {
                if (valueFourOfAKind < 0)
                    if (value >= 0)
                        valueFourOfAKind = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        valueFourOfAKind = value;

            }
            get
            {
                return valueFourOfAKind;
            }
        }
        public int ValueChance
        {
            set
            {
                if (valueChance < 0)
                    if (value >= 0)
                        valueChance = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        valueChance = value;


            }
            get
            {
                return valueChance;
            }
        }

        //NUM OF
        public int NumBonusYahtzees
        {
            set
            {
                numBonusYahtzees++;

            }
            get
            {
                return numBonusYahtzees * 100;
            }
        }

        //HAS
        public int HasFullHouse
        {
            set
            {
                if (hasFullHouse < 0)
                    if (value >= 0)
                        hasFullHouse = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        hasFullHouse = value;

            }
            get
            {
                if (hasFullHouse > 0)
                    return FULL_HOUSE_VALUE;
                else if (hasFullHouse == 0)
                    return 0;
                else if (hasFullHouse == -1)
                    return hasFullHouse;
                else
                    return YAHTZEE_IDENTIFIER;
            }

        }

        public int HasSmallStraight
        {
            set
            {
                if (hasSmallStraight < 0)
                    if (value >= 0)
                        hasSmallStraight = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        hasSmallStraight = value;

            }
            get
            {
                if (hasSmallStraight > 0)
                    return SM_STRAIGHT_VALUE;
                else if (hasSmallStraight == 0)
                    return 0;
                else if (hasSmallStraight == -1)
                    return hasSmallStraight;
                else
                    return YAHTZEE_IDENTIFIER;
            }
        }

        public int HasLargeStraight
        {
            set
            {
                if (hasLargeStraight < 0)
                    if (value >= 0)
                        hasLargeStraight = value;
                    else if (value == YAHTZEE_IDENTIFIER)
                        hasLargeStraight = value;

            }
            get
            {
                if (hasLargeStraight > 0)
                    return LG_STRAIGHT_VALUE;
                else if (hasLargeStraight == 0)
                    return 0;
                else if (hasLargeStraight == -1)
                    return hasLargeStraight;
                else
                    return YAHTZEE_IDENTIFIER;                   
            }
        }

        public int HasYahtzee
        {
            set
            {
                if (hasYahtzee == -1)
                    hasYahtzee = -25;
                else
                    NumBonusYahtzees = 1;

            }
            get
            {
                return hasYahtzee;
              
            }
        }
        #endregion
        /*END NEED TO DO*/


        #region Constructors
        public LowerScoreboard()
        {
            //Nothing atm
        }
        #endregion

        #region Methods
        protected override int calcTotalScore()
        {
            int newTotal = 0;
            //Calc Value of Vars
            
            newTotal += getValueOf(valueThreeOfAKind, PlacesToScore.ThreeOfAKind);
            newTotal += getValueOf(valueFourOfAKind, PlacesToScore.FourOfAKind);
            newTotal += getValueOf(valueChance, PlacesToScore.Chance);

            //Calc Has
            if (hasFullHouse > 0) newTotal += FULL_HOUSE_VALUE;
            if (hasSmallStraight > 0) newTotal += SM_STRAIGHT_VALUE;
            if (hasLargeStraight > 0) newTotal += LG_STRAIGHT_VALUE;
            if (hasYahtzee == YAHTZEE_IDENTIFIER) newTotal += YAHTZEE_VALUE;

            //Calc num of
            newTotal += calcBonus();


            return newTotal;
        }
        protected override int calcBonus()
        {
            return (numBonusYahtzees * BONUS_YAHTZEE_VALUE);
        }

        protected override void Score(PlacesToScore place, int value)
        {
            switch (place)
            {
                case PlacesToScore.ThreeOfAKind:
                    ValueThreeOfAKind = value;
                    break;
                case PlacesToScore.FourOfAKind:
                    ValueFourOfAKind = value;
                    break;
                case PlacesToScore.Chance:
                    ValueChance = value;
                    break;
                case PlacesToScore.FullHouse:
                    HasFullHouse = value;
                    break;
                case PlacesToScore.SmallStraight:
                    HasSmallStraight = value;
                    break;
                case PlacesToScore.LargeStraight:
                    HasLargeStraight = value;
                    break;
                case PlacesToScore.Yahtzee:
                    HasYahtzee = value;
                    break;

                default:
                    break;
            }
        }

        protected override bool isYahtzee(int valueToCheck)
        {
            if (valueToCheck - BONUS_YAHTZEE_VALUE > 0)
                return true;
            else if (valueToCheck == -25)
                return true;
            return false;
        }

        public int getValueOf(int valueToCheck, PlacesToScore place)
        {
            if (isYahtzee(valueToCheck))
            {
                //switch(place)
                //{
                //    case PlacesToScore.SmallStraight:
                //        break;
                //    case PlacesToScore.LargeStraight:
                //        break;
                //    case { }
                //}
                return valueToCheck - 100;
            }
            else if (valueToCheck == -1)
                return 0;
            return valueToCheck;


            throw new NotImplementedException();
        }


        #endregion
    }
}
