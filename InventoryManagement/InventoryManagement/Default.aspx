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
            <asp:GridView ID="GridView1" runat="server" DataKeyNames="ID" AutoGenerateColumns="false" OnDataBound="GridView1_DataBound">
                <Columns>
                    <asp:BoundField DataField="Item.id" HeaderText="ItemID" />
                    <asp:BoundField DataField="Item.Name" HeaderText="Item" />
                    <asp:BoundField DataField="Batch" HeaderText="BatchNo" />
                    <asp:BoundField DataField="OpStock" HeaderText="Stock" />
                    <asp:TemplateField ControlStyle-Height="5px" ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton ID="Button1" OnClick="Button1_Click" runat="server" CommandName="AddBatch" Text="Add Batch" CommandArgument='<%# Eval("ID") %>' /><br />
                            <asp:LinkButton ID="DelBtn" OnClick="DelBtn_Click" runat="server" CommandName="AddBatch" Text="Delete Item" CommandArgument='<%# Eval("ID") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
