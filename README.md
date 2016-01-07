# MicroCQRS

MicroCQRS is a minimalistic example of the event sourcing pattern [CQRS](https://de.wikipedia.org/wiki/Command-Query-Responsibility-Segregation) implementation in C#.
It builds on the Domain-Drive-Design (DDD).

The following elements are not implemented due to the simplicity:
- Persistent Event Store
- Versioning
- Aggregation
- Asynchronuous behaviors
- Command chaining
- Momentos

# Advice and recommendation
CQRS is a great pattern to seperate queries (ex. read operations) from commands (ex. write operations), but CQRS has also a lot of disadvantages like
- Significantly more code than CRUD
- CQRS forces you to not mix domain or business logic with infrastructural operations
- One of the main targets is to improve read and write operations due to the great potentialities of scalability. Do you really have this requirement?

Due to this disadvantages it is not recommand to encompass the whole application by CQRS.
Check twice if CQRS is really usefull for the specific implementation.

# NuGet
The core project is available on NuGet
```
Install-Package MicroCQRS
```
