using System;

namespace BloggingApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation property for the associated Post
        public Post Post { get; set; }
    }
}
