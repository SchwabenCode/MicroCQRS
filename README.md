# MicroCQRS

MicroCQRS is a minimalistic example of the event sourcing pattern [CQRS](https://de.wikipedia.org/wiki/Command-Query-Responsibility-Segregation) implementation in C#.

The following elements are not implemented due to the simplicity:
- Persistent Event Store
- Versioning
- Aggregation
- Asynchronuous behaviors
- Command chaining
- Momentos


The core project is available on NuGet
```
Install-Package MicroCQRS
```
