namespace SummitChallenges.Models
{
    public class User
    {
        public Int64 Id { get; set; }
        public String UserLogOn { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public String FirstName { get; set; } = String.Empty;
        public String LastName { get; set; } = String.Empty;
        public String Documento { get; set; } = String.Empty;
        public String Role { get; set; } = String.Empty;
    }
}
