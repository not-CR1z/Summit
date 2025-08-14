using SummitChallenges.Repositories;

namespace SummitChallenges.Services
{
    public class JournalService
    {
        public string GetJournalsByUser( string user)
        {
            InteractionBD interactionBD = new InteractionBD();
            return interactionBD.GetJournalsByUser(user);
        }
    }
}
