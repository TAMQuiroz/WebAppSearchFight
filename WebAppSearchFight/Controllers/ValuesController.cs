using searchfight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppSearchFight.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public Result [] Post([FromBody]string [] searchArguments)
        {
            SearchEngineManager engines = new SearchEngineManager();
            ResultsCalculator results = new ResultsCalculator(engines, searchArguments);
            ResultsOutputter output = new ResultsOutputter(results);
            return output.GetResults();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
