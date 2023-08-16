using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace BlogApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postService;

        public PostsController(IPostRepository postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            var posts = _postService.GetPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public ActionResult<Post> GetPostById(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public ActionResult<Post> CreatePost(Post post)
        {
            var createdPost = _postService.CreatePost(post.Title, post.Content);
            return CreatedAtAction(nameof(GetPostById), new { id = createdPost.Id }, createdPost);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            try
            {
                _postService.UpdatePost(post);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePost(int id)
        {
            var deleted = _postService.DeletePost(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
