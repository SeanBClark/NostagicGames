<%@ Page Title="" Language="C#" MasterPageFile="~/UL/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="managerProductsAdmin.aspx.cs"  Inherits="WebApplication1.managerProductsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="managerProductsAdmin.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentPlaceHolder" ContentPlaceHolderID="adminContenctPlaceHolder" runat="server">
<br />
<br />

    <asp:GridView HorizontalAlign="Center" CellPadding="1" ID="GVProducts" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="ProductID" ShowHeaderWhenEmpty="true" OnRowCommand="GVProducts_RowCommand" OnRowEditing="GVProducts_RowEditing" AlternatingRowStyle-Wrap="true" OnRowCancelingEdit="GVProducts_RowCancelingEdit" OnRowUpdating="GVProducts_RowUpdating" OnRowDeleting="GVProducts_RowDeleting">

        <alternatingrowstyle backcolor="#dcdcdc" />
        <footerstyle backcolor="#cccccc" forecolor="black"/>
        <headerstyle backcolor="#000084" font-bold="true" forecolor="white" />
        <pagerstyle backcolor="#999999" forecolor="black" horizontalalign="center"/>
        <rowstyle backcolor="#eeeeee" forecolor="black"/>
        <selectedrowstyle backcolor="#008a8c" font-bold="true" forecolor="white" />
        <sortedascendingcellstyle backcolor="#f1f1f1" />
        <sortedascendingheaderstyle backcolor="#0000a9" />
        <sorteddescendingcellstyle backcolor="#cac9c9" />
        <sorteddescendingheaderstyle backcolor="#000065" />

        <Columns>
            <asp:TemplateField HeaderText="Name" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Name") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtName" Text='<%# Eval("Name") %>' runat="server" Width="85px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtNameFooter" runat="server" Width="85px" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="100px">
                 <ItemTemplate>
                    <asp:Label Text='<%# Eval("CategoryID") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtCategory" Text='<%# Eval("CategoryID") %>' runat="server" Width="30px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:DropDownList ID="ddlCategoryFooter" runat="server" Width="110px" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Type" HeaderStyle-Width="100px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Type") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtType" Text='<%# Eval("Type") %>' runat="server" Width="85px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtTypeFooter" runat="server" Width="85px" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Platform" HeaderStyle-Width="120px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Platform") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPlatform" Text='<%# Eval("Platform") %>' runat="server" Width="85px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtPlatformFooter" runat="server" Width="85px" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Amount Available" HeaderStyle-Width="160px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("AmountAvailable") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtAmountAvailable" Text='<%# Eval("AmountAvailable") %>' runat="server" Width="30px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="30px" ID="txtAmountAvailableFooter" runat="server"/>
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Price" HeaderStyle-Width="60px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Price") %>' runat="server" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtPrice" Text='<%# Eval("Price") %>' runat="server" Width="30px" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox Width="30px" ID="txtPriceFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Description" ItemStyle-Wrap="true">
                <ItemTemplate>
                    <asp:TextBox Text='<%# Eval("Description") %>' runat="server" TextMode="MultiLine" ReadOnly="True" BackColor="#eeeeee" Width="150px" Height="46px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtDescription" Text='<%# Eval("Description") %>' runat="server" Width="150px" Height="36px" TextMode="MultiLine" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtDescriptionFooter" runat="server" Wrap="true" TextMode="MultiLine" Width="150px" Height="36px" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Image File">
                <ItemTemplate>
                    <asp:TextBox Text='<%# Eval("ImageFile") %>' runat="server" TextMode="MultiLine" ReadOnly="True" BackColor="#eeeeee" Width="150px" Height="46px" />
                    
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fileImgSave" runat="server" />
                    <asp:Label ID="Label1" runat="server" Text= '<%# Eval("ImageFile") %>'></asp:Label>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:FileUpload ID="fileImgSaveFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/Images/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px"/>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/Images/addnew.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                </FooterTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblSuccess" Text="" runat="server" ForeColor="Black" Font-Bold="true"/>
</asp:Content>
