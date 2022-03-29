# Introduction 
This project resolve the **FinancialChat** requirements related to the new system for chatbot and chatroom between users, including Authentication.

# Getting Started
This project is based on the framework .NET 5.0 built into Visual Studio 2019 Community, using technologies like as:
- Entity Framework Core
- LinQ
- Swagger
- JWT Authentication
- Automapper
- Azure Service Bus
- Microsoft Tests
- Blazor

DB use for is based on SQL Server.

This project is focused mainly in OOP design, also has consideration of some techniques:
- DDD architecture
- N-Layre architecture
- Repository and Singleton patterns
- Dependency injection (DI for IoC)
- SOLID principles
- Exceptions handling
- Lazy approach for DbSet's

# Build
Prior to build/run the project in Visual Studio, please execute the prepared scripts (*FinancialChat.Sql*) in a new DB called **FinancialChatDB**.

Update the connection string that is allocated in the *appsettings.json*.
Update the Keys/Secrets for Service Bus (it will be send by separated e-mail).
Update API endpoints in Blazor App.

When you execute the project you can test the REST API endpoints directly in Swagger or maybe using Postman or any Rest client. You could:
1. Create a new user (*/api/UserManagement/RegisterUser*)
2. Login with the user registered (*/api/UserManagement/LoginUser*)
3. Send a new message to an user or a command format (*/api/ChatManagement/SendMessage*)
4. View last 50 messages in a chat channel (*/api/ChatManagement/GetMessages*)

# Test
This project includes a GUI with blazor to allow interact with the operations.
This project will be published in [Azure]() currently, to allow to test end-to-end the endpoints quickly. Azure has the same data configured in the Scripts included in the project.