<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="regThankYou.aspx.cs" Inherits="WebApplication1.UL.regThankYou" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="userRegistration.js" type="text/javascript"></script>
    <style>
        .ThankYouPageDiv {
            width: 50%;
            margin-left: 25%;
            margin-right: 25%;
            text-align: center;
            margin-top:10%;
            font-size: 100px;
            font-weight:bold;
        }
    </style>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <div class="ThankYouPageDiv">
    Thank You For Registering!
    </div>
</asp:Content>
