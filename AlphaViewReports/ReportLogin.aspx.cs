using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Web.Services;

public partial class ReportLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNome.Text = string.Empty;
            txtDataInicial.Text = "01/01/2010";
            DateTime thisDay = DateTime.Today;
            txtDataFinal.Text = thisDay.ToString("d");
            showReport();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        var saida = DateTime.Now;
        var dateconv = DateTime.TryParse(txtDataInicial.Text, out saida);

        if (dateconv)
        {
            showReport();
            txtNome.Text = string.Empty;
            txtDataInicial.Text = "01/01/2010";
            DateTime thisDay = DateTime.Today;
            txtDataFinal.Text = thisDay.ToString("d");
        }
        else {
            string msg = "Data Inválida";
            ClientScript.RegisterStartupScript(typeof(string), string.Empty,
            string.Format("window.alert(\"{0}\");", msg), true);
            
            txtNome.Text = string.Empty;
            txtDataInicial.Text = "01/01/2000";
            DateTime thisDay = DateTime.Today;
            txtDataFinal.Text = thisDay.ToString("d");
        }
    }
    private void showReport()
    {
        rptViewerLogin.Reset();
        DataTable dt = getData(txtNome.Text, DateTime.Parse(txtDataInicial.Text), DateTime.Parse(txtDataFinal.Text));
        ReportDataSource rds = new ReportDataSource("KeystoneDataSet", dt);
        rptViewerLogin.LocalReport.DataSources.Add(rds);
        rptViewerLogin.LocalReport.ReportPath = "Reports/Login.rdlc";
        rptViewerLogin.LocalReport.Refresh();
    }
    private DataTable getData(string nome, DateTime dataInicial, DateTime dataFinal)
    {
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["KeystoneConnectionString"].ConnectionString;

        using (SqlConnection cn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("sp_loginreport", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
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