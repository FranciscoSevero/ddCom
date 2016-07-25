<%@ Page Language="C#" AutoEventWireup="true" CodeFile="hoursControl.aspx.cs" Inherits="hoursControl" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Controle de Horas</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" type="text/css" href="Bootstrap/bootstrap.min.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.0/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <script src="Bootstrap/Index.jsx"></script>
    <script type="text/javascript" src="Bootstrap/jquery-1.5.min.js"> </script>
    <script type="text/javascript" src="Bootstrap/jquery.price_format.1.3.js"></script>
    <script src="Bootstrap/Index.js"></script>
</head>
<body>
    <div class="container-fluid (full-width)">
        <form id="form1" runat="server" defaultbutton="btnBuscarVst">
            <div>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="form-inline">
                    <h2>Busca por:</h2>
                </div>
                <br />
                <div class="form-inline">
                    <div class="form-group">
                        <label for="cliente">Cliente:</label>
                        <asp:DropDownList class="form-control" ID="dwlCliente" runat="server" placeholder="Enter developer" AutoPostBack="True" DataSourceID="SqlDataSource2" DataTextField="NomeCliente" DataValueField="NomeCliente">
                            <asp:ListItem>vazio</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ControleHorasConnectionString3 %>" SelectCommand="SELECT a.NomeCliente FROM Cliente AS a INNER JOIN Projeto AS b ON a.Cliente_id = b.Cliente_id GROUP BY a.NomeCliente ORDER BY a.NomeCliente"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <label for="projeto">Projeto:</label>
                        <asp:DropDownList class="form-control" ID="dwlProjeto" runat="server" placeholder="Enter developer" AutoPostBack="True" DataSourceID="SqlDataSource3" DataTextField="NomeProjeto" DataValueField="NomeProjeto">
                            <asp:ListItem>vazio</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ControleHorasConnectionString4 %>" SelectCommand="SELECT [NomeProjeto] FROM [Projeto] ORDER BY [NomeProjeto]"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <label for="desenvolvedor">Desenvolvedor:</label>
                        <asp:DropDownList class="form-control" ID="dwlDesenvolvedor" runat="server" placeholder="Enter developer" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="NomeUsuario" DataValueField="NomeUsuario">
                            <asp:ListItem Selected="True" Value="vazio">Todos</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ControleHorasConnectionString2 %>" SelectCommand="SELECT [NomeUsuario] FROM [Usuario] ORDER BY [NomeUsuario]"></asp:SqlDataSource>
                    </div>
                </div>
                <p></p>
                <div class="form-inline">
                    <div class="form-group">
                        <label for="dataInicial">Data Inicial:  </label>
                        <asp:TextBox ID="txtDataInicial" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="dataFinal">Data Final:</label>
                        <asp:TextBox ID="txtDataFinal" ClientIDMode="Static" runat="server" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="valorHora">Valor Hora:</label>
                        <asp:TextBox ID="txtValor" ClientIDMode="Static" runat="server" placeholder="Enter Value" class="form-control">
                        </asp:TextBox>
                    </div>
                </div>
                <p></p>
                <br />
                <div class="form-inline">
                    <asp:Button class="btn btn-default" ID="btnBuscarVst" OnClick="Button1_Click" runat="server" Text="Buscar" />
                </div>
            </div>
            <br />
            <rsweb:ReportViewer ID="rptHoursControl" runat="server" SizeToReportContent="true">
            </rsweb:ReportViewer>
            <br />
        </form>
    </div>
</body>
</html>
