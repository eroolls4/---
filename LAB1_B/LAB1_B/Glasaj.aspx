<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Glasaj.aspx.cs" Inherits="LAB1_B.Glasaj" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

   <asp:Image ID="Image1" runat="server" 
        ImageUrl="https://www.finki.ukim.mk/sites/default/files/styles/large/public/default_images/finki_52_1_2_1_62_0.png?itok=miZDgQ_6" />
    <br />

    <asp:Label ID="professorName" runat="server" Text=""></asp:Label>

    <br />

    <asp:ListBox ID="lbSubject" runat="server" OnSelectedIndexChanged="subject_SelectedIndexChanged" AutoPostBack="True"></asp:ListBox>
    <asp:ListBox ID="lbCredit" runat="server" AutoPostBack="True"></asp:ListBox>

   
    <br />
    <asp:Button ID="addSubject" runat="server" Text="Гласај" OnClick="addSubject_Click" />

    

    <hr />

    Subject: <br />
    <asp:TextBox ID="tbSubject" runat="server"></asp:TextBox>

    <br />
    Credit:
    <br />
    <asp:TextBox ID="tbCredit" runat="server"></asp:TextBox>

    <br />
    <asp:Button ID="addNewSubject" runat="server" Text="Add Subject" OnClick="addNewSubject_Click" />
    <br />
    <asp:Button ID="removeSubject" runat="server" Text="Remove Subject" OnClick="removeSubject_Click" />

</asp:Content>
