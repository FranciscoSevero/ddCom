using System;
using System.Collections;
using System.Linq;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using CHM_Site_V3_RedBox.Models;
using ModelChannelMonitor;
using System.Data.SqlClient;
using System.Data;

namespace ChannelMonitor.Models
{

    public class Repository
    {
        Model model = new Model();
        static Helper helper = new Helper();

        public bool CheckUser(string username, string password)
        {
            var ad = new DomainAuthentication(username, password);
            return ad.IsValid();
        }

        public bool TestConnection()
        {
            try
            {
                if (model.Database.Connection.State != ConnectionState.Open)
                    model.Database.Connection.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SiteContext> Situacao()
        {
            return model.tbl_Sites
                   .Select(site => new SiteContext
                   {
                       id_site = site.id_site,
                       id_plataforma = model.tbl_Plataforma.Where(p => p.id_site == site.id_site).Select(x => x.id_plataforma).FirstOrDefault(),
                       id_status = model.tbl_Ramal.Where(r => r.id_site == site.id_site && r.id_status == 1).Select(x => x.id_status).FirstOrDefault(),
                       site = site.site
                   })
                   .ToList();
        }

        public SiteIdle GetIdle(SiteContext siteContext)
        {            
            var site = model.tbl_Ramal
                .Where(ramal => ramal.id_status == 1 && ramal.id_site == siteContext.id_site)
                .Select(r => new SiteIdle
                {
                    site = model.tbl_Sites.FirstOrDefault(s => s.id_site == siteContext.id_site).site,
                    info_adicional = model.tbl_Sites.FirstOrDefault(s => s.id_site == siteContext.id_site).info_adicional,
                    plataforma = model.tbl_Plataforma
                                .Where(p => p.id_plataforma == r.id_plataforma && p.id_site == r.id_site)
                                .Select(x => new PlataformaIdle
                                {
                                    nome_plataforma = r.tbl_Plataforma.plataforma,
                                    gravador = model.tbl_Gravador
                                                .Select(g => new Gravador
                                                {
                                                    serial = g.serial,
                                                    ramal = model.tbl_Ramal
                                                            .Where(s => s.id_status == 1 && s.id_gravador == g.id_gravador)
                                                            .Select(ra => new Ramal
                                                            {
                                                                ramal = ra.ramal,
                                                                diferenca = ra.diferenca                                                                
                                                            }).ToList()
                                                }).ToList()
                                }).ToList()
                }).FirstOrDefault();

            return site;
        }

        public List<Sites> Sites()
        {
            var sitesList = model.tbl_Sites
                           .Select(site => new Sites
                           {
                               id_site = site.id_site,
                               info_adicional = site.info_adicional,
                               site = site.site
                           })
                           .OrderBy(x => x.id_site).ToList();


            var sites = new List<Sites>();

            foreach (var site in sitesList)
            {
                sites.Add(new Sites
                {
                    id_site = site.id_site,
                    site = site.site,
                    info_adicional = site.info_adicional,
                    plataformaList = model.tbl_Plataforma
                                    .Select(x => new Plataforma
                                    {
                                        id_site = x.id_site,
                                        id_plataforma = x.id_plataforma,
                                        id_tipogravador = x.tbl_Gravador.Where(g => g.id_plataforma == x.id_plataforma).Select(s => s.id_tipogravador).FirstOrDefault(),
                                        plataforma = x.plataforma,
                                        instanciaSql = x.instanciaSql,
                                        usuarioSql = x.usuarioSql,
                                        senhaSql = x.senhaSql
                                    })
                                    .Where(s => s.id_site == site.id_site)
                                    .ToList()
                });

            }

            return sites;

        }

        public bool SaveSite(tbl_Sites site)
        {
            try
            {
                model.tbl_Sites.Add(new tbl_Sites
                {
                    site = site.site,
                    info_adicional = site.info_adicional,
                    cadastro = site.cadastro
                });

                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveSite(tbl_Sites site)
        {
            try
            {
                //pagar hierarquia

                model.tbl_Sites.Remove(model.tbl_Sites
                    .SingleOrDefault(s => s.id_site == site.id_site && s.site == site.site));

                model.SaveChanges();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool SavePlataforma(tbl_Plataforma plataforma)
        {
            try
            {
                model.tbl_Plataforma.Add(plataforma);

                model.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TestConnectionPlataforma(string instanciaSql, string usuarioSql, string senhaSql)
        {
            try
            {
                var connStr = string.Format(@"data source={0};initial catalog={1};persist security info=True;user id={2};password={3};MultipleActiveResultSets=True", instanciaSql, "master",
                                            usuarioSql, senhaSql);

                var sqlConn = new SqlConnection(connStr);

                sqlConn.Open();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<int> RecordersTipoPlataforma(tbl_Plataforma plataforma, string versao)
        {
            return helper.GetRecordersTipoPlataforma(plataforma, versao);
        }

        public List<int> RecordersCadastrados(tbl_Plataforma plataforma)
        {
            //var recorder = model
            //            .tbl_Gravador.Where(gravador => gravador.id_plataforma == plataforma.id_plataforma &&
            //                                            gravador.tbl_Plataforma.id_site == plataforma.id_site)
            //            .FirstOrDefault();

            var recorder = model
                       .tbl_Gravador.Where(gravador => gravador.id_plataforma == plataforma.id_plataforma)
                       .FirstOrDefault();

            return helper.GetRecordersCadastrados(recorder);

        }

        public bool SaveRecorder(tbl_Gravador recorder)
        {
            try
            {
                model.tbl_Gravador.Add(recorder);
                model.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemovePlataforma(tbl_Plataforma plataforma)
        {
            try
            {
                var removeGravadores = RemoveGravadores(plataforma);

                if (removeGravadores)
                {
                    model.Database.ExecuteSqlCommand(string.Format("DELETE FROM tbl_Ramal WHERE id_plataforma = {0} and id_site = {1}", plataforma.id_plataforma, plataforma.id_site));
                    model.Database.ExecuteSqlCommand(string.Format("DELETE FROM tbl_Plataforma WHERE id_plataforma = {0} and id_site = {1}", plataforma.id_plataforma, plataforma.id_site));
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool RemoveGravadores(tbl_Plataforma plataforma)
        {
            try
            {
                model.Database.ExecuteSqlCommand("DELETE FROM tbl_Gravador WHERE id_plataforma = " + plataforma.id_plataforma);

                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ChangeStatus(NewStatus context)
        {
            try
            {

                var id_gravador = model.tbl_Gravador.First(g => g.serial == context.gravador).id_gravador;
                var id_site = model.tbl_Sites.First(tblSites => tblSites.site == context.site).id_site;


                var updateRamal =
                    model.tbl_Ramal.FirstOrDefault(x => x.id_gravador == id_gravador &&
                            x.id_site == id_site &&
                            x.ramal == context.canal);

                if (context.status == "Vago")
                {
                    model.tbl_RamalVago.Add(new tbl_RamalVago
                    {
                        id_gravador = context.gravador,
                        id_servidor = id_site,
                        Ramal = context.canal,
                        Dt_Inclusao = DateTime.Now
                    });
                    updateRamal.id_status = 3;
                }
                else
                {
                    model.tbl_RamalEmAnalise.Add(new tbl_RamalEmAnalise
                    {
                        id_gravador = id_gravador,
                        id_servidor = id_site,
                        Ramal = context.canal,
                        Dt_Inclusao = DateTime.Now
                    });
                    updateRamal.id_status = 4;
                }

                model.Entry(model.tbl_Ramal.FirstOrDefault(x => x.id_gravador == id_gravador &&
                            x.id_site == id_site &&
                            x.ramal == context.canal)).CurrentValues.SetValues(updateRamal);
               
                
                model.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

    }

}