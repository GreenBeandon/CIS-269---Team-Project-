using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Yahtzee.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private const int MAX_ROLLS_PER_ROUND = 3;
        private const int MAX_ROUNDS = 13;

        static Die[] dice = new Die[5];
        static int curRound = 1;
        static int curRoll = 0;
        static bool hasScoredThisRound = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string[] diceImgs = WebGame.findImgs();
                dice[0] = new Die(diceImgs);
                dice[1] = new Die(diceImgs);
                dice[2] = new Die(diceImgs);
                dice[3] = new Die(diceImgs);
                dice[4] = new Die(diceImgs);

                buttonBehavior();
            }

        }  
        
        protected void toggleSave(object sender, EventArgs e)
        {
            string test = "";

            CheckBox chBox = (CheckBox)sender;
            test = chBox.ID.Substring(5);

            int die = int.Parse(test) - 1;
            if (chBox.Checked)
                dice[die].isSaved = true;
            else
                dice[die].isSaved = false;
        }
            
        
        private void ShowPossibleValues()
        {

            #region Var init
            string one = "";
            string two = "";
            string three = "";
            string four = "";
            string five = "";
            string six = "";

            string threeOfAKind = "";
            string fourOfAKind = "";
            string smStraight = "";
            string lgStraight = "";
            string fullHouse = "";
            string chance = "";
            string yahtzee = "";
            #endregion

            #region Var Assign
            one = Scoring.getNumOfSide(dice, Side.One).ToString();
            two = (Scoring.getNumOfSide(dice, Side.Two) * 2).ToString();
            three = (Scoring.getNumOfSide(dice, Side.Three) * 3).ToString();
            four = (Scoring.getNumOfSide(dice, Side.Four) * 4).ToString();
            five = (Scoring.getNumOfSide(dice, Side.Five) * 5).ToString();
            six = (Scoring.getNumOfSide(dice, Side.Six) * 6).ToString();
            chance = Scoring.getTotalDiceValue(dice).ToString();


            Side side;
            if(Scoring.hasXOfAKind(dice, 3, out side))
            {
                if( Scoring.isXOfAKind(side, dice, 4))
                {
                    fourOfAKind = Scoring.getTotalDiceValue(dice).ToString();
                }
                else
                {
                    fourOfAKind = "0";
                }
                threeOfAKind = Scoring.getTotalDiceValue(dice).ToString();
            }
            else
            {
                threeOfAKind = "0";
                fourOfAKind = "0";
            }


            if (Scoring.isXStraight(dice, 4))
            {
                if (Scoring.isXStraight(dice, 5))
                {
                    lgStraight = "40";
                }
                else
                {
                    lgStraight = "0";
                }
                smStraight = "30";
            }
            else
            {
                smStraight = "0";
                lgStraight = "0";
            }


            if( Scoring.isFullHouse(dice))
            {
                fullHouse = "25";
            }
            else
            {
                fullHouse = "0";
            }

            if(Scoring.isYahtzee(dice, out side))
            {
                yahtzee = "50";
            }
            else
            {
                yahtzee = "0";
            }

            #endregion

            #region Possible Form Text Assign
            lblPossibleOnes.Text = one;
            lblPossibleTwos.Text = two;
            lblPossibleThrees.Text = three;
            lblPossibleFours.Text = four;
            lblPossibleFives.Text = five;
            lblPossibleSixes.Text = six;

            lblPossibleThreeOfAKind.Text = threeOfAKind;
            lblPossibleFourOfAKind.Text = fourOfAKind;
            lblPossibleSmStraight.Text = smStraight;
            lblPossibleLgStraight.Text = lgStraight;
            lblPossibleFullHouse.Text = fullHouse;
            lblPossibleChance.Text = chance;
            lblPossibleYahtzee.Text = yahtzee;
            #endregion




        }


        protected void RollDice()
        {
           foreach(Die i in dice)
                i.Roll();
            //dice = new Die[] { new Die(Side.Five), new Die(Side.Five), new Die(Side.Five), new Die(Side.Five), new Die(Side.Five) };
            ShowPossibleValues();
            die1Img.Src = dice[0].GetImgSrc();
            die2Img.Src = dice[1].GetImgSrc();
            die3Img.Src = dice[2].GetImgSrc();
            die4Img.Src = dice[3].GetImgSrc();
            die5Img.Src = dice[4].GetImgSrc();

            lblDie1.Text = dice[0].ToString();
            lblDie2.Text = dice[1].ToString();
            lblDie3.Text = dice[2].ToString();
            lblDie4.Text = dice[3].ToString();
            lblDie5.Text = dice[4].ToString();



        }

        private PlacesToScore ConvertToPlacesFromString(string placeText)
        {
            PlacesToScore place;


            switch (placeText)
            {
                case "Ones":
                    place = PlacesToScore.Ones;
                    break;
                case "Twos":
                    place = PlacesToScore.Twos;
                    break;
                case "Threes":
                    place = PlacesToScore.Threes;
                    break;
                case "Fours":
                    place = PlacesToScore.Fours;
                    break;
                case "Fives":
                    place = PlacesToScore.Fives;
                    break;
                case "Sixes":
                    place = PlacesToScore.Sixes;
                    break;
                case "ThreeOfAKind":
                    place = PlacesToScore.ThreeOfAKind;
                    break;
                case "FourOfAKind":
                    place = PlacesToScore.FourOfAKind;
                    break;
                case "FullHouse":
                    place = PlacesToScore.FullHouse;
                    break;
                case "SmallStraight":
                    place = PlacesToScore.SmallStraight;
                    break;
                case "LargeStraight":
                    place = PlacesToScore.LargeStraight;
                    break;
                case "Yahtzee":
                    place = PlacesToScore.Yahtzee;
                    break;
                case "Chance":
                    place = PlacesToScore.Chance;
                    break;
                default:
                    place = PlacesToScore.Error;
                    break;

            }
            return place;
        }

        private Side convertToSideFromPlace(PlacesToScore place)
        {
           switch(place)
            {
                case PlacesToScore.Ones:
                    return Side.One;
                    
                case PlacesToScore.Twos:
                    return Side.Two;
                    
                case PlacesToScore.Threes:
                    return Side.Three;
                    
                case PlacesToScore.Fours:
                    return Side.Four;
                    
                case PlacesToScore.Fives:
                    return Side.Five;
                case PlacesToScore.Sixes:
                    return Side.Six;
                default:
                    return Side.None;
            }
        }

        protected void Score(object sender, CommandEventArgs e)
        {
          
            if (hasScoredThisRound)
                return;
            Button btn = (Button)sender;
            string test = e.CommandArgument.ToString();
            

            PlacesToScore place;

            place = ConvertToPlacesFromString(test);
            Die[] newDice = dice;


            Side side = convertToSideFromPlace(place);
            if( side != Side.None)
            {

            }
            


            if(WebGame.Score(place, newDice))
            {
                hasScoredThisRound = true;
                curRoll = 3;
                btn.Enabled = false;

                

            }
            if (curRound >= MAX_ROUNDS)
            {
                lblRound.Text = "Game Over!";
                lblRoll.Text = "";
            }
           
           
            
            setScoreboards(WebGame.upSb, WebGame.lwSb);


        }

        private string getScoreText(int amount)
        {
            if (amount == -25 || amount - 100 > 0)
                return "Y";
            else if (amount == -1)
                return "";
            else
                return amount.ToString();
        }
        private string getScoreText(bool yesno)
        {
            if (yesno)
                return "50";
            else
                return "";
        }

        private bool alertIfZero()
        {
            Response.Write("<script>alert('test')</script>");
            return false;
        }


        private void setScoreboards(UpperScoreboard up, LowerScoreboard lw)
        {
            string onesText = "" + getScoreText(up.NumOnes);
            string twosText = "" + getScoreText(up.NumTwos);
            string threesText = "" + getScoreText(up.NumThrees);
            string foursText = "" + getScoreText(up.NumFours);
            string fivesText = "" + getScoreText(up.NumFives);
            string sixesText = "" + getScoreText(up.NumSixes);

            string threeOfAKindText = "" + getScoreText(lw.ValueThreeOfAKind);
            string fourOfAKindText = "" + getScoreText(lw.ValueFourOfAKind);
            string fullHouseText = "" + getScoreText(lw.HasFullHouse);
            string smStraightText = "" + getScoreText(lw.HasSmallStraight);
            string lgStraightText = "" + getScoreText(lw.HasLargeStraight);
            string chanceText = "" + getScoreText(lw.ValueChance);
            string yahtzeeText = "" + getScoreText(lw.HasYahtzee);
            

            lblOnes.Text = onesText;
            lblTwos.Text = twosText;
            lblThrees.Text = threesText;
            lblFours.Text = foursText;
            lblFives.Text = fivesText;
            lblSixes.Text = sixesText;

            lblThreeOfAKind.Text = threeOfAKindText;
            lblFourOfAKind.Text = fourOfAKindText;
            lblFullHouse.Text = fullHouseText;
            lblSmStraight.Text = smStraightText;
            lblLgStraight.Text = lgStraightText;
            lblChance.Text = chanceText;
            lblYahtzee.Text = yahtzeeText;



            lower_total.Text = lw.getTotalScore().ToString();
            upper_total.Text = up.getTotalScore().ToString();
            grand_total.Text = (lw.getTotalScore() + up.getTotalScore()).ToString();


            lblUpperBonus.Text = up.getBonus().ToString();
            lblYahtzeeBonus.Text = lw.getBonus().ToString();
            


        }

        protected void round(object sender, EventArgs e)
        { //Returns if should continue
            if (curRound <= MAX_ROUNDS)
            {
                if (curRoll < MAX_ROLLS_PER_ROUND)
                {
                    RollDice();
                    curRoll += 1;
                }
                else
                {
                    if (hasScoredThisRound)
                    {
                        if (curRound != MAX_ROUNDS)
                        {
                            curRound += 1;
                            curRoll = 1;
                            resetSaved();
                            RollDice();
                            hasScoredThisRound = false;
                        }
                        
                    }
                }
                lblRoll.Text = "Roll: " + curRoll.ToString();
                lblRound.Text = "Round: " + curRound.ToString();
            }
            

        }

        private void resetSaved()
        {
            foreach (Die die in dice)
                die.isSaved = false;
            chDie1.Checked = false;
            chDie2.Checked = false;
            chDie3.Checked = false;
            chDie4.Checked = false;
            chDie5.Checked = false;
        }

        private void buttonBehavior()
        {
            btnStartNew.Visible = false;
            if(curRound >= MAX_ROUNDS)
            {
                btnStartNew.Visible = true;
            }
        }

        protected void btnStartNew_Click(object sender, EventArgs e)
        {
            // Reset counters
            curRoll = 0;
            curRound = 1;

            // Reset textboxes
            lblChance.Text = "";
            lblDie1.Text = "";
            lblDie2.Text = "";
            lblDie3.Text = "";
            lblDie4.Text = "";
            lblDie5.Text = "";
            lblFives.Text = "";
            lblFourOfAKind.Text = "";
            lblFours.Text = "";
            lblFullHouse.Text = "";
            lblLgStraight.Text = "";
            lblOnes.Text = "";
            lblPossibleChance.Text = "";
            lblPossibleFives.Text = "";
            lblPossibleFourOfAKind.Text = "";
            lblPossibleFours.Text = "";
            lblPossibleFullHouse.Text = "";
            lblPossibleLgStraight.Text = "";
            lblPossibleOnes.Text = "";
            lblPossibleSixes.Text = "";
            lblPossibleSmStraight.Text = "";
            lblPossibleThreeOfAKind.Text = "";
            lblPossibleThrees.Text = "";
            lblPossibleTwos.Text = "";
            lblPossibleYahtzee.Text = "";
            lblRoll.Text = "";
            lblRound.Text = "";
            lblSixes.Text = "";
            lblSmStraight.Text = "";
            lblThreeOfAKind.Text = "";
            lblThrees.Text = "";
            lblTwos.Text = "";
            lblUpperBonus.Text = "";
            lblYahtzee.Text = "";
            lblYahtzeeBonus.Text = "";

            // TODO: Reset scores

            upper_total.Text = "";
            lower_total.Text = "";
            grand_total.Text = "";


        }

        
    }
}