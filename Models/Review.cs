using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Headline { get; set; }
        public string ReviewText { get; set; }
        public virtual ICollection<Reviewer> Reviewers{ get; set; }
        public virtual Book Book { get; set; }

    }
}
