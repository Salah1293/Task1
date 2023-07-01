# Task1


		-- I've used (SOLID principles - repository pattern - unit of work - dependency injection - dto - automapper)--

 --> SOLID priciple I've used:-

	1- single responsibility: Any method in the application has one and only one responsibility to act with the application
		and you can find that in repositories folder that contain a repo for each class functions and each function
		has only one perpose to act.

	2- open-closed: The code respects that principle as a mehod serves one aim for the respect of the prev principle
		and when there a need for a new modification i extend the method to enhance it ( methods are in interface container
		for each class and i extend it in a class of that interface container and add the features as needed).

	3- interface segregation: each interface is designed to perform one job and they are all in one job class so, i am not going
		to be forced to use all method when i deal with that class .. the interfaces are in interfaces folder and classes
		that implements those interfaces are in repositories folder.

	4- dependency inversion: i've made interfaces depends on abstraction rather than on a concrete implementation
		so, i provide flexibility and adaptability to changing requirments .. and you can find those abstracted interfaces
		in each repository for the classes such as (IproductsRepository).


 --> design patterns and services I've used:-
	
	1- repoository pattern: it has made my code organised and clean by have queries inside repositories instead of controllers 
		and it reduces queries duplications and it makes a layer for the code that deals with database seperated from
		the layer that deals with the business logic .. it also makes controller dependancy of entity framework to another
		layer so, if the organization has decided to change EF to dapper or change database provider to such as (sql)
		to another on such as (postgresql).
		you can find it with interfaces in (interfaces) folder and job class that implements interfaces in (repository) folder.

	2- unit of work: it gather all my transactions of CRUD operations in a single transaction .. you find it in (Iunit of work , unit of work) fils.

	3-Dependency Injection: I've injected repositories to unit of work so i can access classes -thats are accessed itself from repositories- 
		from unit of work.

	3- dto: it enables me to pass data with multiple attributes in one shot from client to server and vice-versa .. and you cand find it in (Dtos) folder.

	4- auto mapper: it maps different objects attributes so it takes out of my hands how to map those different objects .. you find it
		in (MappingProfile) file inside (helpers) folder.
