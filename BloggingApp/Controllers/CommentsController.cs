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
    [Route("api/posts/{postId}/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;

        public CommentsController(ICommentRepository commentRepository, IPostRepository postRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetCommentsByPostId(int postId)
        {
            var comments = await _commentRepository.GetCommentsByPostIdAsync(postId);
            return Ok(comments);
        }

        [HttpGet("{commentId}")]
        public async Task<ActionResult<Comment>> GetComment(int commentId)
        {
            var comment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public async Task<ActionResult> CreateComment(int postId, Comment comment)
        {
            var post = await _postRepository.GetPostByIdAsync(postId);
            if (post == null)
            {
                return NotFound();
            }
            
            comment.PostId = postId;
            await _commentRepository.CreateCommentAsync(comment);
            return CreatedAtAction(nameof(GetComment), new { commentId = comment.CommentId }, comment);
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult> UpdateComment(int commentId, Comment updatedComment)
        {
            var existingComment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (existingComment == null)
            {
                return NotFound();
            }
            
            existingComment.Text = updatedComment.Text;
            
            await _commentRepository.UpdateCommentAsync(existingComment);
            return NoContent();
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            var existingComment = await _commentRepository.GetCommentByIdAsync(commentId);
            if (existingComment == null)
            {
                return NotFound();
            }
            
            await _commentRepository.DeleteCommentAsync(commentId);
            return NoContent();
        }
    }
}
