<%@ Page Title="" Language="C#" MasterPageFile="~/UL/nostGamesMasterPage.Master" AutoEventWireup="true" CodeBehind="landingPage.aspx.cs" Inherits="WebApplication1.UL.landingPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headMasterPage" runat="server">
    <script src="../Scripts/landingPage.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../CSS/landingPage.css?parameter = 1" />
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="250px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label CssClass="nameStyle" Text='<%# Eval("Name") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Type" HeaderStyle-Width="200px" HeaderStyle-CssClass="GVHeaders">
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

            <%--<asp:TemplateField HeaderText="Description" ItemStyle-Wrap="true" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Label ID="txtPrice" Text='<%# Eval("Description") %>' runat="server" />
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="" HeaderStyle-Width="200px" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Image CssClass="homepageImages" 
                               ID="Image" 
                               runat="server" 
                               ImageUrl='<%# Eval("ImageFile", "~/Images/{0}") %>' 
                               Height="200px"
                               Width="200px"/>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="" HeaderStyle-CssClass="GVHeaders">
                <ItemTemplate>
                    <asp:Button CssClass="btGVLandingPage" ID="btMoreInfo" runat="server" Text="More Infomation" CommandArgument='<%# Eval("ProductID") %>' OnClick="moreInfo_Clicked"/>
                    <br />
                    <br />
                    <asp:Button CssClass="btGVLandingPage" ID="btAddToCart" runat="server" Text="Add to Cart" CommandArgument='<%# Eval("ProductID") %>' OnClick="addToCart_Clicked"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
