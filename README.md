# AbbreviationQuiz

A full-stack quiz app for learning software abbreviations.

## Stack

- **Backend**: ASP.NET Core 9 Web API + Entity Framework Core + SQLite
- **Frontend**: React 19 + TypeScript + Vite

## Running locally

### Backend

```bash
cd AbbreviationQuiz.Api
dotnet run
```

API runs at http://localhost:5000. Swagger UI at http://localhost:5000/swagger.

### Frontend

```bash
cd abbreviation-quiz-client
npm install
npm run dev
```

App runs at http://localhost:5173. API calls are proxied to `http://localhost:5000`.

## API Endpoints

| Method | Path | Description |
|--------|------|-------------|
| GET | `/api/quiz/random` | Get a random abbreviation |
| GET | `/api/abbreviations` | Get all abbreviations |
| POST | `/api/abbreviations` | Add a new abbreviation |
