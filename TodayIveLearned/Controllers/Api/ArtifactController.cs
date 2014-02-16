using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TodayIveLearned.Models;

namespace TodayIveLearned.Controllers.Api
{
    public class ArtifactController : ApiController
    {
        private List<Artifact> _artifacts;
        public ArtifactController()
        {
            _artifacts = new List<Artifact>
            {
                new Artifact
                {
                    Id = 1,
                    Description = "Test",
                    Title = "Angular Routes",
                    Topic =
                        new Topic
                        {
                            Id = 1,
                            Name = "AngularJS",
                            Description = "MVC Framework",
                            Category = new Category {Id = 1, Name = "Programming", Description = "For Nerds only"}
                        }
                }
            };
        }
        // GET api/<controller>
        public IEnumerable<Artifact> Get()
        {
            return _artifacts;
        }

        // GET api/<controller>/5
        public Artifact Get(int id)
        {
            return _artifacts.SingleOrDefault(a => a.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Artifact value)
        {
            _artifacts.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Artifact value)
        {
            _artifacts.Remove(_artifacts.SingleOrDefault(a => a.Id == id));
            _artifacts.Add(value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            _artifacts.Remove(_artifacts.SingleOrDefault(a => a.Id == id));
        }
    }
}