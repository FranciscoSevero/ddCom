using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Report.Site
{
    public partial class RelatoriosChannelMonitor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populaDropDow();
                showReport();
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (string.Compare(ddlSite.Text, "-1", true) == 0)
            {
                string msg = "*** SELECIONE O SITE ***";
                ClientScript.RegisterStartupScript(typeof(string), string.Empty,
                string.Format("window.alert(\"{0}\");", msg), true);
            }
            else
                showReport();
        }
        public void populaDropDow()
        {
            ddlSite.DataSource = getDados("sp_GetSites", null);
            ddlSite.DataBind();

            ListItem listaSite = new ListItem("--Selecione o Site--", "-1");
            ddlSite.Items.Insert(0, listaSite);

            ListItem listaPlataforma = new ListItem("--Selecione a Plataforma--", "-1");
            ddlPlataforma.Items.Insert(0, listaPlataforma);

            ListItem listaGravador = new ListItem("--Selecione o Gravador--", "-1");
            ddlGravador.Items.Insert(0, listaGravador);

            ddlPlataforma.Enabled = false;
            ddlGravador.Enabled = false;
        }
        public DataSet getDados(String sp_name, SqlParameter sp_parameter)
        {
            DataSet ds = new DataSet();
            string connStr = ConfigurationManager.ConnectionStrings["ModelCHM"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlDataAdapter adp = new SqlDataAdapter(sp_name, cn);

                adp.SelectCommand.CommandType = CommandType.StoredProcedure;

                if (sp_parameter != null)
                {
                    adp.SelectCommand.Parameters.Add(sp_parameter);
                }

                adp.Fill(ds);
            }
            return ds;
        }
        private void showReport()
        {
            rptChannelMonitor.Reset();
            DataTable dt = getData(dwlStatus.Text, ddlSite.Text, ddlPlataforma.Text, ddlGravador.Text);
            ReportDataSource rds = new ReportDataSource("ChannelMonitorDataSet", dt);
            rptChannelMonitor.LocalReport.DataSources.Add(rds);
            rptChannelMonitor.LocalReport.ReportPath = "Reports/ReportChannelMonitor.rdlc";
            rptChannelMonitor.LocalReport.Refresh();
        }
        private DataTable getData(string status, string site, string plataforma, string gravador)
        {
            DataTable dt = new DataTable();
            string connStr = ConfigurationManager.ConnectionStrings["ModelCHM"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("sp_ociosidade", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
                cmd.Parameters.Add("@site", SqlDbType.VarChar).Value = site;
                cmd.Parameters.Add("@plataforma", SqlDbType.VarChar).Value = plataforma;
                cmd.Parameters.Add("@gravador", SqlDbType.VarChar).Value = gravador;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
            }
            return dt;
        }
        protected void ddlSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSite.SelectedValue == "-1")
            {
                ddlPlataforma.SelectedIndex = 0;
                ddlPlataforma.Enabled = false;
                ddlGravador.SelectedIndex = 0;
                ddlGravador.Enabled = false;
            }
            else
            {
                ddlPlataforma.Enabled = true;
                SqlParameter parameter = new SqlParameter();

                parameter.ParameterName = "@id_site";
                parameter.Value = ddlSite.SelectedValue;

                ddlPlataforma.DataSource = getDados("sp_GetPlataforma", parameter);
                ddlPlataforma.DataBind();

                ListItem listaPlataforma = new ListItem("--Selecione a Plataforma--", "-1");
                ddlPlataforma.Items.Insert(0, listaPlataforma);

                ddlGravador.SelectedIndex = 0;
                ddlGravador.Enabled = false;

                ddlGravador.Enabled = false;
            }
        }

        protected void ddlPlataforma_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPlataforma.SelectedValue == "-1")
            {

                ddlGravador.SelectedIndex = 0;
                ddlGravador.Enabled = false;
            }
            else
            {
                ddlGravador.Enabled = true;
                SqlParameter parameter = new SqlParameter();

                parameter.ParameterName = "@id_plataforma";
                parameter.Value = ddlPlataforma.SelectedValue;

                ddlGravador.DataSource = getDados("sp_GetGravador", parameter);
                ddlGravador.DataBind();

                ListItem listaGravador = new ListItem("--Selecione o Gravador--", "-1");
                ddlGravador.Items.Insert(0, listaGravador);
            }
        }
    }
}