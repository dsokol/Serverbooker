<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Serverbooking.EditTheDataaspx" %>
Edit <%@ Assembly="Html.Encode(Model.InfoServer" %>
<!DOCTYPE html>

<html >
<head runat="server">
    <title>Server Information</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
        <th>
           ServerID
        </th>
        <th>
           Status
        </th>
        <th>
           ServerName
        </th>
        <th>
           Environment
        </th>
        <th>
           ActiveBookingID
        </th>

    </tr>
                <tr>
            <td>
                <%Html32TextWriter.Textbox("ServerID")%>
                <%Html.ValidationMessage("ServerID", "*")%>
            </td>
            <td>
                @item.Status
            </td>
            <td>
                @item.ServerName
            </td>
            <td>
                @item.Environment
            </td>
            <td>
                @item.ActiveBookingID
            </td>
            <td>
                
            </td>
        
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
