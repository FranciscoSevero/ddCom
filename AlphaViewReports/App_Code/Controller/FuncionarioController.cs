using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoServiceDesk.Model;
using ProjetoServiceDesk.DAO;

namespace ProjetoServiceDesk.Controller
{
    public class FuncionarioController
    {
        FuncionarioBD bd = new FuncionarioBD();

        public Funcionario Autenticar(string login, string senha)
        {
            if (login != "" && senha.Trim().Length > 0)
                return new FuncionarioBD().Autenticar(login, senha);
            else
                return null;
        }
        public FuncionarioController() { }
    }
}