using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodayIveLearned.Models;

namespace TodayIveLearned.Controllers.Api
{
    public class CategoryController : ApiController
    {
        private readonly List<Category> _categories;

        public CategoryController()
        {
            _categories = new List<Category> {new Category {Id = 1, Name = "Life"}, new Category { Id = 2, Name = "Programming"}};
        }
        // GET api/<controller>
        public IEnumerable<Category> Get()
        {
            return _categories;
        }

        // GET api/<controller>/5
        public Category Get(int id)
        {
            return _categories.SingleOrDefault(s => s.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Category value)
        {
            _categories.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Category value)
        {
            _categories.Remove(_categories.SingleOrDefault(s => s.Id == id));
            _categories.Add(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _categories.Remove(_categories.SingleOrDefault(s => s.Id == id));
        }
    }
}