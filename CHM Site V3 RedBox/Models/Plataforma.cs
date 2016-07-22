using ModelChannelMonitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CHM_Site_V3_RedBox.Models
{    
    public class Sites
    {
        public int id_site { get; set; }
        public string site { get; set; }
        public string info_adicional { get; set; }
        public List<Plataforma> plataformaList { get; set; }
    }    
   
    public class Plataforma
    {
        public int id_site { get; set; }
        public int id_plataforma { get; set; }
        public int id_tipogravador { get; set; }
        public string plataforma { get; set; }
        public string instanciaSql { get; set; }
        public string usuarioSql { get; set; }
        public string senhaSql { get; set; }
        public int ociosidade { get; set; }
        public DateTime cadastro { get; set; }

        public Plataforma()
        {

        }
    }

    public class SiteContext
    {       
        public int id_site { get; set; }
        public int id_plataforma { get; set; }
        public int id_gravador { get; set; }        
        public int id_status { get; set; }
        public string site { get; set; }
        public string diferenca { get; set; }

        public SiteContext()
        {
        }
    }

    public class PlataformaIdle 
	{
        public string nome_plataforma { get; set; }
        public List<Gravador> gravador { get; set; }        
	}

    public class Gravador
    {
        public int serial { get; set; }
        public List<Ramal> ramal { get; set; }
    }
    
    public class Ramal
    {
        public int ramal { get; set; }
        public Int64 diferenca { get; set; }
    }

    public class SiteIdle
    {
        public string site { get; set; }
        public string info_adicional { get; set; }        
        public List<PlataformaIdle> plataforma { get; set; }
    }

    public class NewStatus
    {
        public string site { get; set; }
        public int gravador { get; set; }
        public int canal { get; set; }
        public string status { get; set; }
    }
}