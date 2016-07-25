using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class ReportVisitantes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtDataInicial.Text = "01/01/2010";
            DateTime thisday = DateTime.Today;
            txtDataFinal.Text = thisday.ToString("d");
            txtBlocoVst.Text = string.Empty;
            txtNomeVst.Text = string.Empty;
            txtUnidadeVst.Text = string.Empty;
            showReport();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        showReport();
        txtDataInicial.Text = "01/01/2010";
        DateTime thisday = DateTime.Today;
        txtDataFinal.Text = thisday.ToString("d");
        txtBlocoVst.Text = string.Empty;
        txtNomeVst.Text = string.Empty;
        txtUnidadeVst.Text = string.Empty;
    }
    private void showReport()
    {
        rptVisitor.Reset();

        DataTable dt = getData(txtNomeVst.Text, txtUnidadeVst.Text, txtBlocoVst.Text, DateTime.Parse(txtDataInicial.Text), DateTime.Parse(txtDataFinal.Text));
        ReportDataSource rds = new ReportDataSource("VisitorDataSet", dt);
        rptVisitor.LocalReport.DataSources.Add(rds);

        rptVisitor.LocalReport.ReportPath = "Reports/Visitante.rdlc";

        rptVisitor.LocalReport.Refresh();
    }
    private DataTable getData(string name, string unit, string block, DateTime dataInicial, DateTime dataFinal)
    {
        DataTable dt = new DataTable();
        string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["KeystoneConnectionString"].ConnectionString;
        using (SqlConnection cnn = new SqlConnection(connstr))
        {
            SqlCommand cmd = new SqlCommand("sp_visitor", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@unidade", SqlDbType.VarChar).Value = unit;
            cmd.Parameters.Add("@bloco", SqlDbType.VarChar).Value = block;
            cmd.Parameters.Add("@dataInicial", SqlDbType.DateTime).Value = dataInicial.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@dataFinal", SqlDbType.DateTime).Value = dataFinal.ToString("yyyy-MM-dd");

            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        return dt;
    }

    protected void btnVoltar_Click(object sender, EventArgs e)
    {
        Server.Transfer("TelaInicial.aspx");
    }
}