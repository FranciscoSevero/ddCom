using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;

public partial class hoursControl : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dwlCliente.DataBind();
            dwlCliente.Items.Insert(0, new ListItem("Selecionar", string.Empty));
            dwlDesenvolvedor.DataBind();
            dwlDesenvolvedor.Items.Insert(0, new ListItem("Selecionar", string.Empty));
            dwlProjeto.DataBind();
            dwlProjeto.Items.Insert(0, new ListItem("Selecionar", string.Empty));
            txtDataInicial.Text = "01/01/2016";
            DateTime thisday = DateTime.Today;
            txtDataFinal.Text = thisday.ToString("d");
            showReport();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        showReport();
        txtDataInicial.Text = "01/01/2010";
        DateTime thisday = DateTime.Today;
        txtDataFinal.Text = thisday.ToString("d");
        dwlCliente.DataBind();
        dwlCliente.Items.Insert(0, new ListItem("Selecionar", string.Empty));
        dwlDesenvolvedor.DataBind();
        dwlDesenvolvedor.Items.Insert(0, new ListItem("Selecionar", string.Empty));
        dwlProjeto.DataBind();
        dwlProjeto.Items.Insert(0, new ListItem("Selecionar", string.Empty));
        txtValor.Text = "0";
    }
    private void showReport()
    {
        rptHoursControl.Reset();
        DataTable dt = getData(dwlDesenvolvedor.Text, dwlProjeto.Text, dwlCliente.Text, DateTime.Parse(txtDataInicial.Text), DateTime.Parse(txtDataFinal.Text));
        ReportDataSource rds = new ReportDataSource("ControleHorasDataSet", dt);
        rptHoursControl.LocalReport.DataSources.Add(rds);
        rptHoursControl.LocalReport.ReportPath = "Reports/ReportHoursControl.rdlc";
        if (string.IsNullOrEmpty(txtValor.Text))
            txtValor.Text = "0";
        else
            txtValor.Text = txtValor.Text.Substring(3);
        ReportParameter[] RptParans = new ReportParameter[]
        {
                new ReportParameter ("DataInicial", txtDataInicial.Text),
                new ReportParameter ("DataFinal", txtDataFinal.Text),
                new ReportParameter ("ValorHora", txtValor.Text)
        };


        rptHoursControl.LocalReport.SetParameters(RptParans);
        rptHoursControl.LocalReport.Refresh();
    }
    private DataTable getData(string usuario, string projeto, string cliente, DateTime dataInicioInteracao, DateTime dataFimInteracao)
    {
        DataTable dt = new DataTable();
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["ControleHorasConnectionString"].ConnectionString;
        using (SqlConnection cn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("sp_controleHoras", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = usuario;
            cmd.Parameters.Add("@Projeto", SqlDbType.VarChar).Value = projeto;
            cmd.Parameters.Add("@Cliente", SqlDbType.VarChar).Value = cliente;
            cmd.Parameters.Add("@DataInicioInteracao", SqlDbType.VarChar).Value = dataInicioInteracao.ToString("yyyy-MM-dd");
            cmd.Parameters.Add("@DataFimInteracao", SqlDbType.VarChar).Value = dataFimInteracao.ToString("yyyy-MM-dd");
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            adp.Fill(dt);
        }
        return dt;
    }
}