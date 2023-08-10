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

public class PostsControllerTests
{
    

    [Fact]
    public async Task GetPost_ReturnsSinglePost()
    {
        // Arrange
        var postId = 1;
        var post = new Post { PostId = postId, Title = "Post 1", Content = "Content 1" };

        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(post);

        var controller = new PostsController(postRepositoryMock.Object);

        // Act
        var result = await controller.GetPost(postId);

        // Assert
        var actionResult = Assert.IsType<ActionResult<Post>>(result);
        var okObjectResult = Assert.IsType<OkObjectResult>(actionResult.Result);
        var returnedPost = Assert.IsAssignableFrom<Post>(okObjectResult.Value);
        Assert.Equal(post.PostId, returnedPost.PostId);
    }

    [Fact]
    public async Task CreatePost_ReturnsCreatedAtAction()
    {
        // Arrange
        var post = new Post { Title = "New Post", Content = "New Content" };

        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.CreatePostAsync(post)).Returns(Task.CompletedTask);

        var controller = new PostsController(postRepositoryMock.Object);

        // Act
        var result = await controller.CreatePost(post);

        // Assert
        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal(nameof(PostsController.GetPost), actionResult.ActionName);
    }

    [Fact]
    public async Task UpdatePost_ReturnsNoContent()
    {
        // Arrange
        var postId = 1;
        var updatedPost = new Post { PostId = postId, Title = "Updated Post", Content = "Updated Content" };

        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(updatedPost);

        var controller = new PostsController(postRepositoryMock.Object);

        // Act
        var result = await controller.UpdatePost(postId, updatedPost);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeletePost_ReturnsNoContent()
    {
        // Arrange
        var postId = 1;

        var postRepositoryMock = new Mock<IPostRepository>();
        postRepositoryMock.Setup(repo => repo.GetPostByIdAsync(postId)).ReturnsAsync(new Post());

        var controller = new PostsController(postRepositoryMock.Object);

        // Act
        var result = await controller.DeletePost(postId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
