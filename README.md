# RiverBooks

RiverBooks is a modular monolith application designed to manage book orders, user accounts, and email notifications using a clean architecture approach. The project utilizes MediatR for handling commands and queries, FluentValidation for input validation, and background services for processing outbox messages.

## Table of Contents

- [Features](#features)
- [Technologies Used](#technologies-used)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Installation](#installation)
  - [Running the Application](#running-the-application)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- Modular monolith architecture
- Domain-driven design
- MediatR for request/response handling
- FluentValidation for input validation
- Background services for outbox processing
- Integration with external services

## Technologies Used

- ASP.NET Core
- MediatR
- FluentValidation
- Entity Framework Core
- MongoDB
- Redis
- Docker

## Getting Started

### Prerequisites

- .NET 6 SDK
- Docker

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/MehrdadJannesar/RiverBooks.git
    cd RiverBooks
    ```

2. Build the Docker images:
    ```sh
    docker-compose build
    ```

### Running the Application

1. Start the Docker containers:
    ```sh
    docker-compose up
    ```

2. The application will be available at `http://localhost:5000`.

### Docker Configuration

The application uses the following Docker images:

- **SQL Server**: `mcr.microsoft.com/mssql/server:2022-latest`
- **Redis**: `redis`
- **Papercut**: `jijiechen/papercut:latest`
- **MongoDB**: `mongo`

Docker Compose is configured to start and link these services automatically. Make sure Docker is running on your machine before starting the application.

## Project Structure

- **src**: Contains all the source code
  - **RiverBooks.Users**: User module
  - **RiverBooks.Orders**: Order processing module
  - **RiverBooks.SharedKernel**: Shared kernel for common utilities and services
- **tests**: Contains all the test projects

## Contributing

1. Fork the repository.
2. Create your feature branch (`git checkout -b feature/fooBar`).
3. Commit your changes (`git commit -am 'Add some fooBar'`).
4. Push to the branch (`git push origin feature/fooBar`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
