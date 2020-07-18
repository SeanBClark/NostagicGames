<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="moreInfoPage.aspx.cs" Inherits="WebApplication1.UL.moreInfoPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headMasterPage" runat="server">
    <link href="../CSS/landingPage.css?parameter = 1" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    
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
            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="120px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label CssClass="nameStyle" Text='<%# Eval("Name") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Type" HeaderStyle-Width="100px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Type") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Platform" HeaderStyle-Width="120px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Platform") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="80px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Price") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" ItemStyle-Wrap="true" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label ID="txtPrice" Text='<%# Eval("Description") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <%--<asp:TemplateField HeaderText="" HeaderStyle-Width="200px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Image CssClass="homepageImagesDes" 
                               ID="Image" 
                               runat="server" 
                               ImageUrl='<%# Eval("ImageFile", "~/Images/{0}") %>' 
                               Height="400px"
                               Width="400px"/>
                </ItemTemplate>
            </asp:TemplateField>--%>

            <%--<asp:TemplateField HeaderText="" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Button CssClass="btGVLandingPage" ID="btAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' OnClick="addToCart_Clicked "/>
                </ItemTemplate>
            </asp:TemplateField>--%>
        </Columns>
    </asp:GridView>

</asp:Content>
