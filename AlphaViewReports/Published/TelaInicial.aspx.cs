using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TelaInicial : System.Web.UI.Page
{
    public static void VerificaLogin()
    {
        if (HttpContext.Current.Session["autenticado"] == null ||
            HttpContext.Current.Session["autenticado"].ToString() != "OK")
        {
            HttpContext.Current.Session.Abandon();
            HttpContext.Current.Response.Redirect("Default.aspx?msg=Por favor, autentique-se");
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        VerificaLogin();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        switch (radRelatorios.Text)
        {
            case "Logins":
                //Server.Transfer("ReportLogin.aspx");
                Response.Redirect("ReportLogin.aspx");
                break;
            case "Exames":
                //Server.Transfer("ReportExame.aspx");
                Response.Redirect("ReportExame.aspx");
                break;
            case "Moradores":
                //Server.Transfer("ReportMorador.aspx");
                Response.Redirect("ReportMorador.aspx");
                break;
            case "Visitantes":
                //Server.Transfer("ReportVisitantes.aspx");
                Response.Redirect("ReportVisitantes.aspx");
                break;
            default:
                string msg = "Selecione o Relatório";
                ClientScript.RegisterStartupScript(typeof(string), string.Empty,
                string.Format("window.alert(\"{0}\");", msg), true);
                break;
        }
    }

    protected void btnSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("Logout.aspx");
    }
}