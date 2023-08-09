using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BloggingApp.Models;
using BloggingApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using BloggingApp.Interfaces;

namespace BloggingApp.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetPosts()
        {
            var posts = await _postRepository.GetAllPostsAsync();
            return Ok(posts);
        }

        [HttpGet("{postId}")]
        public async Task<ActionResult<Post>> GetPost(int postId)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePost(Post post)
        {
            await _postRepository.CreatePostAsync(post);
            return CreatedAtAction(nameof(GetPost), new { postId = post.PostId }, post);
        }

        [HttpPut("{postId}")]
        public async Task<ActionResult> UpdatePost(int postId, Post updatedPost)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
            {
                return NotFound();
            }
            
            existingPost.Title = updatedPost.Title;
            existingPost.Content = updatedPost.Content;
            
            await _postRepository.UpdatePostAsync(existingPost);
            return NoContent();
        }

        [HttpDelete("{postId}")]
        public async Task<ActionResult> DeletePost(int postId)
        {
            var existingPost = await _postRepository.GetPostByIdAsync(postId);
            if (existingPost == null)
            {
                return NotFound();
            }
            
            await _postRepository.DeletePostAsync(postId);
            return NoContent();
        }
    }
}
