using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class FuncionarioBD : Banco
    {
        internal FuncionarioBD() { }

        internal Funcionario Autenticar(string login, string senha)
        {
            ComandoSQL.Parameters.Clear();
            ComandoSQL.CommandText = @"select * from [Login]
                                     where nomeLogin = @login and SenhaLogin = @senha";
            ComandoSQL.Parameters.AddWithValue("@login", login);
            ComandoSQL.Parameters.AddWithValue("@senha", senha);

            DataTable dt = ExecutaSelect();
            if (dt != null && dt.Rows.Count > 0)
            {
                Funcionario f = new Funcionario();
                f.Codigo = Convert.ToInt32(dt.Rows[0]["Login_id"]);
                f.Login = dt.Rows[0]["nomeLogin"].ToString();
                f.Senha = dt.Rows[0]["SenhaLogin"].ToString();
                return f;
            }
            else
                return null;
        }
    }
}