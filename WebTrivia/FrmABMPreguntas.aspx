<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPagePrincipal.master" AutoEventWireup="true" CodeFile="FrmABMPreguntas.aspx.cs" Inherits="FrmABMPreguntas" %>

<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
    .style6
    {
            width: 69px;
            text-align: right;
        }
    .style8
    {
        width: 171px;
    }
    .style10
    {
        width: 69px;
        text-align: left;
    }
        .style11
        {
            width: 96px;
        }
        .style13
        {
            width: 66px;
        }
        .style14
        {
            width: 196px;
        }
    .style15
    {
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            Preguntas</td>
        <td class="style8"> 
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label1" runat="server" Text="Numero"></asp:Label>
        </td>
        <td class="style8">
            <asp:TextBox ID="txtNumero" runat="server" 
                ontextchanged="txtNumero_TextChanged" AutoPostBack="True"></asp:TextBox>
        </td>
        <td class="style8">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label2" runat="server" Text="Texto"></asp:Label>
        </td>
        <td class="style8" colspan="2">
            <asp:TextBox ID="txtPregunta" runat="server" Height="62px" TextMode="MultiLine" 
                Width="293px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            <asp:Label ID="Label3" runat="server" Text="Tipo"></asp:Label>
&nbsp;</td>
        <td class="style8" colspan="2">
            <asp:RadioButtonList ID="rbdListTipo" runat="server">
                <asp:ListItem>Geografia</asp:ListItem>
                <asp:ListItem>Ciencia</asp:ListItem>
                <asp:ListItem>Deporte</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            Respuestas</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style10">
            Correcta</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6" rowspan="3">
            <asp:RadioButtonList ID="rbdlistCorrecta" runat="server" 
                style="text-align: center">
                <asp:ListItem Value="rbd1">--&gt;</asp:ListItem>
                <asp:ListItem Value="rbd2">--&gt;</asp:ListItem>
                <asp:ListItem Value="rbd2">--&gt;</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td class="style8" colspan="2">
            <asp:TextBox ID="txtRespuesta1" runat="server" Width="245px"></asp:TextBox>
        </td>
        <td valign="top">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:TextBox ID="txtRespuesta2" runat="server" Height="22px" Width="240px"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style8" colspan="2">
            <asp:TextBox ID="txtRespuesta3" runat="server" Width="239px" 
                ></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style8" colspan="2">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style14">
            &nbsp;</td>
        <td class="style6">
            &nbsp;</td>
        <td class="style15" colspan="2">
            <asp:Button ID="btnAgregar" runat="server" Height="25px" Text="Agregar" 
                Width="73px" onclick="Button1_Click" />
            <asp:Button ID="btnModificar" runat="server" onclick="btnModificar_Click" 
                Text="Modificar" />
            <asp:Button ID="btnBaja" runat="server" onclick="btnBaja_Click" Text="Borrar" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>

