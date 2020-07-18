<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="cartPage.aspx.cs" Inherits="WebApplication1.UL.cartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="cartPage.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="cartPage">
        <%-- Cart Count is updated by session data --%>
        <asp:Label ID="labelCartCount" Text="" runat="server" Style="Color:white"></asp:Label>
        <%-- Gridview of a hardcoded data table. Datatable can be replaced by an auto generated SQL datatable for part 2 --%>
        <asp:GridView ID="gvCart" AutoGenerateColumns="false" Style="background-color:white;width:100%" runat="server">
            <Columns>
                <asp:BoundField DataField="ProductID" HeaderText="ID"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                <asp:BoundField DataField="Name" HeaderText="Name"/>
                <asp:BoundField DataField="Type" HeaderText="Type"/>
                <asp:BoundField DataField="Platform" HeaderText="Platform"/>
                <asp:BoundField DataField="Price" HeaderText="Price"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%-- Passes name of item to a function, will be useful for part 2 --%>
                        <asp:LinkButton ID="lnkView" Text="View" runat="server" CommandArgument='<%# Eval("ProductID") %>' OnClick="lnkView_Clicked"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%-- Passes ID of item to a function. ID is used to remove the specific item from the cart in session data --%>
                        <asp:LinkButton ID="lnkRemove" Text="Remove" runat="server" CommandArgument='<%# Eval("ProductID") %>' OnClick="lnkRemove_Clicked"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <br />

        <div class="logInButtons">
                <%-- Clear completely renews the cart session data --%>
                <asp:Button CssClass="registerButton" id="clearButton" runat="server" Text="Clear" />
                <asp:Button CssClass="registerButton" id="checkoutButton" runat="server" Text="Procede to Checkout" />
        </div>
        <br />
        <asp:Label ID="NoItemsInCart" Text="No Items In Cart" runat="server"></asp:Label>
    </div>
</asp:Content>