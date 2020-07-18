<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="userPaymentPage.aspx.cs" Inherits="WebApplication1.UL.userPaymentPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="../Scripts/userPaymentPage.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/userPaymentPage.css?parameter = 1"/> 
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <h3 class="regHeader" style="text-align: center; color: white; text-transform: uppercase;">Please enter payment details</h3>
    <br />
    <br />
    <div class="regPageDiv">
        <br />
        <br />
        Name on Card
        <br />
        <br />
        <asp:TextBox ID="txbCardName" CssClass="txbpaymentName" runat="server"></asp:TextBox>
        <br />
        <br />
        Card Number
        <br />
        <br />
        <asp:TextBox ID="txbCardNumber" CssClass="txbpaymentName" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <div class="divCVC">
        CVC
        
        <asp:TextBox ID="txbCVC" CssClass="txbCVC" runat="server"></asp:TextBox>
        Expiry Date
        
        
        <%--Expiry Day--%>
        <asp:TextBox ID="txbExpiryDay" CssClass="txbDate" runat="server" placeholder="Day" style="width: 10%;"></asp:TextBox>
        <asp:TextBox ID="txbExpiryMonth" CssClass="txbDate" runat="server" placeholder="Month" style="width: 15%;"></asp:TextBox>
        <asp:TextBox ID="txbExpiryYear" CssClass="txbDate" runat="server" placeholder="Year" style="width: 15%;"></asp:TextBox><%--Expiry Month--%>
        </div>
        <br />
        <%--Expiry Month--%>
        <%--<asp:TextBox ID="txbExpiryMonth" CssClass="txbSearchBarStylePopup" runat="server" placeholder="Month"></asp:TextBox>--%>
        <%--Expiry Day--%>
        <%--<asp:TextBox ID="txbExpiryDay" CssClass="txbSearchBarStylePopup" runat="server" placeholder="Day"></asp:TextBox>--%>
        Amount to Spend
        <asp:TextBox ID="txbAmount" CssClass="txbSearchBarStylePopup" runat="server" ></asp:TextBox>
        Description
        <asp:TextBox ID="txbDescription" CssClass="txbSearchBarStylePopup" runat="server"></asp:TextBox>
        <br />
        <br />
        <div class="logInButtons">
                <asp:Button CssClass="registerButton" id="btnPayment" runat="server" Text="Submit Payment" />
                <asp:Button CssClass="registerButton" id="btnOkay" runat="server" Text="Make Payment With Details Above" />
        </div>
        <br/>

        <br/>
        <asp:Label ID="lblPaymentResult" Text="bottom text" runat="server"></asp:Label>
    </div>
</asp:Content>
