using WordleBot.Models;

namespace WordleBot.Services
{
    public class WordleStateContainer : IWordleStateContainer
    {
        public const int NUMBER_OF_GUESSES_ALLLOWED = 5;
        private int _numberOfGuesses = 0;
        private List<WordleRequest> _wordleRequestList = new List<WordleRequest>() { };
        public List<WordleTab> Tabs = new List<WordleTab>();
        public bool IsGameComplete()
        {
            return _numberOfGuesses == NUMBER_OF_GUESSES_ALLLOWED;
        }

        public void IncrementGuess()
        {
            _numberOfGuesses++;
        }

        public List<WordleRequest> GetWordleRequests() 
        { 
            return _wordleRequestList;
        }

        public void InitTab(int tabId, WordleRequest request, string guessFromApi)
        {
            WordleTab tab = new WordleTab(tabId, request, guessFromApi);
            Tabs.Add(tab);
        }

        public List<WordleRequest> GetRequestListFromTabs()
        {
            List<WordleRequest> requestList = new List<WordleRequest>();
            foreach (WordleTab tab in Tabs)
            {
                if(tab.Request != null)
                {
                    requestList.Add(tab.Request);
                }
            }

            return requestList;
        }

        public WordleTab? GetTabById(int id)
        {
          return Tabs?.FirstOrDefault(t => t.TabId == id);
        }

        public void NewGame()
        {
            _numberOfGuesses = 0;
            _wordleRequestList = new List<WordleRequest>();
            Tabs = new List<WordleTab>();
        }

    }

    public class WordleTab
    {
        public WordleTab(int tabId, WordleRequest request, string guessFromApi)
        {
            TabId = tabId; 
            Request = request;
            GuessFromApi = guessFromApi;
        }
        public int TabId { get; set; }
        public WordleRequest Request { get; set; }
        public string GuessFromApi { get; set;}
    }
}
