using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogApi.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> _posts = new List<Post>();

        public void Create(Post post)
        {
            _posts.Add(post);
        }

        public Post GetById(int postId)
        {
            return _posts.FirstOrDefault(post => post.Id == postId);
        }

        public List<Post> GetPosts()
        {
            return _posts.ToList();
        }

        public void Update(Post post)
        {
            var existingPost = _posts.FirstOrDefault(p => p.Id == post.Id);
            if (existingPost != null)
            {
                existingPost.Title = post.Title;
                existingPost.Content = post.Content;
            }
            else
            {
                throw new InvalidOperationException("Post not found");
            }
        }

        public bool Delete(int postId)
        {
            var existingPost = _posts.FirstOrDefault(post => post.Id == postId);
            if (existingPost != null)
            {
                _posts.Remove(existingPost);
                return true;
            }
            return false;
        }
    }
}
