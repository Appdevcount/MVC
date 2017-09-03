Code First
==========
->Domain Classes created at First with default EF Conventions //not create a column for a property which does not have either getters or setters or NotMapped Attribute
  can be overridden with Data Annotations or FluentAPI by overriding OnModelcreating() method, DbModelBuilder class includes important properties and methods to configure
  Code-First gives precedence to Fluent API > data annotations > default conventions.
->Context class created with DB source in base constructor parameter
->Once Domain class and Context class is created ,
  if we instantiate the context class for any CRUD  then the DB Objects will be created at first
            using (var ctx = new CFDbContext())
            {
                CFStudent stud = new CFStudent() { StudentName = "New Student" };

                ctx.CFStudents.Add(stud);
                ctx.SaveChanges();
            }
->Migration/Change applying in DB in 2 ways - Automatic Migration , Code based migration
->Automatic[This migration method takes are of all changes and does the migration to latest version automatically when app runs]
  COMMAND : enable-migrations –EnableAutomaticMigration:$true in Package Manager Console creates an internal sealed Configuration class in the Migration folder 
  //Migration - Automatic Migration by using MigrateDatabaseToLatestVersion class with <context,migrationclass> as parameter
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFDbContext, MVC.Migrations.Configuration>("name=EFDFEntities"));
            //public Configuration()
            //{
            //    AutomaticMigrationsEnabled = true;
            //}
            //To enable removal of properties which might cause dataloss .Set AutomaticMigrationDataLossAllowed = true in the configuration class constructor, along with AutomaticMigrationsEnabled = true.
 Note: You can find more information about parameters that we can pass to the enable-migrations command 
  using the "get-help enable-migrations" command. For more detailed help use "get-help enable-migrations –detailed"

->Code based
  COMMAND : enable-migration , add-migration "",update-database [-verbose], Rollback DB Changes by update-database -TargetMigration:"First School DB schema"
  //Migration - Code based Migration by using MigrateDatabaseToLatestVersion class with <context,migrationclass> as parameter
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFDbContext, MVC.Migrations.Configuration>("name=EFDFEntities"));
            //public Configuration()
            //{
            //    AutomaticMigrationsEnabled = true;
            //}
            //To enable removal of properties which might cause dataloss .Set AutomaticMigrationDataLossAllowed = true in the configuration class constructor, along with AutomaticMigrationsEnabled = true.
 Note: Add-Migration command Syntax:
    Add-Migration [-Name] <String> [-Force]
      [-ProjectName <String>] [-StartUpProjectName <String>]
      [-ConfigurationTypeName <String>] [-ConnectionStringName <String>]
      [-IgnoreChanges] [<CommonParameters>]
    Add-Migration [-Name] <String> [-Force]
      [-ProjectName <String>] [-StartUpProjectName <String>]
      [-ConfigurationTypeName <String>] -ConnectionString <String>
      -ConnectionProviderName <String> [-IgnoreChanges] [<Common Parameters>]

The are 2 POCO classes in Entity framework - 
Entity types[Table mapping classes] 
Complex types[These don't have keys and not having mapping with tables but its properties are the subset of columns for referenced table]