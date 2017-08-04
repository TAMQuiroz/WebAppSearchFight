using System;

namespace searchfight
{
    public class Result
    {
        private string engineName;
        private long resultNumber;
        private string argumentName;

        public Result(int v = -1)
        {
            this.resultNumber = v;
        }

        public string EngineName { get; set; }
        public long ResultNumber { get; set; }
        public string ArgumentName { get; set; }
    }
}
