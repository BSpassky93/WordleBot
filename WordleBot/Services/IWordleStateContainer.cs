using Blazorise;
using WordleBot.Models;

namespace WordleBot.Services
{
    public interface IWordleStateContainer
    {
        bool IsGameComplete();
        List<WordleRequest> GetWordleRequests();
        void InitTab(int tabId, WordleRequest request, string guessFromApi);
        List<WordleRequest> GetRequestListFromTabs();
        WordleTab? GetTabById(int id);
        void IncrementGuess();
        void NewGame();
    }
}
