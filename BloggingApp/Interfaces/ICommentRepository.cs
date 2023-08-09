using System.Collections.Generic;
using System.Threading.Tasks;
using BloggingApp.Models;

namespace BloggingApp.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(int commentId);
    } // This is where the closing curly brace should be
}
