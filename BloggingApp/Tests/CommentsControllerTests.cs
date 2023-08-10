using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using BloggingApp.Controllers;
using BloggingApp.Models;
using BloggingApp.Repositories;
using BloggingApp.Interfaces;

public class CommentsControllerTests
{
    // ... previous test methods

    [Fact]
    public async Task GetComment_ReturnsNotFound_ForInvalidCommentId()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.GetCommentByIdAsync(It.IsAny<int>())).ReturnsAsync((Comment)null);

        var controller = new CommentsController(commentRepositoryMock.Object, null);

        // Act
        var result = await controller.GetComment(1);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Comment>>(result);
        Assert.IsType<NotFoundResult>(actionResult.Result);
    }

    [Fact]
    public async Task CreateComment_ReturnsCreatedAtAction_ForValidInput()
    {
        // Arrange
        var postId = 1;
        var comment = new Comment { Text = "New Comment", PostId = postId };

        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(new Post());

        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.CreateCommentAsync(It.IsAny<Comment>()));

        var controller = new CommentsController(commentRepositoryMock.Object, postRepositoryMock.Object);

        // Act
        var result = await controller.CreateComment(postId, comment);

        // Assert
        var actionResult = Assert.IsType<ActionResult>(result);
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult);
        Assert.Equal(nameof(controller.GetComment), createdAtActionResult.ActionName);
    }

    // ... other test methods

    [Fact]
    public async Task UpdateComment_ReturnsNotFound_ForInvalidCommentId()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.GetCommentByIdAsync(It.IsAny<int>())).ReturnsAsync((Comment)null);

        var controller = new CommentsController(commentRepositoryMock.Object, null);

        // Act
        var result = await controller.UpdateComment(1, new Comment());

        // Assert
        var actionResult = Assert.IsType<NotFoundResult>(result);
        Assert.IsType<NotFoundResult>(actionResult);
    }

    [Fact]
    public async Task UpdateComment_ReturnsNoContent_ForValidInput()
    {
        // Arrange
        var commentId = 1;
        var existingComment = new Comment { CommentId = commentId, Text = "Existing Comment" };
        var updatedComment = new Comment { CommentId = commentId, Text = "Updated Comment" };

        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.GetCommentByIdAsync(commentId)).ReturnsAsync(existingComment);

        var controller = new CommentsController(commentRepositoryMock.Object, null);

        // Act
        var result = await controller.UpdateComment(commentId, updatedComment);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        Assert.IsType<NoContentResult>(actionResult);
        commentRepositoryMock.Verify(repo => repo.UpdateCommentAsync(updatedComment), Times.Once);
    }

    [Fact]
    public async Task DeleteComment_ReturnsNotFound_ForInvalidCommentId()
    {
        // Arrange
        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.GetCommentByIdAsync(It.IsAny<int>())).ReturnsAsync((Comment)null);

        var controller = new CommentsController(commentRepositoryMock.Object, null);

        // Act
        var result = await controller.DeleteComment(1);

        // Assert
        var actionResult = Assert.IsType<NotFoundResult>(result);
        Assert.IsType<NotFoundResult>(actionResult);
    }

    [Fact]
    public async Task DeleteComment_ReturnsNoContent_ForValidInput()
    {
        // Arrange
        var commentId = 1;
        var existingComment = new Comment { CommentId = commentId, Text = "Existing Comment" };

        var commentRepositoryMock = new Mock<ICommentRepository>();
        commentRepositoryMock.Setup(repo => repo.GetCommentByIdAsync(commentId)).ReturnsAsync(existingComment);

        var controller = new CommentsController(commentRepositoryMock.Object, null);

        // Act
        var result = await controller.DeleteComment(commentId);

        // Assert
        var actionResult = Assert.IsType<NoContentResult>(result);
        Assert.IsType<NoContentResult>(actionResult);
        commentRepositoryMock.Verify(repo => repo.DeleteCommentAsync(commentId), Times.Once);
    }
}
