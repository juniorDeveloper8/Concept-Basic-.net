<%@ Page Title="Datos"  Language="C#" MasterPageFile="~/PagesMaster/home.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Visual_Plantilla.PagesAspx.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Tabla de datos</title>
    <style>
        .table-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 80vh;
        }

        .custom-table {
            width: 80%;
            margin: 0 auto;
        }

            .custom-table th,
            .custom-table td {
                text-align: center;
            }

            .custom-table img {
                max-width: 100%;
                height: auto;
            }

            .custom-table .btn {
                padding: 5px 10px;
                font-size: 14px;
            }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <h1 class="text-center">Tabla de datos</h1>
        <br />
        <div class="table-container">

            <%--tabla de datos--%>
            <asp:GridView ID="ListUser" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
                    <%-- Otras columnas --%>
                    <asp:TemplateField HeaderText="Acciones">
                        <%-- Boton editar --%>

                        <ItemTemplate>
                            <asp:ImageButton
                                ID="lnkEdit"
                                runat="server"
                                ImageUrl="~/Img/editar.png"
                                Width="32px" Height="32px"
                                CommandName="Editar"
                                CommandArgument='<%# Eval("id") %>'
                                OnClick="lnkEdit_Click" />
                        </ItemTemplate>

                    </asp:TemplateField>

                    <asp:TemplateField>
                        <%-- Boton eliminar --%>

                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server"
                                ImageUrl="~/Img/eliminar.png"
                                Width="32px" Height="32px"
                                OnClick="lnkEliminar_Click"
                                CommandName="Eliminar"
                                CommandArgument='<%# Eval("id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>
        </div>
    </section>

</asp:Content>