RiverBooks
RiverBooks is a modular monolith application designed to manage book orders, user accounts, and email notifications using a clean architecture approach. The project utilizes MediatR for handling commands and queries, FluentValidation for input validation, and background services for processing outbox messages.

Table of Contents
Features
Technologies Used
Getting Started
Prerequisites
Installation
Running the Application
Project Structure
Contributing
License
Features
Modular monolith architecture
Domain-driven design
MediatR for request/response handling
FluentValidation for input validation
Background services for outbox processing
Integration with external services
Technologies Used
ASP.NET Core
MediatR
FluentValidation
Entity Framework Core
MongoDB
Redis
Docker
Getting Started
Prerequisites
.NET 6 SDK
Docker
Installation
Clone the repository:

sh
Copy code
git clone https://github.com/MehrdadJannesar/RiverBooks.git
cd RiverBooks
Build the Docker images:

sh
Copy code
docker-compose build
Running the Application
Start the Docker containers:

sh
Copy code
docker-compose up
The application will be available at http://localhost:5000.

Docker Configuration
The application uses the following Docker images:

SQL Server: mcr.microsoft.com/mssql/server:2022-latest
Redis: redis
Papercut: jijiechen/papercut:latest
MongoDB: mongo
Docker Compose is configured to start and link these services automatically. Make sure Docker is running on your machine before starting the application.

Project Structure
src: Contains all the source code
RiverBooks.Users: User module
RiverBooks.Orders: Order processing module
RiverBooks.SharedKernel: Shared kernel for common utilities and services
tests: Contains all the test projects
Contributing
Fork the repository.
Create your feature branch (git checkout -b feature/fooBar).
Commit your changes (git commit -am 'Add some fooBar').
Push to the branch (git push origin feature/fooBar).
Create a new Pull Request.
License
This project is licensed under the MIT License - see the LICENSE file for details.
