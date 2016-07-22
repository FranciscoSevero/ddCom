using ModelChannelMonitor;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CHM_Site_V3_RedBox.Models
{
    public class Helper
    {
        Model model = new Model();

        public List<int> GetRecordersTipoPlataforma(tbl_Plataforma plataforma, string versaoRecorder)
        {
            var listRecorder = new List<int>();
            //var id_tipogravador = plataforma.tbl_Gravador.Where(s => s.id_plataforma == plataforma.id_site).Select(x => x.id_plataforma).FirstOrDefault();


            var catalog = versaoRecorder == "V11" ? "BPMAINDB" : "EwareCalls";

            //var connStr2 = string.Format(@"data source={1};initial catalog={2};persist security info=True;user id={3};password={4};MultipleActiveResultSets=True", plataforma.instanciaSql.Trim(), catalog,
            //    plataforma.usuarioSql, plataforma.senhaSql);

            //var connStr = string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3}", plataforma.instanciaSql.Trim(), catalog,
            //    plataforma.usuarioSql, plataforma.senhaSql);

            var connStr = "data source=RICARDO-PC;initial catalog=BPMAINDB;persist security info=True;Integrated Security=true;connect timeout=10;MultipleActiveResultSets=True;App=EntityFramework";

            var queryStr = string.Empty;

            if (versaoRecorder == "V11")
            {
                queryStr = "SELECT SERVERINSTALLATION.SERIALNUMBER AS serial " +
                            "FROM  DATAPORTGROUP " +
                                "INNER JOIN DATAPORTGROUPINSTALLATIONXREF ON DATAPORTGROUP.ID = DATAPORTGROUPINSTALLATIONXREF.DATAPORTGROUPID " +
                                "INNER JOIN INSTALLHIERARCHY ON DATAPORTGROUPINSTALLATIONXREF.INSTALLHIERARCHYID = INSTALLHIERARCHY.ID " +
                                "INNER JOIN INSTALLHIERARCHY AS INSTALLHIERARCHY_1 ON INSTALLHIERARCHY.PARENTID = INSTALLHIERARCHY_1.ID " +
                                "INNER JOIN SERVERINSTALLATION ON INSTALLHIERARCHY.PARENTID = SERVERINSTALLATION.INSTALLHIERARCHYID " +
                                "INNER JOIN DATAPORT ON DATAPORTGROUP.DATASOURCEID = DATAPORT.DATASOURCEID " +
                            "GROUP BY SERIALNUMBER";
            }
            else
            {
                queryStr = "SELECT * FROM tblWatermark";
            }

            SqlConnection connection = new SqlConnection(connStr);
            {
                SqlCommand command = new SqlCommand(queryStr, connection);

                if (connection.State != ConnectionState.Open)
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        listRecorder.Add(-1);
                    }

                }

                if (connection.State == ConnectionState.Open)
                {
                    try
                    {
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            listRecorder.Add(int.Parse(reader[0].ToString()));
                        }

                        connection.Close();//fecha conexão apos comando                    
                    }
                    catch (Exception ex)
                    {
                        listRecorder.Add(-2);
                    }
                }

            }

            return listRecorder;
        }

        public List<int> GetRecordersCadastrados(tbl_Gravador gravador)
        {
            try
            {
                return model.tbl_Gravador
                .Where(grav => grav.id_plataforma == gravador.id_plataforma &&
                                grav.id_tipogravador == gravador.id_tipogravador)
                .Select(x => x.serial)
                .ToList();
            }
            catch (Exception)
            {
                return new List<int>();
            }
        }

        public string ConvertToTime(long timeInt)
        {                        
            var t = TimeSpan.FromSeconds(timeInt);

            string time = string.Format("{0:D2}h {1:D2}m",
                t.Hours,
                t.Minutes
                );

            return time;

        }
    }
}