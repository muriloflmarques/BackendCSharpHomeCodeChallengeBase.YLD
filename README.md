# YLD Gaming API - Murilo Lobato

The current repository was forked from "Yld Home Code Challenge (Backend C#)"

This solution uses .NET 6 and implements DDD (Domain-Driven Design) keeping focus on classes that represent the "business" area. As it's a simple application that merely maps data from one HTTP call into a GET endpoint, it might appear as an overkill, but being aware of how to grow and scale applications since day 1 is still more important than caping it to bare minimum.

The solution holds Common, Domain, Repository, Service and the WeAPI projects that are referencing only one other project (except by Common), the order being WeAPI references Service that references Repository that references Domain that references Common, although this “reference chain” is not mandatory, it creates an easy to follow approach where you send down a flow of information towards the the Repository or retrieve it from the ame project going all the way “up” on the stream.

The solution is solving a simple task, reading data as JSON from a GET endpoint held by a third-party entity and mapping it back to our very similar but smaller classes. There are a few other requirements to be performed before making the data available, the original dataset is descending sorted by “releaseDate” and then, if the user has specified an offset and limit are applied to the sorted list to skip the offset amount and finally only take the quantity informed.

The Offset and Limit values currently hold the following restrictions: offset is an integer with minimum value of 0, maximum of max int and when uninformed holds the default value; the Limit is an integer with minimum value of 0, maximum of 10 and when uninformed holds the value of 2.

For the purpose of this application whenever an invalid value is informed for Limit, 400 is the HTTP response. 

For the purpose of this application whenever the request header “User-Agent” is absent, 400 is the HTTP response.

Unit testing were done using NUnit and Moq.
