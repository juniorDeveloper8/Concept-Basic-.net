<%@ Page Title="Datos" Language="C#" MasterPageFile="~/PagesMaster/home.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Visual_Plantilla.inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tabla de datos</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>

        <h1>Tabla de datos</h1>

        <br />

        <%--tabla de datos--%>
        <asp:GridView ID="ListUser" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgModificar" runat="server"
                            ImageUrl="~/Img/editar.png"
                            Width="32px" Height="32px"
                            CommandName="Modificar"
                            CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgEliminar" runat="server"
                            ImageUrl="~/Img/eliminar.png"
                            Width="32px" Height="32px"
                            OnClientClick="return confirm('Desea eliminar');"
                            CommandName="Eliminar"
                            CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </section>
    
</asp:Content>
