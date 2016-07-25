<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TelaInicial.aspx.cs" Inherits="TelaInicial" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Keystone Login</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN CSS -->
    <link href="Content/Template/assets/admin/pages/css/login.css" rel="stylesheet" type="text/css" />
    <link href="Content/Template/assets/global/css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <link href="~/Content/template/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <!-- EDN CSS -->
</head>
<body class="login">
    <form id="form1" runat="server" defaultbutton="btnLogin">
        <div class="menu-toggler sidebar-toggler">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="index.html">
                <img style="width: 410px" src="Content/template/assets/admin/layout/img/keystone.png" />
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN REPORT FORMS -->
        <div class="content">
            <div>
                <h3>Opções de Relatório</h3>
                <br />
                <asp:RadioButtonList ID="radRelatorios" runat="server">
                    <asp:ListItem Value="Logins">Relatório de Logins</asp:ListItem>
                    <asp:ListItem Value="Exames">Relatório de Exames</asp:ListItem>
                    <asp:ListItem Value="Moradores">Relatório de Moradores</asp:ListItem>
                    <asp:ListItem Value="Visitantes">Relatório de Visitantes</asp:ListItem>
                </asp:RadioButtonList><br />
            </div>
            <div class="form-actions">
                <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" CssClass="btn btn-success uppercase" Text="Selecionar" />
                <asp:Button ID="Button1" runat="server" OnClick="btnSair_Click" CssClass="btn btn-success uppercase" Text="Sair" />
            </div>
            <asp:Label ID="lblMensagem" runat="server" Text="" BorderColor="Red"></asp:Label>
        </div>
        <!-- END REPORTS FORM -->
        <div class="copyright">
            <div class="page-footer-inner">
                2016 &copy; <a href="http://www.ddcom.com.br" style="color: #C40A10" title="ddCom Systems" target="_blank">ddCom Systems</a> All rights reserved
            </div>
        </div>
    </form>
</body>
</html>
