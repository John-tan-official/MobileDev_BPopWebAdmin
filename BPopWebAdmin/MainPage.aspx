<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="BPopWebAdmin.MainPage" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BPopAdmin</title>
    <style>
        .SL {
            margin: 30px auto;
            width: 1000px;
        }
        table, td, th {
            padding: 0 50px;
            margin: auto;
            width: auto;
            border-collapse: collapse;
            border: 1px solid black;
        }
        .TBC{
            width: 900px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="SL">
            <asp:Button ID="btn_startGame" runat="server" Text="START THE GAME" OnClick="btn_startGame_Click" />
        </div>
        <div class="SL">
            <asp:Literal ID="UsersLiteral" runat="server"></asp:Literal>
        </div>
        <div class="SL">
            Add New Questions and Answers: <br />
            <asp:TextBox CssClass="TBC" ID="Question" placeholder="Question" runat="server"></asp:TextBox><br />
            <asp:TextBox CssClass="TBC" ID="ChoiceA" placeholder="ChoiceA"  runat="server"></asp:TextBox><br />
            <asp:TextBox CssClass="TBC" ID="ChoiceB" placeholder="ChoiceB" runat="server"></asp:TextBox><br />
            <asp:TextBox CssClass="TBC" ID="ChoiceC" placeholder="ChoiceC" runat="server"></asp:TextBox><br />
            <asp:TextBox CssClass="TBC" ID="ChoiceD" placeholder="ChoiceD" runat="server"></asp:TextBox><br />
            <asp:TextBox CssClass="TBC" ID="Answer" placeholder="Answer" runat="server"></asp:TextBox><br />
            <asp:Button ID="btn_submitQandA" runat="server" Text="Add" OnClick="btn_submitQandA_Click" />
        </div>
        <div class="SL">            
            <asp:Literal ID="QuestionsLiteral" runat="server"></asp:Literal>
        </div>
    </form>
</body>
</html>
