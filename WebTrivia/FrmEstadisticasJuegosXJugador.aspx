<%@ Page Title=""  Language="C#" MasterPageFile="~/MasterPagePrincipal.master" AutoEventWireup="true" CodeFile="FrmEstadisticasJuegosXJugador.aspx.cs" Inherits="FrmEstadisticasJuegosXJugador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style9
        {
            width: 316px;
        }
        .style10
        {
            width: 55px;
        }
        .style11
        {
            width: 396px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                Estadisticas de juegos por jugadores</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                <asp:Repeater ID="Repeater1" runat="server" >
                  
                        
                   <HeaderTemplate>
                   <table>
                    <tr>
                          <td><asp:Label ID="Doc" runat="server" Text="Documento"></asp:Label></td>
                         <td><asp:Label ID="No" runat="server" Text="Nombre"></asp:Label></td>               
                         <td><asp:Label ID="NombreP" runat="server" Text="Nombre Publico"></asp:Label></td>
                  
                         </tr>
                         </table>
                   </HeaderTemplate>
                <itemtemplate>


                        <table>
                        
                         <tr>
                         <td><asp:Label ID="Documento" runat="server" Text='<%#Eval("Documento") %>'></asp:Label></td>
                         <td><asp:Label ID="Nombre" runat="server" Text='<%#Eval("Nombre") %>'></asp:Label></td>
                         <td><asp:Label ID="NombrePublico" runat="server" Text='<%#Eval("NomPublico") %>'></asp:Label></td>
                        <td>
                        <asp:LinkButton ID="repeater" OnCommand="repeater_OnCommand"  CommandArgument='<%# Eval("Documento")%>' runat="server" Text="Juegos..."></asp:LinkButton></td>
                         </tr>
                        
                </table>

                    </itemtemplate>

                </asp:Repeater>
            </td>
            <td class="style11">
                <asp:Repeater ID="RepJuegos" runat="server">


                  <HeaderTemplate>
                   <table>
                    <tr>
                          <td><asp:Label ID="Doc" runat="server" Text="Numero"></asp:Label></td>
                         <td><asp:Label ID="No" runat="server" Text="FechaHoraInicio"></asp:Label></td>               
                         <td><asp:Label ID="NombreP" runat="server" Text="FechaHoraFin"></asp:Label></td>
                   <td><asp:Label ID="Label2" runat="server" Text="Movimientos"></asp:Label></td>
                         </tr>
                         </table>
                   </HeaderTemplate>
                    <itemtemplate>


                         <table>
                         <tr>

                         <td><asp:Label ID="Documento" runat="server" Text='<%#Eval("Numero") %>'></asp:Label></td>
                         <td><asp:Label ID="Nombre" runat="server" Text='<%#Eval("FechaHoraInicio") %>'></asp:Label></td>
                         <td><asp:Label ID="NombrePublico" runat="server" Text='<%#Eval("FechaHoraFinal") %>'></asp:Label></td>
                         <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("CantMovimientos") %>'></asp:Label></td>
                        <td>
                        <asp:LinkButton ID="repeaterj" OnCommand="repeaterj_OnCommand"  CommandArgument='<%# Eval("Numero")%>' runat="server" Text="Preguntas..."></asp:LinkButton></td>
                         </tr>
                         </table>


                    </itemtemplate>



                </asp:Repeater>
            </td>
            <td>
                <asp:Repeater ID="RepPreguntas" runat="server">


                 <HeaderTemplate>
                   <table>
                    <tr>
                          <td><asp:Label ID="Doc" runat="server" Text="Numero"></asp:Label></td>
                         <td><asp:Label ID="No" runat="server" Text="Texto"></asp:Label></td>               
                         <td><asp:Label ID="NombreP" runat="server" Text="Tipo"></asp:Label></td>
              
                         </tr>
                         </table>
                   </HeaderTemplate>

                  <itemtemplate>


                         <table>
                         <tr>

                         <td><asp:Label ID="Numero" runat="server" Text='<%#Eval("Numero") %>'></asp:Label></td>
                         <td><asp:Label ID="Texto" runat="server" Text='<%#Eval("Texto") %>'></asp:Label></td>
                         <td><asp:Label ID="Tipo" runat="server" Text='<%#Eval("Tipo") %>'></asp:Label></td>
                      
                       </tr>
                         </table>


                    </itemtemplate>
                </asp:Repeater>
            </td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10">
                &nbsp;</td>
            <td class="style9">
                &nbsp;</td>
            <td class="style11">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

