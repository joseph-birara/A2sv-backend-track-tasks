using BlogApi.Application.Interfaces;
using BlogApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApi.WebApi.Controllers
{
    [ApiController]
    [Route("api/posts/{postId}/[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentService;

        public CommentsController(ICommentRepository commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetCommentById(int postId, int id)
        {
            var comment = _commentService.GetCommentById(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpPost]
        public ActionResult<Comment> AddComment(int postId, Comment comment)
        {
            var addedComment = _commentService.AddComment(postId, comment.Text);
            return CreatedAtAction(nameof(GetCommentById), new { postId, id = addedComment.Id }, addedComment);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateComment(int postId, int id, Comment comment)
        {
            if (id != comment.Id)
            {
                return BadRequest();
            }

            try
            {
                _commentService.UpdateComment(comment);
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComment(int postId, int id)
        {
            var deleted = _commentService.DeleteComment(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
