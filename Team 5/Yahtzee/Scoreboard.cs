using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public enum PlacesToScore
    {
        Ones = 1,
        Twos = 2,
        Threes = 3,
        Fours = 4,
        Fives = 5,
        Sixes = 6,
        Chance = 7,
        ThreeOfAKind = 8,
        FourOfAKind = 9,
        FullHouse = 10,
        SmallStraight = 11,
        LargeStraight = 12,
        Yahtzee = 13,
        Error = 14
    }
    public abstract class Scoreboard
    {
        protected int total = 0;
        //OVERRIDE
        protected abstract int calcTotalScore();
        protected abstract void Score(PlacesToScore place, int value);

        protected abstract int calcBonus();
       

        protected virtual bool isYahtzee(int valueToCheck)
        {
            if (valueToCheck == -25)
                return true;
            return false;
        }
        
        public int getTotalScore()
        {
            return calcTotalScore();
        }
        public int getBonus()
        {
            return calcBonus();
        }
    }
}
