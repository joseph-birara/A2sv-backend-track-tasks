using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly List<Comment> _comments = new List<Comment>();

        public Comment GetCommentById(int commentId)
        {
            return _comments.FirstOrDefault(comment => comment.Id == commentId);
        }

        public void UpdateComment(Comment comment)
        {
            var existingComment = _comments.FirstOrDefault(c => c.Id == comment.Id);
            if (existingComment != null)
            {
                existingComment.Text = comment.Text;
            }
            else
            {
                throw new InvalidOperationException("Comment not found");
            }
        }

        public bool DeleteComment(int commentId)
        {
            var existingComment = _comments.FirstOrDefault(comment => comment.Id == commentId);
            if (existingComment != null)
            {
                _comments.Remove(existingComment);
                return true;
            }
            return false;
        }

        public Comment AddComment(int postId, string text)
        {
            var newComment = new Comment
            {
                Id = _comments.Count + 1,
                Text = text,
                PostId = postId
            };

            _comments.Add(newComment);

            return newComment;
        }


    }
}
