<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.master" AutoEventWireup="true" CodeFile="FrmABMAdministradores1.aspx.cs" Inherits="FrmABMAdministradores1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
        width: 113px;
    }
        .style9
        {
            width: 671px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            Administradores</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label1" runat="server" Text="Documento"></asp:Label>
        </td>
        <td class="style9">
            <asp:TextBox ID="txtDocumento" runat="server" AutoPostBack="True" 
                ontextchanged="txtDocumento_TextChanged" Width="143px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
        </td>
        <td class="style9">
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label3" runat="server" Text="Contrasena"></asp:Label>
        </td>
        <td class="style9">
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label4" runat="server" Text="Nombre"></asp:Label>
        </td>
        <td class="style9">
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            <asp:CheckBox ID="chkEstadisticas" runat="server" 
                Text="Generador de estadisticas" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            <asp:Button ID="btnAlta" runat="server" onclick="btnAlta_Click" 
                Text="Agregar" />
            <asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" Text="Borrar" />
            <asp:Button ID="btnModificacion" runat="server" onclick="btnModificacion_Click" 
                Text="Modificar" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style9">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

