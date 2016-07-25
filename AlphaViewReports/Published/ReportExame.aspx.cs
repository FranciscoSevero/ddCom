using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class ReportExame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNome.Text = string.Empty;
            DowListExame.SelectedIndex = 0;
            btnMostrar.Focus();
            showReport();
           
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        showReport();
        txtNome.Text = string.Empty;
        DowListExame.SelectedIndex = 0;
        btnMostrar.Focus();

    }

    public void showReport()
    {
        rptExame.Reset();

        DataTable dt = getData(txtNome.Text, DowListExame.Text);
        ReportDataSource rds = new ReportDataSource("DataSetExame", dt);
        rptExame.LocalReport.DataSources.Add(rds);

        rptExame.LocalReport.ReportPath = "Reports/Exame.rdlc";
        rptExame.LocalReport.Refresh();
    }

    public DataTable getData(string nome, string status)
    {
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["KeystoneConnectionString"].ConnectionString;
        using (SqlConnection cnn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("sp_exame", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
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