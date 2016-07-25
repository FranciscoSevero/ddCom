<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportExame.aspx.cs" Inherits="ReportExame" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório de Exame</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.2/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container-fluid (full-width)">
        <form id="form1" runat="server" defaultbutton="btnMostrar">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <br />
                <div class="form-inline">
                    <h2>Busca por:</h2>
                    <p></p>
                    <div class="form-group">
                        <label for="nome">Nome:</label>
                        <asp:TextBox class="form-control" ID="txtNome" runat="server" placeholder="Enter name"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="status">Status:</label>
                        <asp:DropDownList ID="DowListExame" runat="server" Height="31px" Width="95px">
                            <asp:ListItem Value=" ">--TODOS--</asp:ListItem>
                            <asp:ListItem Value="Válido">Regular</asp:ListItem>
                            <asp:ListItem Value="In">Vencido</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <asp:Button class="btn btn-default" ID="btnMostrar" OnClick="Button1_Click" runat="server" Text="Mostrar" />
                    <asp:Button class="btn btn-default" ID="btnVoltar" OnClick="btnVoltar_Click" runat="server" Text="Voltar" />
                    <br />
                    <br />
                </div>
                <rsweb:ReportViewer ID="rptExame" runat="server" SizeToReportContent="true">
                </rsweb:ReportViewer>

            </div>
        </form>
    </div>
</body>
</html>
