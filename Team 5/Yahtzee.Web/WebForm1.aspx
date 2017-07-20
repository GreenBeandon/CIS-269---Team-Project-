<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Yahtzee.Web.WebForm1" %>

<!DOCTYPE html>

<html>
<head>
    <link href="Stylesheet/Website.css" rel="stylesheet" type="text/css" />
    

    <title>Yahtzee!</title>
	<meta charset="utf-8" />



</head>
<body>
    
    <h1 id="Title">Welcome! <br /> To our yahtzee game!</h1>


        
        <form runat="server">

    <div id="dice">
        <h1> Roll the Dice! </h1>
        <!--p = Physical Die-->
        <div id="pdie1" class="dice" >
            <!--<asp:Label ID="lblDie1" Text="0" runat="server"></asp:Label>-->
            <img id="die1Img" runat="server" src="Assets/Die1.jpg" width="50" />
        </div>
        <div id="pdie2" class="dice" >
            <!--<asp:Label ID="lblDie2" Text="0" runat="server"></asp:Label>-->
            <img id="die2Img" runat="server" src="Assets/Die1.jpg" width="50" />
            </div>
        <div id="pdie3" class="dice">
            <!--<asp:Label ID="lblDie3" Text="0" runat="server"></asp:Label>-->
            <img id="die3Img" runat="server" src="Assets/Die1.jpg" width="50" />
            </div>
        <div id="pdie4" class="dice" >
           <!-- <asp:Label ID="lblDie4" Text="0" runat="server"></asp:Label>-->
            <img id="die4Img" runat="server" src="Assets/Die1.jpg" width="50" />
            </div>
        <div id="pdie5" class="dice">
           <!-- <asp:Label ID="lblDie5" Text="0" runat="server"></asp:Label>-->
            <img id="die5Img" runat="server" src="Assets/Die1.jpg" width="50" />
        </div>
        <br />
        <asp:Literal ID="PopupBox" runat="server"></asp:Literal>
<section id="Scoreboard">
            <div class="scoreboard">
        <div id="upper_scoreboard">
            <asp:Table ID="upper" runat="server" BorderStyle="Solid" CellPadding="5">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell Text="Category" />
                    <asp:TableHeaderCell Text="Scoring" />
                    <asp:TableHeaderCell Text="Kept Score" />
                    <asp:TableHeaderCell Text="Keep" />
                    <asp:TableHeaderCell Text="Possible Score" />
                </asp:TableHeaderRow>

                <asp:TableRow>
                    <asp:TableCell>Aces</asp:TableCell>
                    <asp:TableCell>Count only 1's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblOnes" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnOnes" runat="server" OnCommand="Score" CommandArgument="Ones" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleOnes" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Twos</asp:TableCell>
                    <asp:TableCell>Count only 2's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblTwos" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnTwos" runat="server" OnCommand="Score" CommandArgument="Twos" UseSubmitBehavior="False" Text="Keep" />

                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleTwos" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Threes</asp:TableCell>
                    <asp:TableCell>Count only 3's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblThrees" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                             <asp:Button ID="btnThrees" runat="server" OnCommand="Score" CommandArgument="Threes" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleThrees" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Fours</asp:TableCell>
                    <asp:TableCell>Count only 4's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblFours" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnFours" runat="server" OnCommand="Score" CommandArgument="Fours" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleFours" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Fives</asp:TableCell>
                    <asp:TableCell>Count only 5's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblFives" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnFives" runat="server" OnCommand="Score" CommandArgument="Fives" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleFives" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Sixes</asp:TableCell>
                    <asp:TableCell>Count only 6's</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblSixes" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                       <asp:Button ID="btnSixes" runat="server" OnCommand="Score" CommandArgument="Sixes" UseSubmitBehavior="False" Text="Keep" />
                   </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleSixes" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        

        <p>
            Total Upper Score <asp:TextBox ID="upper_total" runat="server" width="50"/>            
        </p>

        <div id="lower_scoreboard">
            <asp:Table ID="lower" runat="server" BorderStyle="Solid" CellPadding="5">
                <asp:TableRow>
                    <asp:TableCell>3 of a kind</asp:TableCell>
                    <asp:TableCell>Total of all dice</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblThreeOfAKind" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnThreeOfAKind" runat="server" OnCommand="Score" CommandArgument="ThreeOfAKind" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleThreeOfAKind" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>4 of a kind</asp:TableCell>
                    <asp:TableCell>Total of all dice</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblFourOfAKind" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                          <asp:Button ID="btnFourOfAKind" runat="server" OnCommand="Score" CommandArgument="FourOfAKind" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleFourOfAKind" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Full house</asp:TableCell>
                    <asp:TableCell>25 pts</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblFullHouse" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnFullHouse" runat="server" OnCommand="Score" CommandArgument="FullHouse" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleFullHouse" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>Small straight</asp:TableCell>
                    <asp:TableCell>30 pts</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblSmStraight" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnSmStraight" runat="server" OnCommand="Score" CommandArgument="SmallStraight" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleSmStraight" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Large straight</asp:TableCell>
                    <asp:TableCell>40 pts</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblLgStraight" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                          <asp:Button ID="btnLgStraight" runat="server" OnCommand="Score" CommandArgument="LargeStraight" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleLgStraight" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Yahtzee!</asp:TableCell>
                    <asp:TableCell>50 pts</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblYahtzee" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                         <asp:Button ID="btnYahtzee" runat="server" OnCommand="Score" CommandArgument="Yahtzee" UseSubmitBehavior="False" Text="Keep" />
                   </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleYahtzee" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>

                <asp:TableRow>
                    <asp:TableCell>Chance</asp:TableCell>
                    <asp:TableCell>Total of all dice</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblChance" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Button ID="btnChance" runat="server" OnCommand="Score" CommandArgument="Chance" UseSubmitBehavior="False" Text="Keep" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblPossibleChance" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />

        <div id="bonus_scoreboard">
            <asp:Table ID="bonus" runat="server" BorderStyle="Solid" CellPadding="5" Width="500px">
                <asp:TableRow>
                    <asp:TableCell>Upper Section Bonus</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblUpperBonus" runat="server" ReadOnly="true" Width="25"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>Yahtzee Bonus</asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="lblYahtzeeBonus" runat="server" ReadOnly="true" Width="50"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>    
        </div>
        <br />
      
        <p>
            Lower Total Score <asp:TextBox ID="lower_total" runat="server" width="50"/>
            <br />
            <br />
            Grand Total <asp:TextBox ID="grand_total" runat="server" Width="50"></asp:TextBox>
        </p>
    </div>
