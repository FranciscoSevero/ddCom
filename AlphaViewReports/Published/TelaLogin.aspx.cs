using ProjetoServiceDesk.Controller;
using ProjetoServiceDesk.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TelaLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["Acesso"] != null && !IsPostBack)
        {
            txtUserName.Text = Request.Cookies["Acesso"]["funcionario"];
            txtPassword.Attributes.Add("value", Request.Cookies["Acesso"]["senha"]);
        }

        if (Request.QueryString["msg"] != null)
            lblMensagem.Text = Request.QueryString["msg"];

        txtUserName.Focus();
    }

    public string CalculateMD5Hash(string input)
    {
        // Calcular o Hash
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        // Converter byte array para string hexadecimal
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }

    protected void ValidUser(object sender, EventArgs e)
    {
        lblMensagem.Text = string.Empty;

        if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Text))
        {
            Funcionario user = new FuncionarioController().Autenticar(txtUserName.Text, CalculateMD5Hash(txtPassword.Text));
            if (user != null)
            {
                Session["autenticado"] = "OK";
                Session["codigoFuncionario"] = user.Codigo;
                Session["nomeFuncionario"] = user.Login;
                Session["senhaFuncionario"] = user.Senha;

                Response.Redirect("TelaInicial.aspx");
            }
            else
                lblMensagem.Text = "Usuário e/ou senha inválida.";

        }
        else {

            if (string.IsNullOrEmpty(txtUserName.Text) && string.IsNullOrEmpty(txtPassword.Text))
            {
                lblMensagem.Text = "Digite um Usuário e Senha!";
            }
            else
            {
                if (string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
                {
                    if (string.IsNullOrEmpty(txtUserName.Text))
                    {
                        lblMensagem.Text = "Digite um Usuário!";
                    }
                    else
                    {
                        lblMensagem.Text = "Digite a Senha!";
                    }
                }
            }
        }
        
        txtUserName.Text = string.Empty;
        txtPassword.Text = string.Empty;
    }

    public bool getData(string senha)
    {
        bool cadastrado;
        if (senha == "teste")
            cadastrado = true;
        else
            cadastrado = false;

        return cadastrado;
    }

}