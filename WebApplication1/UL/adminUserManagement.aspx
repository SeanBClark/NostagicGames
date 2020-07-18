<%@ Page Title="" Language="C#" MasterPageFile="~/UL/adminMasterPage.Master" AutoEventWireup="true" CodeBehind="adminUserManagement.aspx.cs" Inherits="WebApplication1.UL.adminUserManagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="adminContenctPlaceHolder" runat="server">
    <br />
    <br />
    <asp:GridView HorizontalAlign="Center" CellPadding="1" ID="GVUsers" runat="server" AutoGenerateColumns="false" ShowHeaderWhenEmpty="true" DataKeyNames="UserID" OnRowEditing="GVUsers_RowEditing" OnRowCancelingEdit="GVUsers_RowCancelingEdit" OnRowUpdating="GVUsers_RowUpdating">
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
            <asp:TemplateField HeaderText="User ID" HeaderStyle-Width="80px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("UserID") %>' runat="server" Width="80px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtUserID" Text='<%# Eval("UserID") %>' runat="server" Width="80px" />
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Email" HeaderStyle-Width="230px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Email") %>' runat="server" Width="230px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" Width="85px" />
                </EditItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Status" HeaderStyle-Width="160px">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Status") %>' runat="server" Width="110px" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlStatus" Text='<%# Eval("Status") %>' runat="server" Width="110px">
                        <asp:ListItem Text="Active" Value="Active"></asp:ListItem>
                        <asp:ListItem Text="Suspended" Value="Suspended"></asp:ListItem>
                    </asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px"/>
                </ItemTemplate>
                 <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px"/>
                    <asp:ImageButton ImageUrl="~/Images/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px"/>
                 </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>
</asp:Content>
