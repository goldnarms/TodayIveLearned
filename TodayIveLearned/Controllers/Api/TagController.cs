using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodayIveLearned.Models;

namespace TodayIveLearned.Controllers.Api
{
    public class TagController : ApiController
    {
        private readonly List<Tag> _tags;

        public TagController()
        {
            _tags = new List<Tag> { new Tag { Id = 1, Name = "Life" }, new Tag { Id = 2, Name = "Programming" } };
        }
        // GET api/<controller>
        public IEnumerable<Tag> Get()
        {
            return _tags;
        }

        // GET api/<controller>/5
        public Tag Get(int id)
        {
            return _tags.SingleOrDefault(s => s.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Tag value)
        {
            _tags.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Tag value)
        {
            _tags.Remove(_tags.SingleOrDefault(s => s.Id == id));
            _tags.Add(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _tags.Remove(_tags.SingleOrDefault(s => s.Id == id));
        }
    }
}