# CI och skyddad main

`main` är skyddad med ett ruleset:

- Alla ändringar måste gå via pull request.
- Kontrollen **`ci-ok`** måste vara grön innan merge.
- Force push och radering av `main` är blockerade.

## Varför bara `ci-ok`?

`backend-ci.yml` har tre jobb:

| Jobb             | Körs                         | Gör                                  |
| ---------------- | ---------------------------- | ------------------------------------ |
| `changes`        | alltid                       | kollar om backend-kod har ändrats    |
| `build-and-test` | bara om kod har ändrats      | format, build och test               |
| `ci-ok`          | alltid                       | blir röd om något jobb ovan failade  |

Om `build-and-test` vore krävd skulle en PR som bara ändrar dokumentation
fastna på "Waiting for status to be reported", eftersom jobbet aldrig startar.
`ci-ok` körs alltid och rapporterar därför alltid ett resultat.
