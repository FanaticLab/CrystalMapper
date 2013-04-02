# Crystal Mapper #
High performance and easy to use object relational mapping library very large scale financial systems. Crystal Mapper ensure type safety via LINQ and allows to query database directly without any adherence. It is used in number of successful projects and is amazingly fast compare to industry standard ORMs.

CodeSmith templates helps you generate classes quickly, each class correspond to single table in database. It helps to maintain clean separation of database interfacing code with business logic. I also like to recommend [Application Architecture](http://codestand.feedbook.org/2011/02/application-architecture.html "Application Architecture") that will ensure reusability using MVC pattern.

[http://www.fanaticlab.com/projects/crystalmapper//documentation](http://www.fanaticlab.com/projects/crystalmapper//documentation "Documentation")

Templates are integral part of ORM. you can download Generator from http://www.codesmithtools.com. 

#### Speed Test (mysql 100, 000 iterations) ####

* DataSet					00:00:17.161
* Crystal Mapper			00:00:15.782
* Crystal Mapper via LINQ	00:00:19.261
 
#### Getting Started ####

* Download CrystalMapper – 1.4.0.0.zip and extract project to any folder.
* Open CrystalMapper solution under Implementation folder.
* Run Crystal Mapper.Test to see it in action.


#### Release 2.4.0.0 ####

Bug Fixes
Removed EntityCollection/Child table relations for simplicity and performance
New IQueryable function ToDonymous returns List of Donymous objects (http://coresystem.codeplex.com). It is faster than DataTable and allows you to access columns as properties when used as dynamic object, you can used it in Razor templates.
Note: Dynamic runtime is slow than static, so it should be avoid where possible.

#### Release 2.3.0.0 ####

* New IQueryable functions 'ForUpdate' and 'ForUpdateAll' for MySQL and PostgreSQL databases in CrystalMapper.Linq namespace
* Performance enhancements in LINQ to SQL compilation
* MySQL and PostgreSql support