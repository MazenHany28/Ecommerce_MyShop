
# E-Commerce MVC Application Documentation

## ✅ Project Overview
A full-featured e-commerce platform built using ASP.NET Core MVC following the **NTier Architecture** (UI, Business Logic, Data Access). The application allows users to browse electronics (laptops, mobiles, cameras), add them to a cart, and complete purchases through Stripe payment integration. It also includes an admin panel for managing products, categories, and orders.

---

## 🧱 Architecture Overview

### NTier Architecture Layers:
- **Presentation Layer (UI)**  
  ASP.NET Core MVC UI responsible for rendering views and handling user interactions.

- **Business Logic Layer (BLL)**  
  Contains business rules, service logic, and validation.

- **Data Access Layer (DAL)**  
  EF Core Repositories and context for interacting with the database.

### Repository Pattern
Encapsulates data access logic. Helps achieve:
- Cleaner code
- Easier unit testing
- Lower coupling

### Unit of Work Pattern
Coordinates work across multiple repositories:
- Provides transactional integrity
- Commit once for all related operations

---

## 🚀 Live Demo
Visit the live deployed version here:

👉 **https://ecommercemyshop.runasp.net**

---

## 📥 Getting Started

### 1️⃣ Clone the Repository
```bash
git clone https://github.com/MazenHany28/Ecommerce_MyShop
```

### 2️⃣ Install Dependencies
- Ensure .NET SDK is installed
- Restore NuGet packages

```bash
dotnet restore
```

### 3️⃣ Update `appsettings.json`
Replace with your secrets:
- Connection String
- Stripe Public & Secret Keys


Example snippet:
```json
"ConnectionStrings": {
  "DefaultConnection": "your-db-connection-string"
},
"Stripe": {
  "SecretKey": "your-secret-key",
  "PublishableKey": "your-publishable-key"
}
```

### 4️⃣ Run the Application
```bash
dotnet run
```

---

## 👤 Admin Login Credentials

| Credential | Value |
|-----------|-------|
| Email | admin@admin.com |
| Username | admin |
| Password | Admin@123 |

⚠️ Please update these immediately in production.

---

## 💳 Stripe Payment Testing

Use the official test card:
```
Card Number: 4242 4242 4242 4242
Expiration: any future date
CVC: any 3 digits
ZIP: any value
```

---

## 🗄 SQL Dummy Data Note

If you seed dummy product data:
- Replace `AddedByUserId` with your admin `UserId` to prevent FK conflicts.

---

## 🧩 Features

✅ Identity authentication (Admin - Customer - Buyer)
✅ Buyer can create their products
✅ Users can edit their profiles and view their order history
✅ Product browsing & filtering  
✅ Shopping cart system  
✅ Stripe online payments  
✅ Admin panel  
✅ Buyer panel
✅ NTier architecture  
✅ Repository + Unit of Work  
✅ Session-based cart  
 

---

## 🔧 Features To Be Implemented

| Feature | Status |
|---------|--------|
| Email sender + email confirmation | ❌ |
| Download/delete profile data (GDPR) | ❌ |
| External login / register | ❌ |
| File uploads to wwwroot | ❌ |
| Redis distributed cache | ❌ |
| Stripe webhooks | ❌ |

Planned future work.

---



## ⚙️ Technology Stack

| Tech | Usage |
|------|--------|
| ASP.NET Core MVC | Main framework |
| Entity Framework Core | ORM |
| SQL Server | Database |
| Identity | Authentication |
| Stripe | Payments |
| Bootstrap | UI styling |

---

## 🧑‍💼 User Guide

### Shopping Experience
1. Browse categories/products
2. Add items to cart
3. Proceed to checkout
4. Enter payment details
5. Receive confirmation

### Admin Capabilities
- Create/update/delete products
- Manage categories
- View orders
- Control inventory

---


## 📬 Contact
For support or questions:
`mazen.kesba@gmail.com`

---

Happy Coding! 🎉
