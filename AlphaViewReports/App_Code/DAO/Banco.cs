using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ProjetoServiceDesk.DAO
{
    internal class Banco
    {
        private SqlConnection _conn;
        private string _strConexao;
        private SqlCommand _comandoSQL;
        private SqlTransaction _transacao;
        protected SqlCommand ComandoSQL
        {
            get { return _comandoSQL; }
            set { _comandoSQL = value; }
        }
        protected Banco()
        {
            _strConexao = "Data Source=10.10.20.22\\sqlexpress;Initial Catalog=Keystone;USER ID=sa;Password=adm";
            _conn = new SqlConnection(_strConexao);
            _comandoSQL = new SqlCommand();
            _comandoSQL.Connection = _conn;
        }
        protected Banco(string stringConexao)
        {
            _strConexao = stringConexao;
            _conn = new SqlConnection(_strConexao);
            _comandoSQL = new SqlCommand();
            _comandoSQL.Connection = _conn;
        }
        protected bool AbreConexao(bool transacao)
        {
            try
            {
                _conn.Open();
                if (transacao)
                {
                    _transacao = _conn.BeginTransaction();
                    _comandoSQL.Transaction = _transacao;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected bool FechaConexao()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected void FinalizaTransacao(bool commit)
        {
            if (commit)
                _transacao.Commit();
            else
                _transacao.Rollback();
            FechaConexao();
        }
        protected int ExecutaComando(bool transacao)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            AbreConexao(transacao);
            try
            {
                retorno = _comandoSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL:", ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }
        protected int ExecutaComando(bool transacao, out int ultimoCodigo)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            ultimoCodigo = 0;
            AbreConexao(transacao);
            try
            {
                ultimoCodigo = Convert.ToInt32(_comandoSQL.ExecuteScalar());
                retorno = 1;
            }
            catch (Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }
        protected DataTable ExecutaSelect()
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            AbreConexao(false);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(_comandoSQL.ExecuteReader());
            }
            catch (Exception ex)
            {
                dt = null;
                throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                FechaConexao();
            }
            return dt;
        }
        protected double ExecutaScalar()
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            AbreConexao(false);
            double retorno;
            try
            {
                retorno = Convert.ToDouble(_comandoSQL.ExecuteScalar());
            }
            catch (Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL: ", ex);
            }
            finally
            {
                FechaConexao();
            }
            return retorno;
        }
    }
}