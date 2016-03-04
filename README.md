# MicroCQRS

MicroCQRS is a minimalistic example of the event sourcing pattern [CQRS](https://de.wikipedia.org/wiki/Command-Query-Responsibility-Segregation) implementation in C#.
It builds on the Domain-Drive-Design (DDD).

The following elements are not implemented due to the simplicity:
- Persistent Event Store
- Versioning
- Aggregation
- Asynchronous behaviors
- Command chaining
- Momentos

But MicroCQRS here provides a special functionality: Notificators.
You can execute commands with the possibility to provide a frame to get information during the execution.

In the AddressManager example you can see, that the Database Add Commands are executing a passed Notificator to inform the caller when and with which ID the entry has been added.
But the same Command in the Tracing is not providing a Notificator.

# Advice and recommendation
CQRS is a great pattern to seperate queries (ex. read operations) from commands (ex. write operations) and gives you a huge potential to
- test your logic in a really nice way
- prove your behaviors
- to solve bottlenecks scale your application (horizontal) with a lot of servers in a lot of datacenters in many countries
- to run you application with multiple versions side-by-side without downtime due deployments or maintainance
- to implement concurrency mechanisms in an easy way

... but CQRS has also a lot of disadvantages like
- Significantly more code than CRUD
- CQRS forces you to not mix domain or business logic with infrastructural operations
- One of the main targets is to improve read and write operations due to the great potentialities of scalability. Do you really have this requirement?

Due to this disadvantages it is not recommended to encompass the whole application by CQRS.
Check twice if CQRS is really usefull for the specific purpose.

## For which kind of application / application parts CQRS is recommended?
- It is recommended for application with a huge difference in amount between read and write operations like a huge online shop 
- *add here more reasons and examples soon*

# NuGet
The core project is available on [NuGet](https://www.nuget.org/packages/MicroCQRS/) (at this point as preview!)
```
Install-Package MicroCQRS -Version 0.0.1-pre -Pre
```

# License
MIT

# Examples

## AddressManager
AddressManager is a sample application when to use NOT CQRS.
You can see: CRUD would be more simpel and less complicated here.

# Remarks
*here will be added something soon*
