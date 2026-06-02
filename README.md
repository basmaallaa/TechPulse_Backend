# TechPulse — Backend (.NET)

> The server responsible for storing and retrieving article data

---

## What Does This Project Do?

This is the behind-the-scenes server that the website talks to. Its job is to:
- **Save** new articles to the database
- **Retrieve** all articles when the website requests them
- **Delete** articles when a user asks
- **Store** article images on the server

---

## Built With

| Tool | What it does |
|------|-------------|
| **ASP.NET Core** | The main framework that runs the server |
| **SQL Server** | The database that stores all articles |
| **Entity Framework** | Talks to the database so we don't have to write raw SQL |
| **AutoMapper** | Converts data between different formats automatically |

---

## Running It on Your Machine

**Step 1 —** Make sure you have these installed:
- 👉 [.NET 8 SDK](https://dotnet.microsoft.com/download)
- 👉 [SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (free)

**Step 2 —** Open `appsettings.json` and update the database connection:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=TechPulseDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

> Change `Server=.` if your database is on a different machine.

**Step 3 —** Open your Terminal and run:

```bash
# Download the project files
git clone https://github.com/your-username/techpulse-backend.git
cd techpulse-backend/TechPulse.PL

# Create the database
dotnet ef database update

# Start the server
dotnet run
```

**Step 4 —** The server will be running at:
🌐 `https://localhost:7271`

---

## Project Files — What's What?

The project is split into 3 layers — each layer has one job and one job only:

```
TechPulse.sln
│
├── 📡 TechPulse.PL  (Presentation Layer)
│   └── Receives requests from the website and sends back responses
│
├── 🧠 TechPulse.BL  (Business Layer)
│   └── Checks that data is valid before saving it
│
└── 🗄️ TechPulse.DAL (Data Access Layer)
    └── Talks directly to the database
```

**Why split it this way?**
If you ever want to swap out the database or change a business rule,
you only touch one layer — the rest of the code stays the same.

---

## API — What Requests Does the Server Accept?

| Request | URL | What it does |
|---------|-----|-------------|
| `GET` | `/api/Post` | Returns all articles |
| `POST` | `/api/Post` | Saves a new article |
| `DELETE` | `/api/Post/{id}` | Deletes an article by its ID |

---

## Where Are Images Stored?

Images are saved in this folder on the server:
```
TechPulse.PL/wwwroot/uploads/
```

And they're accessible at:
```
https://localhost:7271/uploads/image-name.jpg
```

When an article is deleted, its image is automatically deleted too.

---

## What Do Server Responses Look Like?

Every response from the server follows the same structure,
so the website always knows what to expect:

```json
{
  "data": { ... },              ← The actual content (articles, etc.)
  "message": "Success",         ← A human-readable message
  "isSuccess": true             ← Did it work? true or false
}
```

---

## Connecting Frontend to Backend

The server is configured to only accept requests from `http://localhost:4200`.

If you run the website on a different address, open `Program.cs` and update this line:

```csharp
policy.WithOrigins("http://localhost:4200") // ← change this
```
