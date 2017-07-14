<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventoryManagement.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Add_Btn" runat="server" Text="Add Item" OnClick="Add_Btn_Click" /><br />
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ItemID" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ItemID" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Item" />
                    <asp:BoundField DataField="BatchNo" HeaderText="BatchNo" />
                    <asp:BoundField DataField="Stock" HeaderText="Stock" />
                    <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="Button1" OnClick="Button1_Click" runat="server" CommandName="AddBatch" Text="Add Batch" CommandArgument='<%# Eval("ItemID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
