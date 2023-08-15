// IPostService.cs
using BlogApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogApi.Application.Interfaces
{
    public interface IPostService
    {
        Post CreatePost(string title, string content);
        Post GetPostById(int postId);
        List<Post> GetPosts();
        // Other methods for updating, deleting, etc.
    }
}

using BlogApi.Domain.Entities;
using System.Collections.Generic;

namespace BlogApi.Application.Interfaces
{
    public interface IPostService
    {
        Post CreatePost(string title, string content);
        Post GetPostById(int postId);
        List<Post> GetPosts();
        void UpdatePost(Post post);
        bool DeletePost(int postId);
    }
}
