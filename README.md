# JobListing CRUD App

A **modern, responsive job listing web application** built using **ASP.NET 8 MVC**, **Entity Framework Core**, and **SQLite**, developed and tested on **Ubuntu Linux** with **JetBrains Rider**.

---

![screenshot](screenshots/joblisting_main.png)

## ✨ Features

- **Full CRUD** (Create, Read, Update, Delete) operations for job postings
- **Entity Framework Core** integration with **SQLite** for lightweight, cross-platform data storage
- **Modern Bootstrap 5 UI** with clean, easy-to-navigate screens
- Organized **MVC architecture**
- Sample seed data for instant usability
- Designed and developed using **JetBrains Rider** on Linux for a smooth cross-platform development experience

---

## 🚀 Quick Start

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [JetBrains Rider](https://www.jetbrains.com/rider/) (or any C# IDE)
- (Optional) [TablePlus](https://tableplus.com/) for DB inspection

---

### 1. Clone the Repository
```
git clone https://github.com/Surveinit/JobListings.git
cd JobListings
```


---

### 2. Install Dependencies
```
dotnet restore
```

---

### 3. Create and Migrate the Database
```
dotnet ef database update
```

This creates a `JobListingApp.db` SQLite file in the project root.

---

### 4. Run the App
```
dotnet run
```

---

## 🏗️ Project Structure

| Folder          | Description                        |
|-----------------|------------------------------------|
| `Controllers/`  | MVC Controller logic               |
| `Models/`       | Data models (JobListing, etc.)     |
| `Views/`        | Razor view templates (Bootstrap)   |
| `Data/`         | EF Core DbContext                  |

---

## 🖼️ Screenshots

| Home / Index                        | Create New Listing                       |
|-------------------------------------|------------------------------------------|
| ![](screenshots/index.png)          | ![](screenshots/create.png)              |

---

## 🛠️ Technologies

- **ASP.NET Core 8 MVC**
- **Entity Framework Core**
- **SQLite**
- **Bootstrap 5**
- **JetBrains Rider** on **Linux**
- *(Tailwind or additional CSS is easily pluggable)*

---

## 🌟 Getting Help

- If you have issues or suggestions, open an [Issue](https://github.com/surveinit/JobListingApp/issues).
- Explore or tweak styles using Bootstrap or Tailwind CSS ([see your recent memory about CSS experimentation][1]).

---

## ✍️ Future plans 

-[X] **Switch to Tailwind**
- [ ] **Fix Nav bar: Where the current page is not highlighted.**
-[ ] **Full on JobPortal**: Company can post jobs and individual can apply for job.
