using TournamentTrackerLibrary.Models;

namespace TournamentTrackerUI.Interfaces
{
    public interface IPrizeRequester
    {
        void GetPrize(PrizeModel prize);
    }
}
