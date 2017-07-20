<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Splash.aspx.cs" Inherits="Yahtzee.Web.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <html>
    <head>
        <link href="Stylesheet/Website.css" rel="stylesheet" type="text/css" />
        <title>Yahtzee!</title>
    </head>
    <body>
        <div id="splash">
            <h1 id="splash_h1">Welcome to Bazinga Yahtzee (beta)</h1>
            <br />
            <br />
            <img id="splash_logo" src="Assets/yahtzee_logo.jpg" alt="Yahtzee logo"/>
            <br />
            <br />
            <asp:Button ID="play_button" runat="server" Text="Play Yahtzee" PostBackUrl="~/WebForm1.aspx"/>
        </div>
    </body>
    </html>
</asp:Content>

