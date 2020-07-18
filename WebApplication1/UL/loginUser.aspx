<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="loginUser.aspx.cs" Inherits="WebApplication1.UL.loginUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="loginUser.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="logInDiv" style="font-size: 30px; background-color: #d96968; padding: 10px">
        Login
    </div>
    <div class="logInDiv">
        <br />
        <asp:Label ID="labelError" runat="server" Text="" style="color:red"></asp:Label>
        <br />
        Email Address
        <br />
        <br />
        <asp:TextBox class="textBoxesLogInReg" id="textBoxEmail" runat="server"></asp:TextBox>
        <br />
        <%-- Gives error if text box is empty --%>
        <asp:RequiredFieldValidator ID="rfdTextBoxEmail" runat="server" ControlToValidate="textBoxEmail"
            ErrorMessage="You must enter an email" Display="Dynamic" style="color:red"></asp:RequiredFieldValidator>
        <%-- Gives error if not a valid email format --%>
        <asp:RegularExpressionValidator ID="revTextBoxEmail" runat="server" ControlToValidate="textBoxEmail"
            ErrorMessage="Must be a valid email"  Display="Dynamic"
            ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" style="color:red"></asp:RegularExpressionValidator>
        <br />
        <br />
        Password
        <br />
        <br />
        <asp:TextBox class="textBoxesLogInReg" id="textBoxPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <%-- Gives error if text box is empty --%>
        <asp:RequiredFieldValidator ID="rfdTextBoxPassword" runat="server" ControlToValidate="textBoxPassword"
            ErrorMessage="You must enter a password" Display="Dynamic" style="color:red"></asp:RequiredFieldValidator>
        <%-- Gives error if password does not match criteria: Password must contain an uppercase letter, lowercase letter, number, and be 8-16 characters long --%>
        <asp:RegularExpressionValidator ID="revTextBoxPassword" runat="server" ControlToValidate="textBoxPassword"
            ErrorMessage="Password must contain an uppercase letter, lowercase letter, number, and be 8-16 characters long" Display="Dynamic"
            ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9]).{8,16}$" style="color:red"></asp:RegularExpressionValidator>
        <br />
        <br />
        <div class="logInButtons">
            <asp:Button class="registerButton" ID="btnForgotPassword" Text="Forgot Password" CausesValidation="false" runat="server" />
            <asp:Button class="registerButton" ID="btnRegister" Text="Register" CausesValidation="false" runat="server" />
            <asp:Button class="registerButton" ID="btnLogin" Text="Login" runat="server" />
        </div>
    </div>
</asp:Content>