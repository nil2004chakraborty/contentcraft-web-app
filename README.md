# ContentCraft

A basic blog management web application with CRUD functionality, built using .NET Core and Angular.

## Table of Contents

* [Project Overview](#project-overview)
* [Current Features](#current-features)
* [Planned Features & Future Enhancements](#planned-features--future-enhancements)
* [Technologies Used](#technologies-used)
* [Setup Instructions](#setup-instructions)
    * [Prerequisites](#prerequisites)
    * [Backend Setup (.NET Core)](#backend-setup-net-core)
    * [Frontend Setup (Angular)](#frontend-setup-angular)
    * [Database Setup (PostgreSQL)](#database-setup-postgresql)
    * [Running the Application](#running-the-application)
* [Contributing](#contributing)
* [License](#license)
* [Contact](#contact)

## Project Overview

ContentCraft is a web application designed to simplify the creation, management, and publication of blog content. This initial version provides basic Create, Read, Update, and Delete (CRUD) operations for managing blog posts and users. It serves as a foundation for future enhancements and the integration of modern web development trends.

## Current Features

* **User Management:**
    * Create new user accounts.
    * View existing users.
    * Update user information.
    * Delete user accounts.
* **Post Management:**
    * Create new blog posts with titles and descriptions.
    * View a list of all blog posts.
    * View the details of a specific blog post.
    * Edit existing blog posts.
    * Delete blog posts.
* **Categorization (Basic):**
    * Ability to assign a category to blog posts (currently a simple integer).
* **Publishing Status:**
    * Mark blog posts as published or not published.
* **Date Tracking:**
    * Automatic recording of the post creation date.

## Planned Features & Future Enhancements

In future iterations, I plan to explore and integrate the following modern trends and features:

* **AI Integration:** Implement AI-powered features such as content generation suggestions, SEO optimization, and grammar/style analysis to enhance the writing process.
* **Headless CMS Architecture:** Investigate decoupling the .NET Core backend to serve content via APIs, allowing for potential future expansion to mobile apps or other platforms.
* **Rich Text Editor:** Integrate a WYSIWYG editor for more user-friendly content creation.
* **Image/Media Management:** Allow users to upload and manage images and other media within their blog posts.
* **Tagging:** Implement a tagging system for better content organization and discoverability.
* **Improved User Experience:** Develop a more modern and intuitive user interface in Angular, potentially incorporating real-time collaboration features for content creation.
* **GraphQL API:** Consider implementing a GraphQL API for more efficient and flexible data fetching on the frontend.
* **Authentication & Authorization:** Implement secure user authentication and role-based authorization.
* **Search Functionality:** Allow users to search for blog posts based on keywords.

## Technologies Used

* **Backend:** [.NET Core](https://dotnet.microsoft.com/download)
* **Frontend:** [Angular](https://angular.io/)
* **Database:** [PostgreSQL](https://www.postgresql.org/download/)
* **Version Control:** [Git](https://git-scm.com/)
* **Code Hosting:** [GitHub](https://github.com/)

## Setup Instructions

This section provides instructions on how to set up and run the ContentCraft application on your local machine.

### Prerequisites

Before you begin, ensure you have the following installed:

* [.NET Core SDK](https://dotnet.microsoft.com/download) (version compatible with your backend project)
* [Node.js](https://nodejs.org/) and [npm](https://www.npmjs.com/) (for Angular)
* [Angular CLI](https://angular.io/cli) (install globally using `npm install -g @angular/cli`)
* [PostgreSQL](https://www.postgresql.org/download/) installed and running.
* A code editor (e.g., [Visual Studio Code](https://code.visualstudio.com/), [Visual Studio](https://visualstudio.microsoft.com/), [Sublime Text](https://www.sublimetext.com/))

### Backend Setup (.NET Core)

1.  Navigate to the `Backend` directory in your project:
    ```bash
    cd Backend
    ```
2.  Restore NuGet packages:
    ```bash
    dotnet restore
    ```
3.  Configure the database connection in `appsettings.json`. **Important: Ensure you do not commit sensitive credentials to a public repository. Consider using environment variables in a production setting.** You will need to provide the connection string for your PostgreSQL database. Example:
    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Host=localhost;Port=5432;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword;"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }
    ```
    **Replace `YourDatabaseName`, `YourUsername`, and `YourPassword` with your PostgreSQL credentials.**
4.  If you are using Entity Framework Core Migrations, apply them:
    ```bash
    dotnet ef database update
    ```
    (Make sure you have the `dotnet-ef` tool installed: `dotnet tool install --global dotnet-ef`)

### Frontend Setup (Angular)

1.  Navigate to the `Frontend` directory:
    ```bash
    cd Frontend
    ```
2.  Install npm dependencies:
    ```bash
    npm install
    ```
3.  Configure the API endpoint in your Angular service files (e.g., `environment.ts`). Update the base URL to point to your .NET Core backend API. Example:
    ```typescript
    export const environment = {
      production: false,
      apiUrl: 'https://localhost:5001/api' // Adjust the port if your backend runs on a different one
    };
    ```

### Database Setup (PostgreSQL)

1.  Ensure your PostgreSQL server is running.
2.  Create the database (if it doesn't exist) using a tool like pgAdmin or the `psql` command-line interface. The database name should match the one specified in your backend's `appsettings.json`.
    ```sql
    CREATE DATABASE YourDatabaseName;
    ```
3.  Run the `schema.sql` file located in the `Database` directory to create the necessary tables. You can use a tool like pgAdmin to execute this script.

### Running the Application

1.  **Backend (.NET Core):**
    Navigate to the `Backend` directory in your terminal and run:
    ```bash
    dotnet run
    ```
    This will start your .NET Core API. Take note of the port it's running on (usually `https://localhost:5001` or `http://localhost:5000`).

2.  **Frontend (Angular):**
    Open a new terminal, navigate to the `Frontend` directory, and run:
    ```bash
    ng serve -o
    ```
    This will build and serve your Angular application, usually on `http://localhost:4200`. The `-o` flag will automatically open it in your default browser.

## Contributing

If you'd like to contribute to the development of ContentCraft, please follow these steps:

1.  Fork the repository on GitHub.
2.  Create a new branch for your feature or bug fix (`git checkout -b feature/your-feature-name`).
3.  Make your changes and commit them (`git commit -am 'Add new feature'`).
4.  Push to the branch (`git push origin feature/your-feature-name`).
5.  Open a pull request on GitHub.

## License

[You can add a license here if you choose to (e.g., MIT License, Apache 2.0). A common way to do this is to create a `LICENSE` file in the root of your repository and then refer to it here. For example: `This project is licensed under the [MIT License](LICENSE).`]

## Contact

Nilakshi Chakraborty - chakraborty.nilakshi2004@gmail.com 

---

This is a comprehensive starting point for your `README.md` file. Feel free to adjust the content and add more details as your project evolves. Remember to keep it up-to-date!
