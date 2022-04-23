<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.master" AutoEventWireup="true" CodeFile="FrmUsuarioBaseDeDatos.aspx.cs" Inherits="FrmUsuarioBaseDeDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            height: 40px;
        }
        .style10
        {
        }
        .style11
        {
            height: 40px;
            }
        .style14
        {
            width: 245px;
        }
        .style15
        {
            height: 40px;
            width: 245px;
        }
        .style16
        {
            width: 146px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%;">
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style10" colspan="2">
                Usuario de logueo y base de datos</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                <asp:Label ID="Label2" runat="server" Text="Contrasena"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                <asp:Label ID="Label4" runat="server" Text="Roles de Servidor"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpRoles" runat="server" Height="16px" Width="129px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                <asp:Label ID="Label3" runat="server" Text="Permisos BD"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="drpPermisos" runat="server" Height="16px" Width="130px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style14">
                &nbsp;</td>
            <td class="style16">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCrear" runat="server" onclick="btnCrear_Click" 
                    Text="Crear Nuevo" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style15">
            </td>
            <td class="style11" colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style9">
            </td>
        </tr>
    </table>
</asp:Content>

