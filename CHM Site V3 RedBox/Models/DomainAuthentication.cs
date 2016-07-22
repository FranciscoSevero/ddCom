using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security;
using System.DirectoryServices.AccountManagement;
using ChannelMonitor.Models;
using System.Web.Configuration;

/// <summary>
/// Summary description for Credentials
/// </summary>
public class DomainAuthentication
{    
    public struct Credentials
    {
        public string Username;
        public string Password;
    }

    public Credentials _Credentials;

    public string Domain;

    public DomainAuthentication(string username, string password)
    {
        try
        {
            _Credentials.Username = username;
            _Credentials.Password = password;
            //Domain = Environment.UserDomainName;
            Domain = WebConfigurationManager.AppSettings["Dominio"];            
        }
        catch (Exception ex)
        {
            throw;
        }

    }

    public bool IsValid()
    {
        var ret = string.Empty;

        try
        {
            using (var pc = new PrincipalContext(ContextType.Domain, Domain))
            {                
                return pc.ValidateCredentials(_Credentials.Username, _Credentials.Password);
            }
        }
        catch (Exception ex)
        {            
            return false;
        }        
    }
}