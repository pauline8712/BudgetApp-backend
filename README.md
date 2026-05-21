# group-project-backend

## Local development

The backend uses **PostgreSQL** via `Npgsql.EntityFrameworkCore.PostgreSQL`. You need a running Postgres instance reachable from your machine before the API will start.

Default connection (in `BudgetApp.API/appsettings.json`):

```
Host=localhost;Port=5432;Database=BudgetAppDb;Username=postgres;Password=postgres
```

These are dev placeholders. **Don't commit real credentials.** Override locally with .NET User Secrets:

```powershell
dotnet user-secrets --project BudgetApp.API set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=<port>;Database=BudgetAppDb;Username=<user>;Password=<pwd>"
```

User Secrets auto-load when `ASPNETCORE_ENVIRONMENT=Development` (default in `launchSettings.json`).

> Note: port `5432` may be occupied by other Docker containers on shared dev machines. If yours runs on a different port, just set it via the command above — no code change needed.

Apply the schema:

```powershell
dotnet ef database update --project BudgetApp.Infrastructure --startup-project BudgetApp.API
```

Run the API:

```powershell
dotnet run --project BudgetApp.API
```

Swagger UI: `https://localhost:7057/swagger` (or `http://localhost:5123/swagger`).

---

## JWT Authentication

The API uses JWT (JSON Web Token) for authentication. Protected endpoints require a valid token in the `Authorization` header.

### Endpoints

| Method | URL | Description |
|---|---|---|
| POST | `/api/auth/register` | Register a new user |
| POST | `/api/auth/login` | Login and receive a JWT token |

### Register

```
POST http://localhost:5123/api/auth/register
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourPassword123!"
}
```

Response:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "email": "user@example.com",
  "role": "User"
}
```

### Login

```
POST http://localhost:5123/api/auth/login
Content-Type: application/json

{
  "email": "user@example.com",
  "password": "YourPassword123!"
}
```

### Using the token

Copy the token from the response and include it in the `Authorization` header for all protected requests:

```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

### Protected endpoints

All budget, category and transaction endpoints require a valid token:
- `GET /api/categories/{budgetId}` — returns 200 OK with token, 401 Unauthorized without

### Manual test results (Postman)

| Test | Expected | Result |
|---|---|---|
| POST /api/auth/register | 200 OK + token | ✅ |
| POST /api/auth/login | 200 OK + token | ✅ |
| GET /api/categories/{id} with token | 200 OK | ✅ |
| GET /api/categories/{id} without token | 401 Unauthorized | ✅ |

### appsettings.json — Jwt section

`appsettings.json` is gitignored (contains secrets). Copy `appsettings.example.json` and fill in your values:

```json
"Jwt": {
  "Secret": "YourSecretKeyAtLeast32CharactersLong!",
  "Issuer": "BudgetApp",
  "Audience": "BudgetAppUsers",
  "ExpiresInMinutes": 60
}
```
