<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TelaLogin.aspx.cs" Inherits="TelaLogin" %>

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
    <!-- BEGIN GLOBAL MANDATORY STYLES -->

    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="Content/Template/assets/admin/pages/css/login.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="Content/Template/assets/global/css/components.css" id="style_components" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link href="~/Content/template/assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
</head>

<body class="login">
    <form id="form1" runat="server" defaultbutton="btnLogin">
        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        <div class="menu-toggler sidebar-toggler">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        <!-- END SIDEBAR TOGGLER BUTTON -->
        <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="index.html">
                <img style="width: 410px" src="Content/template/assets/admin/layout/img/keystone.png" />
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <h3 class="form-title">Sign In</h3>
            <div class="alert alert-danger display-hide">
                <button class="close" data-close="alert"></button>
                <span>Enter any username and password. </span>
            </div>
            <div class="form-group">
                <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                <label class="control-label visible-ie8 visible-ie9">Username</label>
                <asp:TextBox ID="txtUserName" runat="server" placeholder="Username" AutoCompleteType="Disabled" CssClass="form-control form-control-solid placeholder-no-fix"></asp:TextBox>
            </div>
            <div class="form-group">
                <label class="control-label visible-ie8 visible-ie9">Password</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" AutoCompleteType="Disabled" CssClass="form-control form-control-solid placeholder-no-fix"></asp:TextBox>
            </div>
            <div class="form-actions">
                <asp:Button ID="btnLogin" runat="server" OnClick="ValidUser" CssClass="btn btn-success uppercase" Text="Login" />
            </div>
            <asp:Label ID="lblMensagem" runat="server" Text="" BorderColor="Red"></asp:Label>
            <!-- END LOGIN FORM -->
        </div>
        <div class="copyright">
            <div class="page-footer-inner">
                2016 &copy; <a href="http://www.ddcom.com.br" style="color: #C40A10" title="ddCom Systems" target="_blank">ddCom Systems</a> All rights reserved
            </div>
        </div>
    </form>
</body>
</html>
