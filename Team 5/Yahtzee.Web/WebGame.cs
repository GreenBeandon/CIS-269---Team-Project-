using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Yahtzee.Web
{
    public class WebGame
    {
        public static UpperScoreboard upSb = new UpperScoreboard();
        public static LowerScoreboard lwSb = new LowerScoreboard();
        public static bool hasYahtzee = false;

        public static string[] findImgs()
        {
            string[] returnArr = new string[6];
            for( int i = 1; i < 7; i++)
                returnArr[i-1] = ("../Assets/Die" + (i) + ".jpg"); // source = Dice[i]
            return returnArr;
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

        public static bool Score(PlacesToScore place, Die[] dice)
        {
            bool flag = false;
            Side yahtzeeSide;
            bool isYahtzee = Scoring.isYahtzee(dice, out yahtzeeSide);
            if (isYahtzee)
            {
                
                if (place == PlacesToScore.Yahtzee)
                    lwSb.HasYahtzee = 1;
                else
                {
                    if (lwSb.HasYahtzee == -1)
                        return flag;
                    
                }



                   
                
            }

            
            switch(place)
            {
                #region Ones
                case PlacesToScore.Ones:

                    if(isYahtzee)
                    {
                        if(yahtzeeSide != Side.One)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumOnes = -25;
                        flag = true;
                        break;
                    }


                    int ones = Scoring.getNumOfSide(dice, Side.One);
                    upSb.NumOnes = ones;
                    flag = true;
                    break;
                #endregion
                #region Twos
                case PlacesToScore.Twos:

                    if (isYahtzee)
                    {
                        if (yahtzeeSide != Side.Two)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumTwos = -25;
                        flag = true;
                        break;
                    }

                    int twos = Scoring.getNumOfSide(dice, Side.Two);
                    upSb.NumTwos = twos;
                    flag = true;
                    break;
                #endregion
                #region Threes
                case PlacesToScore.Threes:

                    if (isYahtzee)
                    {
                        if (yahtzeeSide != Side.Three)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumThrees = -25;
                        flag = true;
                        break;
                    }

                    int threes = Scoring.getNumOfSide(dice, Side.Three);
                    upSb.NumThrees = threes;
                    flag = true;
                    break;
                #endregion
                #region Fours
                case PlacesToScore.Fours:

                    if (isYahtzee)
                    {
                        if (yahtzeeSide != Side.Four)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumFours = -25;
                        flag = true;
                        break;
                    }

                    int fours = Scoring.getNumOfSide(dice, Side.Four);
                    upSb.NumFours = fours;
                    flag = true;
                    break;
                #endregion
                #region Fives
                case PlacesToScore.Fives:

                    if (isYahtzee)
                    {
                        if (yahtzeeSide != Side.Five)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumFives = -25;
                        flag = true;
                        break;
                    }

                    int fives = Scoring.getNumOfSide(dice, Side.Five);
                    upSb.NumFives = fives;
                    flag = true;
                    break;
                #endregion
                #region Sixes
                case PlacesToScore.Sixes:

                    if (isYahtzee)
                    {
                        if (yahtzeeSide != Side.Six)
                        {
                            return flag;
                        }
                        lwSb.NumBonusYahtzees++;
                        upSb.NumSixes = -25;
                        flag = true;
                        break;
                    }

                    int sixes = Scoring.getNumOfSide(dice, Side.Six);
                    upSb.NumSixes = sixes;
                    flag = true;
                    break;
                #endregion
                #region Three Of A kind
                case PlacesToScore.ThreeOfAKind:
                    if (isYahtzee)
                    {
                        lwSb.NumBonusYahtzees++;
                        //lwSb.ValueThreeOfAKind = -25;
                        lwSb.ValueThreeOfAKind = Scoring.getTotalDiceValue(dice) + 100;
                        flag = true;
                        break;
                    }
                    Side side;
                    bool hasThreeOfAKind = Scoring.hasXOfAKind(dice, 3, out side);
                    if(hasThreeOfAKind)
                    {
                        lwSb.ValueThreeOfAKind = Scoring.getTotalDiceValue(dice);
                    }
                    else
                        lwSb.ValueThreeOfAKind = 0;
                    flag = true;

                    break;
                #endregion
                #region Four Of A kind
                case PlacesToScore.FourOfAKind:
                    if (isYahtzee)
                    {
                        lwSb.NumBonusYahtzees++;
                        //lwSb.ValueFourOfAKind = -25;
                        lwSb.ValueFourOfAKind = Scoring.getTotalDiceValue(dice) + 100;
                        flag = true;
                        break;
                    }
                    
                    bool hasFourOfAKind = Scoring.hasXOfAKind(dice, 4, out side);
                    if (hasFourOfAKind)
                    {
                        lwSb.ValueFourOfAKind = Scoring.getTotalDiceValue(dice);
                    }
                    else
                        lwSb.ValueFourOfAKind = 0;
                    flag = true;

                    break;
                #endregion
                #region FullHouse
                case PlacesToScore.FullHouse:
                    if (isYahtzee)
                    {
                        lwSb.NumBonusYahtzees++;
                        lwSb.HasFullHouse = -25;
                        flag = true;
                        break;
                    }

                    if(Scoring.isFullHouse(dice))
                    {
                        lwSb.HasFullHouse = 25;
                        
                    }
                    else
                    {
                        lwSb.HasFullHouse = 0;
                    }
                    flag = true;
                    break;
                #endregion
                #region Small Straight
                case PlacesToScore.SmallStraight:
                    if (isYahtzee)
                    {
                        lwSb.NumBonusYahtzees++;
                        lwSb.HasSmallStraight = -25;
                        flag = true;
                        break;
                    }
                    
                    if(Scoring.isXStraight(dice, 4))
                    {
                        lwSb.HasSmallStraight = 30;
                    }
                    else
                    {
                        lwSb.HasSmallStraight = 0;
                    }
                    flag = true;


                    break;
                #endregion
                #region Large Straight
                case PlacesToScore.LargeStraight:
                    if (isYahtzee)
                    {
                        lwSb.NumBonusYahtzees++;
                        lwSb.HasLargeStraight = -25;
                        flag = true;
                        break;
                    }

                    if(Scoring.isXStraight(dice, 5))
                    {
                        lwSb.HasLargeStraight = 40;
                        
                    }
                    else
                    {
                        lwSb.HasLargeStraight = 0;
                    }
                    flag = true;
                    break;
                #endregion
                #region Large Straight
                case PlacesToScore.Chance:
                    if (isYahtzee)
                    {
                        //lwSb.ValueChance = -25;
                        lwSb.NumBonusYahtzees++;
                        lwSb.ValueChance = Scoring.getTotalDiceValue(dice) + 100;
                        flag = true;
                        break;
                    }
                    
                    lwSb.ValueChance = Scoring.getTotalDiceValue(dice);
                    flag = true;
                    break;
                #endregion
                #region Yahtzee
                case PlacesToScore.Yahtzee:
                    hasYahtzee = true;
                    flag = true;
                    break;
                    #endregion
            }

            return flag;

        }

    }
}