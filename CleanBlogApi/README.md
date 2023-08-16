# CleanBlogApi

CleanBlogApi is a sample ASP.NET Core Web API project that demonstrates the implementation of a clean architecture for a blog application. The project is structured using the principles of clean architecture to ensure separation of concerns and maintainability.

## Project Structure

The project is organized into different layers, each responsible for a specific aspect of the application:

- **Domain:** Contains the domain entities and business logic.
- **Application:** Defines interfaces and implementations for application services.
- **Infrastructure:** Implements data storage and external services.
- **WebApi:** Provides the API endpoints and controllers.

## Features

- Create, retrieve, update, and delete posts.
- Add, retrieve, update, and delete comments on posts.

## Getting Started

1. **Clone the Repository:** Clone this repository to your local machine.

2. **Restore Packages:** Open the solution in Visual Studio or your preferred code editor and restore the NuGet packages.

3. **Set Up the Database (Optional):** The project currently uses an in-memory storage mechanism. For a real-world scenario, you can replace this with a database. Refer to the infrastructure layer for implementing data storage.

4. **Run the Application:** Build and run the WebApi project. The API will be accessible at `https://localhost:5001` (or another port if specified).

5. **API Documentation:** Swagger UI is available at `https://localhost:5001/swagger` for exploring and testing the API endpoints.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvements, feel free to open an issue or submit a pull request.


