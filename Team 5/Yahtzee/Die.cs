using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yahtzee
{
    public enum Side
    {
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        None = 7
    }


    public class Die
    {
        #region Static Vars
        private static Random rand = new Random();
        #endregion

        #region Class Vars

        //Dice has 6 sides
        private string[] sidesImgSrc = new string[6]; //Dice Pictures array
        private Side[] sides = new Side[6];
        private Side top;
        public bool isSaved = false;
        #endregion

        #region Class Properties
        public Side getTop { get { return top; } }
        #endregion


        #region Constructors
        public Die()
        {
            //Create the dice with sides 1-6
            for (int i = 1; i < 7; i++)
            {
                sides[i - 1] = (Side)i;

            }
            Roll();
        }

        public Die(string[] arr)
        {
            //Create the dice with sides 1-6
            for (int i = 1; i < 7; i++)
            {
                sides[i - 1] = (Side)i;

            }
            //ImgArray
            sidesImgSrc = arr;

            Roll();
        }

        public Die(Side top)
        {
            //Create the dice with sides 1-6
            for (int i = 1; i < 7; i++)
                sides[i - 1] = (Side)i;
            //set side
            this.top = top;
        }
        #endregion

        #region Methods
        //public void Roll()
        //{
        //    //Random 
        //    Random rnd = new Random();
        //    for (int i = 0; i < Dice.Length; i++)j
        //    {
        //        //Random number from Array 0 - 5 
        //        int index = rnd.Next(0, Dice.Length + 1);

        //    }
        //}

        public void Roll() //Old Roll()
        {
            //Rolls the dice. Returns the top
            if( isSaved == false)
            top = ((Side)rand.Next(sides.Length) + 1);
            

        }

        public string GetImgSrc()
        {
            return sidesImgSrc[((int)top-1)];
        }


        public override string ToString()
        {
            return top.ToString();
        }
        #endregion
    }
}
