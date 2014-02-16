using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodayIveLearned.Models;

namespace TodayIveLearned.Controllers.Api
{
    public class TopicController : ApiController
    {
        private readonly List<Topic> _topics;

        public TopicController()
        {
            _topics = new List<Topic> {new Topic {Id = 1, Name = "Appearance", Category = new Category{ Id = 1, Name = "Life"}, Triggers = new List<Trigger> {new Trigger{Id= 1, Name = "shoe"}}}, new Topic { Id = 2, Name = "AngularJS", Category = new Category{ Id = 2, Name = "Programming"}, Triggers = new List<Trigger>{new Trigger{Id = 2, Name = "angular"}}}};
        }
        // GET api/<controller>
        public IEnumerable<Topic> Get()
        {
            return _topics;
        }

        // GET api/<controller>/5
        public Topic Get(int id)
        {
            return _topics.SingleOrDefault(s => s.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Topic value)
        {
            _topics.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Topic value)
        {
            _topics.Remove(_topics.SingleOrDefault(s => s.Id == id));
            _topics.Add(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _topics.Remove(_topics.SingleOrDefault(s => s.Id == id));
        }

        [HttpGet]
        [ActionName("Triggers")]
        public IEnumerable<Topic> Triggers(string text)
        {
            var words = text.ToLower().Split(new[] {",", " "}, StringSplitOptions.RemoveEmptyEntries);
            return _topics.Where(t => t.Triggers.Any(trigger => words.Contains(trigger.Name)));
        }
    }
}