<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="gridPanel" runat="server" OnDataBinding="gridPanel_DataBinding">
                <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                    SelectedRowStyle-BackColor="Black"
                    SelectedRowStyle-ForeColor="White" OnSelectedIndexChanged="gridView_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Apellido" DataField="Nombre" />
                        <asp:BoundField HeaderText="Email" DataField="Nombre" />
                        <asp:BoundField HeaderText="Usuario" DataField="Nombre" />
                        <asp:BoundField HeaderText="Habilitado" DataField="Nombre" />
                        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                    </Columns>
                 </asp:GridView>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
