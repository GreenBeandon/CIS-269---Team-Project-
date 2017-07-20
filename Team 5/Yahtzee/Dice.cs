using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    class Dice
    {
        #region Constants

        public const int SidesOfDie = 6;

        #endregion

        #region Properties

        private int[] gameDice = new int[5];

        public int[] GameDice
        {
            get { return gameDice; }
            set { gameDice = value; }
        } 

        #endregion

        #region Methods

        /// <summary>
        /// constructor
        /// </summary>
        public Dice()
        {
            for (int i = 0; i < gameDice.Length; i++)
            {
                gameDice[i] = 0;
            }
        }

        /// <summary>
        /// rolls the dice in the array
        /// </summary>
        /// <param name="rnd">the randomizer to ensure a "random" roll of each die in the dice collection</param>
        public void RollDice(Random rnd)
        {
            for (int i = 0; i < gameDice.Length; i++)
            {
                gameDice[i] = rnd.Next(1, SidesOfDie + 1);
            }
        }

        /// <summary>
        /// CalcX determines the total of a specified die value of a collection of dice
        /// </summary>
        /// <param name="dieValue">value of the dice to be totalled (1s, 2s, ... 6s)</param>
        /// <returns>the total of the specified die value in the collection of dice</returns>
        public int CalcX(int dieValue)
        {
            int total = 0;

            for (int i = 0; i < gameDice.Length; i++)
            {
                if (gameDice[i] == dieValue)
                {
                    total += gameDice[i];
                }
            }

            return total;
        }

        /// <summary>
        /// calculate X of a kind total (where X = {3, 4, 5} based on dieValue)
        /// </summary>
        /// <param name="dieValue">determines the Yahtzee field to calculate</param>
        /// <param name="gameDice">the collection of dice</param>
        /// <returns>the total of the dice, if a X of a kind exists, or 0</returns>
        public int CalcXOfAKind(int numOfAKind)
        {
            int total = 0;
            int counter = 1;
            bool isXOfAKind = false;

            // sort the dice array
            Array.Sort(gameDice);

            for(int i = 0; i < gameDice.Length; i++)
            {
                // sum up all the dice
                total += gameDice[i];

                if (i < gameDice.Length - 1)
                {
                    // two consecutive die values, increment the counter
                    if (gameDice[i] == gameDice[i + 1])
                    {
                        counter++;
                        
                        // if the counter = the X of a kind (3, 4, or 5), flag it
                        if (numOfAKind == counter)
                        {
                            isXOfAKind = true;
                        }
                    }
                    else
                    {
                        // two consecutive die values do not equate, start the counter over
                        counter = 1;
                    }
                }
            }

            if (!isXOfAKind)
            {
                // not a X of a kind
                total = 0;
            }
            else
            {
                // X of a kind, adjust score for Yahtzee (5 of a kind)
                if(numOfAKind == 5)
                {
                    total = 50;
                }
            }

            return total;
        }

        /// <summary>
        /// calculate whether or not a full house (2 of a kind + 3 of a kind) is possible
        /// </summary>
        /// <returns>the total of 25, if a full house exists, or 0</returns>
        public int CalcFullHouse()
        {
            int total = 0;
            bool setOf2 = false;
            bool setOf3 = false;
            bool isFullHouse = true;

            // sort the dice array
            Array.Sort(gameDice);

            for (int i = 0; i < gameDice.Length; i++)
            {
                if (i < gameDice.Length - 1)
                {
                    switch (i)
                    {
                        case 0:
                            if (gameDice[i] != gameDice[i + 1])
                            {
                                // full house not possible - in a sorted array, the first 2 values MUST be equal for a full house to exist
                                isFullHouse = false;
                            }
                            break;
                        case 1:
                            if (gameDice[i] == gameDice[i + 1])
                            {
                                // a set of 3 has been made
                                setOf3 = true;
                            }
                            else
                            {
                                // a set of 2 has been made
                                setOf2 = true;
                            }
                            break;
                        case 2:
                            if (gameDice[i] == gameDice[i + 1])
                            {
                                if (setOf3)
                                {
                                    // full house not possible - due to 4 of a kind
                                    isFullHouse = false;
                                }
                            }
                            else
                            {
                                if (setOf2)
                                {
                                    // full house not possible - due to more than two values represented in the array of dice
                                    isFullHouse = false;
                                }
                            }
                            break;
                        case 3:
                            if (gameDice[i] != gameDice[i + 1])
                            {
                                // full house not possible - in a sorted array, the last 2 values MUST be equal for a full house to exist
                                isFullHouse = false;
                            }
                            break;
                        default:
                            // do nothing
                            break;
                    }
                }

                if (!isFullHouse)
                {
                    // full house not possible, stop analyzing the dice, no score
                    break;
                }
            }

            if (isFullHouse)
            {
                // full house determined
                total = 25;
            }

            return total;
        }

        /// <summary>
        /// calculate whether or not a straight (small or large) is possible
        /// </summary>
        /// <param name="wantLargeStraight">true for large straight, false for small straight</param>
        /// <returns>the total of 40 if a large straight exists, 30 if a small straight exists, or 0</returns>
        public int CalcStraight(bool wantLargeStraight)
        {
            int total = 0;
            bool isStraight = true;
            bool smallStraightPassUsed = false;

            // sort the dice array
            Array.Sort(gameDice);

            for (int i = 0; i < gameDice.Length; i++)
            {
                if (i < gameDice.Length - 1)
                {
                    switch (i)
                    {
                        case 0:
                            if (gameDice[i] != gameDice[i + 1] - 1)
                            {
                                if (wantLargeStraight)
                                {
                                    // large straight not possible - each of the 5 dice values MUST be consecutively one less than the next
                                    isStraight = false;
                                }
                                else
                                {
                                    smallStraightPassUsed = true;
                                }
                            }
                            break;
                        case 1:
                        case 2:
                            if (gameDice[i] != gameDice[i + 1] - 1)
                            {
                                // straight not possible - the first 4 dice OR, the last 4 dice, values MUST be consecutively one less than the next
                                isStraight = false;
                            }
                            break;
                        case 3:
                            if (gameDice[i] != gameDice[i + 1] - 1)
                            {
                                if (wantLargeStraight)
                                {
                                    // large straight not possible - each of the 5 dice values MUST be consecutively one less than the next
                                    isStraight = false;
                                }
                                else
                                {
                                    if (smallStraightPassUsed)
                                    {
                                        // small straight not possible - must have 4 consecutive values of one less than the next
                                        isStraight = false;
                                    }
                                }
                            }
                            break;
                    }
                }

                if (!isStraight)
                {
                    // straight not possible, stop analyzing the dice, no score
                    break;
                }
            }

            if (isStraight)
            {
                // straight determined
                if (wantLargeStraight)
                {
                    total = 40;
                }
                else
                {
                    total = 30;
                }
            }

            return total;
        }

        /// <summary>
        /// calculate the total of all the dice, as this is "chance"
        /// </summary>
        /// <returns>the total of all the dice</returns>
        public int CalcChance()
        {
            int total = 0;

            for (int i = 0; i < gameDice.Length; i++)
            {
                // sum up all the dice
                total += gameDice[i];
            }

            return total;
        }

        #endregion

    }
}