</section>  

    </div>


        
       


     <%--   <div id="upperScoreboard" class="Scoreboard">
            
            <!--ONES-->
            <asp:Label ID="lblOnes" Text="Ones: " runat="server"></asp:Label>
            <asp:Button ID="btnOnes" runat="server" OnCommand="Score" Text="Score" CommandArgument="Ones" UseSubmitBehavior="False" />

            <!--TWOS-->
            <asp:Label ID="lblTwos" Text="Twos: " runat="server"></asp:Label>
             <asp:Button ID="btnTwos" runat="server" OnCommand="Score" Text="Score" CommandArgument="Twos" UseSubmitBehavior="False" Width="49px" />

            <!--THREES-->
            <asp:Label ID="lblThrees" Text="Threes: " runat="server"></asp:Label>
             <asp:Button ID="btnThrees" runat="server" OnCommand="Score" Text="Score" CommandArgument="Threes" UseSubmitBehavior="False" />

            <!--FOURS-->
            <asp:Label ID="lblFours" Text="Fours: " runat="server"></asp:Label>
             <asp:Button ID="btnFours" runat="server" OnCommand="Score" Text="Score" CommandArgument="Fours" UseSubmitBehavior="False" />

            <!--FIVES-->
            <asp:Label ID="lblFives" Text="Fives: " runat="server"></asp:Label>
             <asp:Button ID="btnFives" runat="server" OnCommand="Score" Text="Score" CommandArgument="Fives" UseSubmitBehavior="False" />

            <!--SIXES-->
            <asp:Label ID="lblSixes" Text="Sixes: " runat="server"></asp:Label>
             <asp:Button ID="btnSixes" runat="server" OnCommand="Score" Text="Score" CommandArgument="Sixes" UseSubmitBehavior="False" />
            
        </div>
        <div id="lowerScoreboard" class="Scoreboard">

              <!--Three of a kind -->
            <asp:Label ID="lblThreekind" Text="Three of a kind" runat="server"></asp:Label>
              <asp:Button ID="btnThreekind" runat="server" OnCommand="Score" Text="Score" CommandArgument="Threeofakind" UseSubmitBehavior="False" />
              <!--Four of a kind -->
            <asp:Label ID="lblFourkind" Text="Four of a kind" runat="server"></asp:Label>
               <asp:Button ID="btnFourofakind" runat="server" OnCommand="Score" Text="Score" CommandArgument="Fourofakind" UseSubmitBehavior="False" />
              <!--Full House -->
            <asp:Label ID="lblFullHouse" Text="Full House" runat="server"></asp:Label>
             <asp:Button ID="btnFullHouse" runat="server" OnCommand="Score" Text="Score" CommandArgument="Fullhouse" UseSubmitBehavior="False" />
              <!--Small Straight -->
            <asp:Label ID="lblSmallStraight" Text="Small Straight" runat="server"></asp:Label>
             <asp:Button ID="btnSmallStraight" runat="server" OnCommand="Score" Text="Score" CommandArgument="SmallStraight" UseSubmitBehavior="False" />
              <!--Large Straight -->
            <asp:Label ID="lblLargeStright" Text="Large Straight" runat="server"></asp:Label>
              <asp:Button ID="btnLargeStraight" runat="server" OnCommand="Score" Text="Score" CommandArgument="LargeStraight" UseSubmitBehavior="False" />
              <!--Chance -->
            <asp:Label ID="lblChance" Text="Chance" runat="server"></asp:Label>
               <asp:Button ID="btnChance" runat="server" OnCommand="Score" Text="Score" CommandArgument="Chance" UseSubmitBehavior="False" />
              <!--Yahtzee -->
            <asp:Label ID="lblYahtzee" Text="Yahtzee!" runat="server"></asp:Label>
               <asp:Button ID="btnYahtzee" runat="server" OnCommand="Score" Text="Score" CommandArgument="Yahtzee" UseSubmitBehavior="False" />

        </div>--%>

         
        
     <br />   

    <div id="checkboxes">
        <!--cb = CheckBox Die-->
        <h1 id="keep">Choose what to keep</h1>

        <asp:CheckBox ID="chDie1" Text="Keep Die #1" runat="server" OnCheckedChanged="toggleSave" AutoPostBack="True" />
        <asp:CheckBox ID="chDie2" Text="Keep Die #2" runat="server" OnCheckedChanged="toggleSave" AutoPostBack="True" />
        <asp:CheckBox ID="chDie3" Text="Keep Die #3" runat="server" OnCheckedChanged="toggleSave" AutoPostBack="True" />
        <asp:CheckBox ID="chDie4" Text="Keep Die #4" runat="server" OnCheckedChanged="toggleSave" AutoPostBack="True" />
        <asp:CheckBox ID="chDie5" Text="Keep Die #5" runat="server" OnCheckedChanged="toggleSave" AutoPostBack="True" />
        <!--
        <input type="checkbox" name="cbDie1" runat="server" onchange="toggleSave"/> Keep Die #1
        <input type="checkbox" name="cbDie2" runat="server" onchange="toggleSave"/> Keep Die #2
        <input type="checkbox" name="cbDie3" runat="server" onchange="toggleSave"/> Keep Die #3
        <input type="checkbox" name="cbDie4" runat="server" onchange="toggleSave"/> Keep Die #4
        <input type="checkbox" name="cbDie5" runat="server" onchange="toggleSave"/> Keep Die #5
        -->
        <div id="debugText" >
            <asp:Label ID="lblRound" Text="" runat="server"></asp:Label>
            <asp:Label ID="lblRoll" Text="" runat="server"></asp:Label>
        </div>


       
        <asp:Button ID="btnRollDice" runat="server" OnClick="round" Text="Roll Dice" UseSubmitBehavior="False" />
        <br />
        <asp:Button ID="btnReset" runat="server" OnClick="btnStartNew_Click" Text="New Game" UseSubmitBehavior="False" />
</div>    
  
    

    <asp:Button id="btnStartNew" runat="server" Text="New Game" OnClick="btnStartNew_Click" />
            <br />
    <p>Created by Brandon Kerber, Cole Stevens, Marshall Harris, and Josh Warnock</p> 
    </form>

   
    
    <footer id="footer">
       
    </footer>
</body>
</html>

