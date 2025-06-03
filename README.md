# 🛠️ Product API – ASP.NET Core Web API

This is a simple RESTful API built with **ASP.NET Core** and **Entity Framework Core** that allows managing a list of products. It supports CRUD operations and integrates with a SQL Server database.

## 🚀 Features

* Get all products
* Get product by ID
* Create new product
* Update existing product
* Delete product
* Swagger UI for testing endpoints
* CORS enabled for Angular frontend

## 📦 Tech Stack

* ASP.NET Core 8 (or your version)
* Entity Framework Core
* SQL Server
* Swagger / Swashbuckle
* Dependency Injection (Scoped Repositories)
* LINQ & Async methods

## 🔧 Endpoints

All endpoints are under:

```
http://localhost:5293/api/Products
```

| Method | Endpoint             | Description        |
| ------ | -------------------- | ------------------ |
| GET    | `/api/Products`      | Get all products   |
| GET    | `/api/Products/{id}` | Get product by ID  |
| POST   | `/api/Products`      | Create new product |
| PUT    | `/api/Products`      | Update a product   |
| DELETE | `/api/Products/{id}` | Delete a product   |

## 🧱 Model

```csharp
public class Product
{
    public int ID { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string? Details { get; set; }
    public int SKU { get; set; }
}
```

## ⚙️ Setup Instructions

1. **Clone the repo**

   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name
   ```

2. **Update `appsettings.json`**
   Set your connection string for SQL Server.

3. **Apply migrations & seed database**

   ```bash
   dotnet ef database update
   ```

4. **Run the application**

   ```bash
   dotnet run
   ```

5. **Test API in Swagger**
   Navigate to:

   ```
   http://localhost:5293/swagger
   ```

## 🔐 CORS Configuration

CORS is enabled in `Program.cs` to allow requests from Angular frontend at `http://localhost:4200`.

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});
```

## 📂 Folder Structure

```
├── Controllers/
│   └── ProductController.cs
├── Data/
│   └── GeneralDbContext.cs
├── Models/
│   └── Product.cs
├── Repositories/
│   └── ProductRepo.cs
├── Program.cs
```

## 📜 License

MIT
