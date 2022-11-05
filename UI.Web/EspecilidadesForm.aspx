<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EspecilidadesForm.aspx.cs" Inherits="UI.Web.EspecilidadesForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:GridView ID="GridView1" runat="server" Height="173px" Width="579px">
        </asp:GridView>
        <asp:Button ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" Text="Buscar" />
        <asp:TextBox ID="TextDNI" runat="server" Width="330px"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="DNI"></asp:Label>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
