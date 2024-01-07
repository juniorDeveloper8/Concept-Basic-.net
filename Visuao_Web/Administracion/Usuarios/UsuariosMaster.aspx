<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuariosMaster.aspx.cs" Inherits="Visuao_Web.Administracion.Usuarios.UsuariosMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section>
        <h1>TABLA DE USUARIOS</h1>

        <asp:GridView ID="gdvUsuarios" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gdvUsuarios_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgModificar" runat="server"
                            ImageUrl="~/Imagens/editar.png"
                            Width="32px" Height="32px"
                            CommandName="Modificar"
                            CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgEliminar" runat="server"
                            ImageUrl="~/Imagens/eliminar.png"
                            Width="32px" Height="32px"
                            OnClientClick="return confirm('Desea eliminar');"
                            CommandName="Eliminar"
                            CommandArgument='<%# Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>

        <br />

        <br />

        <div>
        </div>
    </section>

</asp:Content>
