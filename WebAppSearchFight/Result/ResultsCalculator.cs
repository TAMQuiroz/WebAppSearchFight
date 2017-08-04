using System;
using System.Collections;

namespace searchfight
{
    class ResultsCalculator
    {
        private Result[] results;

        public ResultsCalculator(SearchEngineManager engines, string[] searchArguments)
        {
            if(searchArguments.Length == 0)
            {
                Console.WriteLine("This program needs at least one argument. Press any key to continue...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
                
            this.results = new Result[engines.GetEngineList().Count + 1];
            for (var i = 0; i <= engines.GetEngineList().Count; i++) results[i] = new Result();
            this.FightEngines(engines.GetEngineList(), searchArguments);
        }

        internal Result[] GetResults()
        {
            return results;
        }

        internal void SetResults(Result[] value)
        {
            results = value;
        }

        public Result GetResult(int index)
        {
            return results[index];
        }

        public void SetResult(int index, long resultNumber, string argumentName, string engineName)
        {
            results[index].ResultNumber = resultNumber;
            results[index].ArgumentName = argumentName;
            results[index].EngineName = engineName;
        }

        private void FightEngines(ArrayList engines, string[] searchArguments)
        {
            for (int i = 0; i < searchArguments.Length; i++)
            {
                Console.Write(searchArguments[i] + ": ");

                for (int j = 0; j < engines.Count; j++)
                {
                    var engine = (ISearchEngine)engines[j];
                    engine.GenerateRequest(searchArguments[i]);

                    Console.Write(engine.Name + ": " + engine.TotalResults + " ");

                    if (engine.TotalResults > results[j].ResultNumber)
                        this.SetResult(j, engine.TotalResults, searchArguments[i], engine.Name);

                    //For the overall winner
                    if (engine.TotalResults > results[engines.Count].ResultNumber)
                        this.SetResult(engines.Count, engine.TotalResults, searchArguments[i], engine.Name);
                }

                Console.WriteLine("\n");
            }
        }
    }
}
