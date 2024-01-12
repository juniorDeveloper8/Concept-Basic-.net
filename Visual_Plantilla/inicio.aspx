<%@ Page Title="Datos" Language="C#" MasterPageFile="~/PagesMaster/Login.Master" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Visual_Plantilla.inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Inicio</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <style>
        body {
            background-color: #f8f9fa;
        }

        .container {
            height: 100vh;
            width: 100vh;
            position: fixed;
            left: 25%;
            justify-content: center;
            align-items: center;
        }

        .card {
            border: none;
            border-radius: 15px;
            box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
        }

        .form-control-lg {
            border-radius: 8px;
            margin-bottom: 10px;
        }

        .btn-primary {
            background-color: #007bff;
            border: none;
            border-radius: 8px;
            padding: 14px;
            width: 100%;
        }

        .btn-primary:hover {
            background-color: #0056b3;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContenLogin" runat="server">
    <section>
        <div class="container">
            <div class="col-md-6">
                <div class="card p-4">
                    <div class="text-center mb-4">
                        <h1 class="h3">¡Bienvenido de nuevo!</h1>
                        <p>Inicia sesión para continuar</p>
                    </div>
                    <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text=""></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control form-control-lg" TextMode="Email" placeholder="Correo Electrónico"></asp:TextBox>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <asp:CheckBox ID="chkRememberMe" runat="server" Checked="true" Text="Recordarme" CssClass="mb-3" />
                    <asp:Label ID="lblWelcomeMessage" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnSignIn" runat="server" Text="Iniciar sesión" CssClass="btn btn-lg btn-primary" OnClientClick="return ValidateForm();" OnClick="btnSignIn_Click" />
                    <div class="text-center mt-3">
                        ¿No tienes una cuenta? <a href="PagesAspx/Registro.aspx">Regístrate</a>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
