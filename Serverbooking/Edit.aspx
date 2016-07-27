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
<Columns>
    <asp:Edit>
        
        <asp:LinkButton Runat="server" 
            OnClientClick="return confirm('Are you sure you?');" 
            CommandName="Delete">Delete</asp:LinkButton>
        
    </asp:Edit>
</Columns>
          </div>

                
    </form>
</body>
</html>
