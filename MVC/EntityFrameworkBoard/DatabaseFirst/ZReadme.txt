SPROC Mapping to Table Entity from dessginer
============================================
After Importing Table and SPROC in Database First Modal
Need to map Tables wth SPROC by right clicking on Table in desgner for SPROC mapping,
Once SPROC and its parameters are mapped with Table entity types, 
The mapping can be validated for any run time error by right clicking and selecting Validate from Table in designer
The funtion imports are generated for the SPROC after the mapping

In Insert SPROC , we are returning last generated Identity column value as return value

Table Mapping
=============
By default on Database first the Table columns are mapped with Entity Type properties

POCO[Normal .NET Class] Class and Dynamic POCO Proxy Class
=======================================
Dynamic Proxy class allows lazy loading and change tracking 

A POCO class must be declared with public access.
A POCO class must not be sealed (NotInheritable in Visual Basic)
A POCO class must not be abstract (MustInherit in Visual Basic).
Each navigation property must be declared as public, virtual
Each collection property must be ICollection<T>
ProxyCreationEnabled option must NOT be false (default is true) in context class

context.Configuration.ProxyCreationEnabled = false;

