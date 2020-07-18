<%@ Page Title="" Language="C#" MasterPageFile="~/UL/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="adminRegistration.aspx.cs" Inherits="WebApplication1.UL.adminRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="userRegistration.js" type="text/javascript"></script>
    <style>
        .regPageDiv {
            width: 50%;
            margin-left: 25%;
            margin-right: 25%;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="adminContenctPlaceHolder" runat="server">
    <br />
    <br />
    <div class="regPageDiv">
        
        <p class="regHeader">Register Account</p>

        <br />
        Email Address
        <br />
        <asp:TextBox ID="txbUsername" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>       
        <asp:Label ID="LbUsernamVal" CssClass="regErrors" runat="server" Text="Invalid Email Address"></asp:Label>
        <br />
        <br />
        Password
        <br />
        <asp:TextBox ID="txbPassword" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
        <br />
        <br />
        Re-Enter Password
        <br />
        <asp:TextBox ID="txbRePassword" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="matchError" runat="server" Text="Passwords do not match" style="color: red;"></asp:Label>
        <br />
        <asp:Label ID="lbPassVal" runat="server" Text="Password requires one lower case letter, one upper case letter, one digit, 6-13 length, and no spaces! " style="color: red;"></asp:Label>
        <br />
        Administrator Code 
        <br />
        <asp:TextBox ID="txbAdminCode" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbCodeVal" runat="server" Text="Must be Numeric" style="color: red;"></asp:Label>
        <br />
        
        <%--<asp:Panel ID="bxAdminCode" runat="server">
        Administrator Code 
        <br />
        <asp:TextBox ID="txbAdminCode" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lbCodeVal" runat="server" Text="Must be Numeric" style="color: red;"></asp:Label>
        <br />
        </asp:Panel>--%>

        <div class="logInButtons">
            <asp:Button class="btnRegLeft" ID="btnClear" runat="server" Text="Clear" CausesValidation="false" />
            <asp:Button class="btnRegRight" ID="btnContinue" runat="server" Text="Continue" />
            <br />
            <asp:Label ID="lblThankYou" Text="Successfully Registered!" runat="server"></asp:Label>
            <br />
            <%--<button class="btnReg" id="btnRegAdmin">Register Administrator Account</button>--%>
            <%--<button class="btnReg" id="btnRegUser">Register User Account</button>--%>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
