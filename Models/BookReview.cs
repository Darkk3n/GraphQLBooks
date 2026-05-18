using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLBooks.Models
{
    public class BookReview
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
        public DateTime ReviewDate { get; set; }
        public string User { get; set; }
    }
}