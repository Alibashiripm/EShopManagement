
# Eshop Management - Clean Architecture

This project is a comprehensive web Eshop application developed using ASP.NET and .NET 8, designed with a clean architecture to ensure maintainability, scalability, and testability.

## Features

- User Registration and Authentication: Secure user registration, login, and email activation.
  
-  User Orders: Track and manage user orders effectively.

-  Payment Integration: Integrated with Zarin Pal portal for seamless transactions.

-  Admin Panel: A full-featured admin panel for managing the store and user activities.

-  Access Level Control: Manage user roles and permissions to control access.

-  File Categories: Organize files into categories for better management.

-  File Segmentation: Allows for segmenting files for easier access and organization.

-  Filter and Search: Advanced filtering and search functionality for products and files.

-  Sales Invoice: Generate and manage sales invoices for orders.

-  Discount Codes: Create and manage discount codes for promotional purposes.

-  Commenting: Users can leave comments and reviews on products.

-  Special Membership: Offer special memberships with exclusive benefits.
-  Blog Section: A dedicated blog section for content marketing and updates.


## Technologies Used
 
- **ASP.NET Core**: For building the web application.
- **Entity Framework Core**: For database management.
- **SQL Server**: As the primary database.
- **AutoMapper**: For object-object mapping.
- **Swagger**: For API documentation.
- **xUnit**: For unit testing.
 
### Prerequisites

- .NET 8 SDK
- SQL Server
- VS (optional)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Alibashiripm/EShopManagement
2. Navigate to the project directory  
   ```bash
   for update database infra/for run MVC or Api
3. Restore dependencies:
   ```bash
   dotnet restore
4. Update the database:
   ```bash
   dotnet ef database update
5. Run the application:
   ```bash
   dotnet run
 ```
## Authors

- [@Alibashiripm](https://github.com/Alibashiripm)

