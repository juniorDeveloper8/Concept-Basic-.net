<%@ Page Title="" Language="C#" MasterPageFile="~/PagesMaster/Registro.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Visual_Plantilla.PagesAspx.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main class="content">
    <div class="container-fluid p-3">
        <h1>Insertar Nuevo Usuario</h1>
        <div class="row">
            <div class="col-md-6">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control mb-3" placeholder="Nombre"></asp:TextBox>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control mb-3" placeholder="Apellido"></asp:TextBox>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control mb-3" placeholder="Usuario"></asp:TextBox>
                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control mb-3" placeholder="Clave"></asp:TextBox>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control mb-3" placeholder="Correo"></asp:TextBox>

                <asp:DropDownList ID="ddlRoles" runat="server" CssClass="form-select mb-3">
                </asp:DropDownList>

                <asp:Button ID="btnInsertar" runat="server" Text="Insertar Usuario" CssClass="btn btn-primary" OnClick="btnInsertar_Click" />
                <asp:Label ID="lblMensaje" runat="server" Text="" CssClass="text-danger"></asp:Label>
            </div>
        </div>
    </div>
        </main>
</asp:Content>
