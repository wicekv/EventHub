# EventHub Application

Welcome to **EventHub**, your go-to application for managing and participating in events! Our platform allows users to easily register, create their own events, and join events organized by others.

## Features

- **User Registration**: Sign up to create your personal account and start interacting with events.
- **User Login**: Securely log in to access and manage your events.
- **Create Events**: Host your events by specifying details such as the event name, description, date, and location.
- **Join Events**: Browse and join events created by other users to participate in community gatherings, workshops, and more.

## Getting Started

### Prerequisites

Before you can run the application, make sure you have the following installed:
- [.NET Core SDK](https://dotnet.microsoft.com/download) (version specified in `global.json`)
- An IDE like [Visual Studio](https://visualstudio.microsoft.com/), [VS Code](https://code.visualstudio.com/) or similar

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/EventHub.git
2. Change to the project directory:
   ```bash
   cd EventHub
3. Restore all necessary .NET Core packages needed for the project:
   ```bash
   dotnet restore
4. Build the project to ensure there are no compilation errors:
   ```bash
   dotnet build

5. Start the application by running:
   ```bash
   dotnet run --project EventHub
