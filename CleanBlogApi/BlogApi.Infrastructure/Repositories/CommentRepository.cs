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

        public void Create(Comment comment)
        {
            _comments.Add(comment);
        }

        public Comment GetById(int commentId)
        {
            return _comments.FirstOrDefault(comment => comment.Id == commentId);
        }

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return _comments.Where(comment => comment.PostId == postId).ToList();
        }

        public void Update(Comment comment)
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

        public bool Delete(int commentId)
        {
            var existingComment = _comments.FirstOrDefault(comment => comment.Id == commentId);
            if (existingComment != null)
            {
                _comments.Remove(existingComment);
                return true;
            }
            return false;
        }
    }
}
