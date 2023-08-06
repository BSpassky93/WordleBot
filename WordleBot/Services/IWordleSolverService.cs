using WordleBot.Models;

namespace WordleBot.Services
{
    public interface IWordleSolverService
    {
        Task<WordleResponse> GetWordleResultAsync(List<WordleRequest> request);
    }
}
