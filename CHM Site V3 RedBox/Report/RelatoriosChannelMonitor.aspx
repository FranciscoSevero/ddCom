<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RelatoriosChannelMonitor.aspx.cs" Inherits="Report.Site.RelatoriosChannelMonitor" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Relatório Channel Monitor</title>

    <meta name="viewport" content="width=device-width, initial-scale=1" />





    <link href="Bootstrap/bootstrap.min.css" rel="stylesheet" />


</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <br />
            <div class="form-inline">
                <div style="width: 100%; margin-left: 10px;">
                    <div class="form-group">
                        <label for="cliente">Status:</label>
                        <asp:DropDownList ID="dwlStatus" runat="server" DataSourceID="SqlDataSourceStatus" DataTextField="status" DataValueField="status" Width="180px" Height="30px">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSourceStatus" runat="server" ConnectionString="<%$ ConnectionStrings:ModelCHM %>" SelectCommand="SELECT [status] FROM [tbl_Status] ORDER BY [status] DESC"></asp:SqlDataSource>
                    </div>
                    <div class="form-group">
                        <label for="cliente">Site:</label>
                        <asp:DropDownList ID="ddlSite" runat="server" DataTextField="site" DataValueField="id_site" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlSite_SelectedIndexChanged" Height="25px">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="cliente">Plataforma:</label>
                        <asp:DropDownList ID="ddlPlataforma" runat="server" Width="190px" AutoPostBack="True" DataTextField="plataforma" DataValueField="id_plataforma" OnSelectedIndexChanged="ddlPlataforma_SelectedIndexChanged" Height="25px">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="cliente">Gravador:</label>
                        <asp:DropDownList ID="ddlGravador" runat="server" Width="190px" DataTextField="serial" DataValueField="id_gravador" Height="30px">
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <p></p>
            <div class="form-inline">
                <div style="width: 100%; margin-left: 10px;">
                    <asp:Button ID="btnBuscar" class="btn btn-primary bottom-right" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                </div>
            </div>
            <p></p>
        </div>
        <div style="width: 100%; margin-left: auto;">
            <rsweb:ReportViewer ID="rptChannelMonitor" runat="server" SizeToReportContent="true">
                <LocalReport ReportPath="Reports\ReportChannelMonitor.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
