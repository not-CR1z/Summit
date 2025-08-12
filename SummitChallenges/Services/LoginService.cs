using SummitChallenges.Utilities;

namespace SummitChallenges.Services
{
    public class LoginService
    {
        public Boolean Login(String username, String password)
        {
            LdapValidator validator = new LdapValidator();
            Boolean validationSuccess = validator.ValidateUser(username, password);
            if (validationSuccess)
            {
                return true;
            }
            return false;
        }
    }
}
