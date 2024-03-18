<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Najava.aspx.cs" Inherits="LAB1_B.Najava" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="container">
    
      <div class="row">
        <div class="col-md-6">
           Име:
           <asp:TextBox ID="fullName" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator 
               class="text-danger"
               ID="RequiredFieldValidator1" 
               runat="server" 
               ErrorMessage="Внеси име"
               ControlToValidate="fullName">
           </asp:RequiredFieldValidator>
           
        </div>
    </div>

    <hr />


    <div class="row">
        <div class="col-md-6">
           Лозинка:
           <asp:TextBox ID="password" runat="server"></asp:TextBox>
           <asp:RequiredFieldValidator 
               class="text-danger"
               ID="PasswordFieldValidator" 
               runat="server" 
               ErrorMessage="Внеси лозинка"
               ControlToValidate="password">
           </asp:RequiredFieldValidator>
           
        
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-6">
           е-адреса:
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
            
            <asp:RequiredFieldValidator 
                class="text-danger"
                ID="EmailRequiredFieldValidator" 
                runat="server" 
                ErrorMessage="Невалиден форма" 
                ControlToValidate="email"></asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator 
                class="text-danger"
                ID="EmailRegularExpressionValidator" 
                runat="server" 
                ErrorMessage="Невалиден формат" 
                ControlToValidate="email" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
   
        </div>
    </div>

    <hr />

    <div class="row">
        <div class="col-md-6">
            <asp:Button ID="addInfo" runat="server" Text="Најавете се" OnClick="addInfo_Click" />
        </div>

    </div>
</div>
</asp:Content>
