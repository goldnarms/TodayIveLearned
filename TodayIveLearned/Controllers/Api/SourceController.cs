using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodayIveLearned.Models;

namespace TodayIveLearned.Controllers.Api
{
    public class SourceController : ApiController
    {
        private List<Source> _sources;

        public SourceController()
        {
            _sources = new List<Source> {new Source {Id = 1, Name = "Blog"}, new Source { Id = 2, Name = "Friend"}};
        }
        // GET api/<controller>
        public IEnumerable<Source> Get()
        {
            return _sources;
        }

        // GET api/<controller>/5
        public Source Get(int id)
        {
            return _sources.SingleOrDefault(s => s.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Source value)
        {
            _sources.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Source value)
        {
            _sources.Remove(_sources.SingleOrDefault(s => s.Id == id));
            _sources.Add(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _sources.Remove(_sources.SingleOrDefault(s => s.Id == id));
        }
    }
}