# Book Library Console App (EF Core Practice)

## Purpose

A short console application for practicing Entity Framework Core with a real database.

You will build a minimal library system where users, books, and authors are stored in a database using EF Core with full CRUD support.

---

## Database Tables

- **Users**
  - Id (int)
  - Name (string)

- **Authors**
  - Id (int)
  - Name (string)
  - Books (collection navigation)

- **Books**
  - Id (int)
  - Title (string)
  - AuthorId (FK)
  - Author (navigation)

Each book must be assigned to a single author (One-to-Many relationship).

---

## Functional Requirements

- [ ] Add a new user, book, or author
- [ ] List all books with their authors
- [ ] Update existing books or authors
- [ ] Delete a book or author
- [ ] Show how many books each author has written

---

## Technical Requirements

- EF Core (use SQLite for simplicity)
- Use `DbContext` for managing the database
- Define entities with relationships (One-to-Many between Authors and Books)
- Use `Migrations` to create and update the database schema
- Use `LINQ` to perform queries like aggregation (e.g., count of books per author)
- Keep code structured with folders: `Models`, `Data`, etc.

---

## Optional Functionality

- [ ] Add filtering or sorting (e.g., list books by author name)
- [ ] Allow user input from the console (menu-based interface)
- [ ] Use `ToList()`, `Include()`, `Count()` and other LINQ expressions for practice

---

## Goals

By the end of the project, you should be comfortable with:
- Creating models and relationships
- Configuring EF Core with a local database
- Performing CRUD with `DbContext`
- Writing LINQ queries over database data
- Using migrations to control schema

---

