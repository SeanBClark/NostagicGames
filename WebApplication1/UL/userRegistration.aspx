<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="userRegistration.aspx.cs" Inherits="WebApplication1.UL.userRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="../Scripts/userRegistration.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <asp:TextBox ID="txbPassword" CssClass="txbSearchBarStylePopup" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        Re-Enter Password
        <br />
        <asp:TextBox ID="txbRePassword" CssClass="txbSearchBarStylePopup" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <asp:Label ID="matchError" runat="server" Text="Passwords do not match" style="color: red;"></asp:Label>
        <br />
        <asp:Label ID="lbPassVal" runat="server" Text="Password Requires at least one lower case letter, one upper case letter, one digit, 6-13 length, and no spaces." style="color: red;"></asp:Label>
        <br />
<%--        <div id="adminCode">
            Administrator Code 
            <br />
            <asp:TextBox ID="txbAdminCode" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lbCodeVal" runat="server" Text="Must be Numeric" style="color: red;"></asp:Label>
            <br />
        </div>--%>
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
<%--            <br />
            <div id="btnAdmin">
            <asp:Button class="btnReg" 
                        ID="btnRegAdmin" 
                        runat="server" 
                        Text="Register Administrator Account" 
                        OnClientClick="showAdminCodeDiv(); return false;" 
                        CausesValidation="false" 
                        AutoPostBack="False"
            />
            </div>
            <div id="btnUser">
            <asp:Button class="btnReg" 
                        ID="btnRegUser" 
                        runat="server" 
                        Text="Register User Account" 
                        OnClientClick="hideAdminCodeDiv(); return false;" 
                        CausesValidation="false" 
                        AutoPostBack="False"
            />
            </div>--%>
            <%--<button class="btnReg" id="btnRegAdmin">Register Administrator Account</button>--%>
            <%--<button class="btnReg" id="btnRegUser">Register User Account</button>--%>
            <br />
            <br />
            <br />
        </div>
    </div>
</asp:Content>
