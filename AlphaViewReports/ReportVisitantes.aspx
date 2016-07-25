<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportVisitantes.aspx.cs" Inherits="ReportVisitantes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>Relatório de Visitantes</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="Bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="Content/Index.jsx"></script>

</head>
<body>
    <div class="container-fluid (full-width)">
        <form id="form1" runat="server" defaultbutton="btnBuscarVst">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="form-inline">
                    <h2>Busca por:</h2>
                    <p></p>
                    <div class="form-group">
                        <label for="nome">Nome:</label>
                        <asp:TextBox class="form-control" ID="txtNomeVst" runat="server" placeholder="Enter name"></asp:TextBox>
                    </div>
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                    </asp:CheckBoxList>
                    <div class="form-group">
                        <label for="unidade">Unidade:</label>
                        <asp:TextBox class="form-control" ID="txtUnidadeVst" runat="server" placeholder="Enter unit"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="bloco">Bloco:</label>
                        <asp:TextBox class="form-control" ID="txtBlocoVst" runat="server" placeholder="Enter bloc"></asp:TextBox>
                    </div>
                </div>
                <p></p>
                <br />
                <div class="form-inline">
                    <div class="form-group">
                        <label for="nome">Data Inicial:</label>
                        <asp:TextBox ID="txtDataInicial" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="nome">Data Final:</label>
                        <asp:TextBox ID="txtDataFinal" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                    </div>
                    <asp:Button class="btn btn-default" ID="btnBuscarVst" OnClick="Button1_Click" runat="server" Text="Buscar" />
                    <asp:Button class="btn btn-default" ID="btnVoltar" OnClick="btnVoltar_Click" runat="server" Text="Voltar" />
                    <br />
                    <br />
                </div>
                <rsweb:ReportViewer ID="rptVisitor" runat="server" SizeToReportContent="true">
                </rsweb:ReportViewer>
            </div>
        </form>
    </div>
</body>
</html>
