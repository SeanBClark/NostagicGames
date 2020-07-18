<%@ Page Title="" Language="C#" MasterPageFile="~/UL/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="adminLogin.aspx.cs" Inherits="WebApplication1.UL.adminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .logPageDiv {
            width: 50%;
            margin-left: 25%;
            margin-right: 25%;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminContenctPlaceHolder" runat="server">
<br />
<br />
    <div class="logPageDiv">
        Admin Number
        <br />
        <asp:TextBox ID="txbUsername" CssClass="txbSearchBarStylePopup" runat="server" style="width:25%"></asp:TextBox>
          <br />
        <asp:Label ID="LbUsernamVal" class="LbVal" runat="server" Text="Invalid Email Address"></asp:Label>
        <br />
        <br />
        Password
        <br />
        <asp:TextBox ID="txbPassword" CssClass="txbSearchBarStylePopup" runat="server" style="width:25%"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnClear" CssClass="btnPopUp" runat="server" Text="Clear" />                
        <asp:Button ID="btnLoginAct" CssClass="btnPopUp" runat="server" Text="Login"/>
        <br />
        <br />
        <asp:Label ID="lblOutput" Text="" runat="server"></asp:Label>
    </div>

</asp:Content>
