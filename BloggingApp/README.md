# BloggingApp Project

This is a sample ASP.NET Core Web API project for a blogging application. The project includes controllers and repositories for managing posts and comments.

## Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Getting Started](#getting-started)
- [Usage](#usage)
- [Contributing](#contributing)
- [Used Tools and Packages](#used-tools-and-packages)



## Project Overview

The BloggingApp project is built using ASP.NET Core and follows the MVC architecture. It provides endpoints to manage blog posts and their associated comments.

The project consists of the following components:
- Controllers: The API endpoints for managing posts and comments.
- Models: Data models representing posts and comments.
- Repositories: Interfaces implementations for data access operations.
- Tests: Unit tests for the controllers and repositories.
- Interfaces: interfaces for the repository methods 

## Features

- Get a list of comments for a specific post.
- Get details of a single comment by comment ID.
- Create a new comment for a post.
- Update the text of an existing comment.
- Delete a comment.
- Add posts
- Delete posts 
- Update posts

## Used Tools and Packages

The BloggingApp project utilizes the following tools and packages:

- [ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core): A cross-platform, high-performance framework for building modern, cloud-based, and internet-connected applications.

- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/): An Object-Relational Mapping (ORM) framework that simplifies database interactions.

- [Moq](https://github.com/moq/moq4): A mocking library for .NET that allows you to create mock objects for unit testing.

- [XUnit](https://xunit.net/): A unit testing framework for .NET that supports test-driven development.

- [Swagger UI](https://swagger.io/tools/swagger-ui/): A tool for visualizing and interacting with APIs using a web interface.

- [Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/): A package for configuring and using dependency injection in ASP.NET Core applications.

- [Npgsql.EntityFrameworkCore.PostgreSQL](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/): A PostgreSQL provider for Entity Framework Core, allowing you to use PostgreSQL as the database backend.

## Installation

To install the required packages, you can use the NuGet Package Manager Console:

## Getting Started

1. Clone the repository to your local machine.
2. Open the `BloggingApp` project in your preferred development environment (e.g., Visual Studio, Visual Studio Code).
3. Restore NuGet packages and build the project.

## Usage

1. Run the application using the IDE or the command line.
2. Use tools like Swagger UI to interact with the API endpoints and test different operations.
3. Review and run the provided unit tests in the `Tests` folder.

## Contributing

Contributions are welcome! If you find any issues or want to add new features, feel free to submit a pull request.


