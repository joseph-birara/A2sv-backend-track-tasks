using System;
using System.Collections.Generic; // Add this namespace for ICollection

namespace BloggingApp.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for the associated Comments
        public ICollection<Comment> Comments { get; set; }
    }
}
