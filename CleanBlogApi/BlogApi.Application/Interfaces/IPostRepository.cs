

using BlogApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogApi.Application.Interfaces
{
    public interface IPostRepository
    {
        Post CreatePost(string title, string content);
        Post GetPostById(int postId);
        List<Post> GetPosts();
        void UpdatePost(Post post);
        bool DeletePost(int postId);
    }
}
