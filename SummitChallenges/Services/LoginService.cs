using SummitChallenges.Repositories;
using SummitChallenges.Utilities;

namespace SummitChallenges.Services
{
    public class LoginService
    {
        public string Login(String username, String password)
        {
            LdapValidator validator = new LdapValidator();
            Boolean validationSuccess = validator.ValidateUser(username, password);
            if (validationSuccess)
            {
                ConnectionBD connectionBD = new ConnectionBD();
                return connectionBD.LoginQuery(username);
            }
            return String.Empty;
        }
    }
}
