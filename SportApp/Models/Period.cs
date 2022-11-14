using System;
using System.Collections.Generic;

namespace SportApp.Models
{
    public partial class Period
    {
        public Period()
        {
            People = new HashSet<Person>();
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public long? GroupId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
