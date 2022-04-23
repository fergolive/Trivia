<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.master" AutoEventWireup="true" CodeFile="FrmRegistroJugador.aspx.cs" Inherits="FrmRegistroJugador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style4
        {
            height: 15px;
        }
        .style5
        {
            height: 25px;
        }
        .style6
        {
        }
        .style7
        {
            height: 15px;
            width: 126px;
            text-align: right;
        }
        .style8
        {
            height: 25px;
            width: 126px;
            text-align: right;
        }
        .style9
        {
            width: 126px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%; height: 235px;">
        <tr>
            <td>
                &nbsp;</td>
            <td class="style6" colspan="2">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style6" colspan="2">
                Registro de Usuarios</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style6">
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
                <asp:Label ID="Label4" runat="server" Text="Documento : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDocumento" runat="server" Width="156px" AutoPostBack="True" 
                    ontextchanged="txtDocumento_TextChanged"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4">
            </td>
            <td class="style7">
                <asp:Label ID="Label2" runat="server" Text="Usuario :"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtUser" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td class="style4">
            </td>
        </tr>
        <tr>
            <td class="style5">
            </td>
            <td class="style8">
                <asp:Label ID="Label1" runat="server" Text="Contraseña :"></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="txtPass" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td class="style5">
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="Label3" runat="server" Text="Nombre completo :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="Label5" runat="server" Text="Nombre publico : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtNomPublico" runat="server" Width="156px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button2" runat="server" Text="Volver" />
            </td>
            <td class="style6">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnAgregar" runat="server" Text="Registrar" 
                    onclick="Button1_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

