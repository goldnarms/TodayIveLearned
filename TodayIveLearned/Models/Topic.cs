using System.Collections.Generic;
using System.Security.AccessControl;

namespace TodayIveLearned.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public List<Trigger> Triggers { get; set; }
    }
}