using System.Collections;

namespace searchfight
{
    class SearchEngineManager
    {
        private ArrayList engineList;

        public SearchEngineManager()
        {
            GoogleSearchEngine google = new GoogleSearchEngine();
            BingSearchEngine bing = new BingSearchEngine();
            this.engineList = new ArrayList { google, bing };
        }

        public ArrayList GetEngineList()
        {
            return engineList;
        }

        public void SetEngineList(ArrayList value)
        {
            engineList = value;
        }
    }
}
