using BlogApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogApi.Application.Interfaces
{
    public interface ICommentRepository
    {
        Comment AddComment(int postId, string text);
        Comment GetCommentById(int commentId);
        void UpdateComment(Comment comment);
        bool DeleteComment(int commentId);
    }
}
