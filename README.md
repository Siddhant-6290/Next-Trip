# Tourism Management System (TMS)

A web application built with **ASP.NET Core MVC** and **Entity Framework Core** for managing tourism packages, user registrations, and bookings.  
This project is for learning purposes and demonstrates user authentication, role-based access, and package search functionality.

---

## 🚀 Features
- User Registration and Login  
- Role-based Authentication (**Admin** & **Customer**)  
- Hardcoded **Admin Credentials**:
  - **Email**: `admin@test.com`  
  - **Password**: `admin123`
- Customers can search and view tourism packages  
- Admins can manage packages (CRUD operations)  
- Session-based login system  
- Clean Bootstrap-based UI

---

## 🛠 Tech Stack
- **ASP.NET Core 8.0 (MVC)**
- **Entity Framework Core**
- **SQL Server LocalDB**
- **Bootstrap 5**
- **C#**

---

## 📂 Project Structure
TMS/
├── Controllers/ # MVC Controllers (Account, TourPackage, etc.)
├── Models/ # EF Core Models (User, Booking, Package)
├── Views/ # Razor Views (Login, Register, Index, etc.)
├── Data/ # TourismContext (EF Core DbContext)
├── wwwroot/ # Static files (CSS, JS, Images)
└── README.md # Project documentation




## ⚡ Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)  
- [SQL Server / LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)  
- Visual Studio / VS Code

### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/TMS.git

2.Navigate into the project:
cd TMS

3.Apply migrations (if needed):
dotnet ef database update

4.Run the project:
dotnet run



👤 Roles

Admin

Hardcoded credentials: admin@test.com / admin123

Can manage all packages

Customer

Registers via the Register page

Can search and view packages




