using System;
using System.Net;
using System.DirectoryServices.Protocols;
using System.Collections.Generic;

namespace SummitChallenges.Utilities
{
    public class LdapValidator
    {
        private String _ldapServer = "10.8.35.6";
        private String _ldapDomain = "LDAP.BANCOLOMBIA.CORP";

        public Boolean ValidateUser(String username, String password)
        {
            try
            {

                LdapDirectoryIdentifier myDirId = new LdapDirectoryIdentifier(_ldapServer);
                NetworkCredential credential = new NetworkCredential(username, password, _ldapDomain);
                using (LdapConnection ldapConnection = new LdapConnection(myDirId, credential))
                {
                    ldapConnection.Bind();
                    return true;
                }
            }
            catch (LdapException ex)
            {
                Console.WriteLine($"Error al autenticar usuario: {ex.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error de conexión: {ex.Message}");
                return false;
            }
        }
    }
}
