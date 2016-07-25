using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class ReportMorador : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtNome.Text = string.Empty;
            DowListApto.SelectedIndex = 0;
            DowListBloco.SelectedIndex = 0;
            btnMostrar.Focus();
            showReport();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        showReport();
        txtNome.Text = string.Empty;
        DowListApto.SelectedIndex = 0;
        DowListBloco.SelectedIndex = 0;
        btnMostrar.Focus();
    }
    public void showReport()
    {
        rptMorador.Reset();
        DataTable dt = getData(Int32.Parse(DowListBloco.SelectedValue),Int32.Parse(DowListApto.SelectedValue), txtNome.Text);
        ReportDataSource rds = new ReportDataSource("DataSetMorador", dt);
        rptMorador.LocalReport.DataSources.Add(rds);rptMorador.LocalReport.ReportPath = "Reports/Morador.rdlc";
        rptMorador.LocalReport.Refresh();

    }
    public DataTable getData(int bloco, int apto, string nome)
    {
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["KeystoneConnectionString"].ConnectionString;
        using (SqlConnection cnn = new SqlConnection(connStr)) {
            SqlCommand cmd = new SqlCommand("sp_moradores", cnn); 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
            cmd.Parameters.Add("@bloco",SqlDbType.Int).Value = bloco;
            cmd.Parameters.Add("@apto", SqlDbType.Int).Value = apto;

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