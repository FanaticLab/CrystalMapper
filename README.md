# Why CrystalMapper?

**CrystalMapper is object relation mapping library for C#, that is fast, simple and encourages rapid development for database driven applications**

Developed for high performance large scale financial systems, used in number of successful projects. It is amazingly fast even with LINQ as compare to other ORMs. It fits very well into MVC pattern and supports multitier applications … please read simple [application architecture breakdown](http://codestand.feedbook.org/2011/02/application-architecture.html) that utilizes CrystalMapper as an ORM. It is design to maintain clean separation of database, where Model only have to understand CrystalMapper API. Templates for generating mapping classes are integral part of the ORM.

## Speed

It competes directly with ADO.NET DataSet, following are some stats for MySQL database. It proves to be faster than other leading ORMs

* DataSet					**17.161 sec**
* Crystal Mapper			**15.782 sec**
* Crystal Mapper & LINQ	    **19.261 sec**
 
## Getting Started

* Download lastest release from the download page.
* Open CrystalMapper solution under Implementation folder.
* Run CrystalMapper.Test in debug mode to see it in action; everything just works.

