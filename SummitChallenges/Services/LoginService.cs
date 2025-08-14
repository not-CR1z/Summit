using SummitChallenges.Models;
using SummitChallenges.Repositories;
using SummitChallenges.Utilities;

namespace SummitChallenges.Services
{
    public class LoginService
    {
        public User? Login(String username, String password)
        {
            LdapValidator validator = new LdapValidator();
            Boolean validationSuccess = validator.ValidateUser(username, password);
            if (validationSuccess)
            {
                InteractionBD connectionBD = new InteractionBD();
                return connectionBD.LoginQuery(username);
            }
            return null;
        }
    }
}
