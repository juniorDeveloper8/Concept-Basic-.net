<%@ Page Title="" Language="C#" MasterPageFile="~/PagesMaster/FormularioEdit.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="Visual_Plantilla.PagesAspx.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Arial', sans-serif;
            background-color: #f5f5f5;
        }

        .main-container {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        .form-container {
            width: 400px;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }

        .form-container h1 {
            text-align: center;
            color: #333;
        }

        .form-container .form-group {
            margin-bottom: 15px;
        }

        .form-container label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
            color: #555;
        }

        .form-container .form-control {
            width: calc(100% - 20px);
            padding: 10px;
            box-sizing: border-box;
            border: 1px solid #ccc;
            border-radius: 4px;
            font-size: 14px;
            margin-bottom: 10px;
        }

        .form-container .btn-primary {
            width: 100%;
            background-color: #007bff;
            color: #fff;
            border: 1px solid #007bff;
            border-radius: 4px;
            padding: 10px;
            font-size: 16px;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderEdit" runat="server">
    <div class="main-container">
        <div class="form-container">
            <h1>Editar Usuario</h1>
            <div class="form-group">
                <label for="txtNombreEdit">Nombre:</label>
                <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtApellidoEdit">Apellido:</label>
                <asp:TextBox ID="txtApellidoEdit" runat="server" CssClass="form-control" placeholder="Apellido"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtUsuarioEdit">Usuario:</label>
                <asp:TextBox ID="txtUsuarioEdit" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtClaveEdit">Clave:</label>
                <asp:TextBox ID="txtClaveEdit" runat="server" CssClass="form-control" placeholder="Clave"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCorreoEdit">Correo:</label>
                <asp:TextBox ID="txtCorreoEdit" runat="server" CssClass="form-control" placeholder="Correo"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtEstadoEdit">Estado:</label>
                <asp:TextBox ID="txtEstadoEdit" runat="server" CssClass="form-control" placeholder="Estado"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtRolEdit">Rol:</label>
                <asp:TextBox ID="txtRolEdit" runat="server" CssClass="form-control" placeholder="Rol"></asp:TextBox>
            </div>
            <!-- Agrega más campos según sea necesario -->
            <asp:Button ID="btnGuardarCambios" runat="server" Text="Guardar Cambios" CssClass="btn btn-primary" OnClick="btnGuardarCambios_Click" />
        </div>
    </div>
</asp:Content>
