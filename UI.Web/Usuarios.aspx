﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
                SelectedRowStyle-BackColor="Black"
                SelectedRowStyle-ForeColor="White"
                DataKeyNames="ID" DataSourceID="SqlDataSource1" >
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                    <asp:BoundField HeaderText="EMail" DataField="EMail" />
                    <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                    <asp:BoundField HeaderText="Habilitado" DataField="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server" OnLoad="formPanel_Load">
            <asp:Label ID="nombreLabel" runat="server" Text="Nombre: "></asp:Label>
            <asp:TextBox ID="nombreTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: "></asp:Label>
            <asp:TextBox ID="apellidoTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="emailLabel" runat="server" Text="EMail: "></asp:Label>
            <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: "></asp:Label>
            <asp:CheckBox ID="habilitadoCheckBox" runat="server" /><br />
            <asp:Label ID="nombreUsuarioLabel" runat="server" Text="Usuario: "></asp:Label>
            <asp:TextBox ID="nombreUsuarioTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="claveLabel" runat="server" Text="Clave: "></asp:Label>
            <asp:TextBox ID="claveTextBox" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="retetirClaveLabel" runat="server" Text="Repetir Clave: "></asp:Label>
            <asp:TextBox ID="repetirClaveTextBox" TextMode="Password" runat="server"></asp:TextBox>
            <br />
        </asp:Panel>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" OnClick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formActionsPanel" runat="server">
            <asp:LinkButton ID="aceptarLinkButton" runat="server" OnClick="aceptarLinkButton_Click">Aceptar</asp:LinkButton>
            <asp:LinkButton ID="cancelarLinkButton" runat="server">Cancelar</asp:LinkButton>
        </asp:Panel>
    </form>
</body>
</html>
