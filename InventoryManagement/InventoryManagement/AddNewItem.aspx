<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddNewItem.aspx.cs" Inherits="InventoryManagement.AddNewItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>ID
                    </td>
                    <td>
                        <asp:TextBox ID="ItemID" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name
                    </td>
                    <td>
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Batch
                    </td>
                    <td>
                        <asp:TextBox ID="Batch" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Quantity
                    </td>
                    <td>
                        <asp:TextBox ID="Quantity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="Submit" Text="Submit" OnClick="Submit_Click" runat="server" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
