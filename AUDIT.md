# Kodgranskning – BudgetApp

Granskad: 2026-11-09
Poäng: 0 = saknas, 1 = finns lite, 2 = sitter bra

## Steg 1: Starta från noll – det här fick jag "bara veta"

- README säger inte vilket Postgres-lösenord som förväntas eller hur man sätter det.
- README säger att man ska redigera `appsettings.json`, men filen finns inte i repot.
- `Jwt:Secret` måste sättas, annars kraschar API:t – står inte i README.
- `dotnet restore` behövdes innan `dotnet ef database update`.
- Migrationer körs automatiskt vid start – står inte i README.
- Frontend: `.env` måste skapas, men den ignorerades inte av git (åtgärdat i frontend PR #35).

## Steg 2: Checklista

### Hur koden är byggd

| Punkt | Poäng | Kommentar |
|---|---|---|
| Tunna controllers, logik i services | 2 | Controllers skickar vidare till MediatR. Men samma try/catch är kopierad i varje metod. |
| DTOs används | 2 | Alla handlers returnerar DTOs, inga entiteter skickas ut. |
| Frontend går att hitta i | 2 | Uppdelad i pages, components, hooks, services, helpers. |

### Hur koden mår

| Punkt | Poäng | Kommentar |
|---|---|---|
| Tester, ett kommando | 1 | 27 NUnit-tester för handlers (`dotnet test`). Inga tester i frontend. |
| Servern validerar data | 1 | Validators finns bara för Create, inte Update. Valideringsfel blir 500 i stället för 400 eftersom controllers fångar alla exceptions. |
| Vettiga felmeddelanden | 1 | Backend skickar `ex.Message` med 500. Tom `catch {}` i Dashboard. `alert()` på flera ställen. |
| Laddning och tom lista | 1 | Laddning visas, men inga meddelanden när listor är tomma. |

### Hur repot fungerar för ett team

| Punkt | Poäng | Kommentar |
|---|---|---|
| README räcker | 1 | Saknar user-secrets, Jwt:Secret och hänvisar till fil som inte finns. |
| bin/obj/node_modules utanför git | 2 | Inga byggfiler i git. |
| Inga lösenord/nycklar | 0 | Lösenord och JWT-secrets i git-historiken. Admin-lösenord i `DbInitializer.cs`. `.env` saknades i frontendens `.gitignore` (åtgärdat i frontend PR #35). |
| Commit-historik | 1 | Mest tydliga meddelanden, men även "fix" och "Add files via upload". Plus: `main` är skyddad och kräver pull requests. |
| Formatering | 0 | `prettier --check`: 26 filer avviker. Ingen Prettier-konfiguration. |

## Mina fem viktigaste förbättringar

1. **Säkra hemligheterna** – byt JWT-secret och lösenord, flytta admin-lösenordet till konfiguration. (`.env` i frontendens `.gitignore` är redan åtgärdat.)
2. **Global felhantering i backend** – ta bort try/catch i controllers, lägg till middleware som ger 400/404/500 utan interna detaljer.
3. **Validera Update-kommandona** – validators för UpdateBudget, UpdateCategory, UpdateTransaction.
4. **Skriv om README** – Postgres, user-secrets, Jwt:Secret, hur man kör tester.
5. **Bättre tillstånd i frontend** – meddelanden för tomma listor, inga tomma `catch {}`, visa fel på sidan i stället för `alert()`.