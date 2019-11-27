using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookApi.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength =10, ErrorMessage ="Headline must be between 10 and 200 characters")]
        public string Headline { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 50, ErrorMessage = "Review must be between 10 and 200 characters")]
        public string ReviewText { get; set; }
        public virtual ICollection<Reviewer> Reviewers{ get; set; }
        public virtual Book Book { get; set; }

    }
}
