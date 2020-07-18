<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="resetPassword.aspx.cs" Inherits="WebApplication1.UL.resetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headMasterPage" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <h2 style="text-align: center;">Reset Password</h2>
    <br />
    <div class="overlay-content">
        Email Address
        <br />
        <asp:TextBox ID="txbUsername" CssClass="txbSearchBarStylePopup" runat="server" style="width:25%"></asp:TextBox>
          <br />
        <%--<asp:Label ID="LbUsernamVal" class="LbVal" runat="server" Text="Invalid Email Address"></asp:Label>--%>
        <br />
        <br />        
        <asp:Button ID="btnClear" CssClass="btnPopUp" runat="server" Text="Clear" />                
        <asp:Button ID="btnLoginAct" CssClass="btnPopUp" runat="server" Text="Send Email"/>        
    </div>

</asp:Content>
