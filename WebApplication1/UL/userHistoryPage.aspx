<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="userHistoryPage.aspx.cs" Inherits="WebApplication1.UL.userHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="userHistoryPage.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="aboutHeader" style="text-align: center; padding: 2%">Account History</h3>
 <div id="fiv"></div>   
    <asp:GridView   HorizontalAlign="Center" 
                    CellPadding="1" 
                    ID="GVProducts" 
                    runat="server" 
                    AutoGenerateColumns="false" 
                    ShowFooter="false" 
                    DataKeyNames="ProductID" 
                    ShowHeaderWhenEmpty="true"
                    CssClass="gridViewOverAll">
        <Columns>
            <asp:TemplateField HeaderText="Order ID" HeaderStyle-Width="250px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label CssClass="nameStyle" Text='<%# Eval("OrderID") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product ID" HeaderStyle-Width="200px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("ProductID") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="120px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Quantity") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Total Order" HeaderStyle-Width="80px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("OrderTotal") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

</asp:Content>
