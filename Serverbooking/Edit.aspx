<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Edit" %>
<%@ Assembly="Html.Encode(Model.InfoServer" %>
<!DOCTYPE html>

<html >
<head runat="server">
    <title>Server Information</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="width">
            <asp: GridView IF="edit" runat="server"
                AutoGenerateColumns="False" 
                CssClass="grid"
                ShowFooter="True"
                AutoGenerateEditButton="false"
                AllowPaging="True" PageSize="5"
                OnRowEditing="GridView_RowEditing" 
                OnRowCancelingEdit="GridView_RowCancelingEdit"
                OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowUpdating="GridView1_RowUpdating"
                OnRowDeleting="GridView1_RowDeleting">
                <columns>
                    <asp:TemplateField HeaderText="ServerID">
                    <itemTemplate><asp:Label ID="lblServerID" width"70px"
                        text='<%#Eval("ServerID") runat="server"> %>'</asp:Label></itemTemplate>
                    </asp:>
                                        <asp:TemplateField HeaderText="ServerID">
                        <ItemTemplate> <%#Eval("ServerID")%> </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEd_Book" Width="200px" Text='<%#Eval("BookName")%>' CssClass="txt" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbBookName" Width="200px" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category">
                        <ItemTemplate> <%#Eval("Category")%> </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEd_Cate" Width="100px" Text='<%#Eval("Category")%>' CssClass="txt" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbCategory" Width="100px" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate> <%#Eval("Price")%> </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="tbEd_Price" Width="100px" Text='<%#Eval("Price")%>' CssClass="txt" runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox ID="tbPrice" Width="100px" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate></ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btInsert" runat="server" Text="Insert Record" 
                                OnClientClick="return validate(this);"
                                OnClick="InsertRecord" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    < <%--SHOW THE EDIT AND DELETE BUTTON IN EVERY ROW.--%>
                    <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
          </div>
    </div>
                
    </form>
</body>
</html>
