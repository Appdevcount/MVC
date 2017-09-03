using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace MVC.EntityFrameworkBoard.CodeFirst
{
    public class CFDbContext : DbContext
    {
        public CFDbContext() : base("name=EFDFEntities")
        //base() Parameter less base constructor for creating DB with name {Namespace}.{Context class name} in Local SQLExpress
        //base("xyz") create DB with parameter string name in Local SQLExpress
        //base("name=xyz") for creating DB Objects in connection string DB
        {
            //Database Intialization Strategies //It can also be placed in Glbal.asax Application_start event method as seens in some project - verify the possibility
            Database.SetInitializer<CFDbContext>(new CreateDatabaseIfNotExists<CFDbContext>());
            //Database.SetInitializer<CFDbContext>(new DropCreateDatabaseIfModelChanges<CFDbContext>());
            //Database.SetInitializer<CFDbContext>(new DropCreateDatabaseAlways<CFDbContext>());
            //Database.SetInitializer<CFDbContext>(new SchoolDBInitializer());// can create custom DB Initializer 
            //by inheriting CreateDatabaseIfNotExists<CFDbContext> and can seed data to DB
            //Database.SetInitializer<SchoolDBContext>(null);//Disable initializer

            //Migration - Automatic Migration by using MigrateDatabaseToLatestVersion class with <context,migrationclass> as parameter
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CFDbContext, MVC.Migrations.Configuration>("name=EFDFEntities"));
            //public Configuration()
            //{
            //    AutomaticMigrationsEnabled = true;
            //}
            //To enable removal of properties which might cause dataloss .Set AutomaticMigrationDataLossAllowed = true in the configuration class constructor, along with AutomaticMigrationsEnabled = true.
        }
        public DbSet<CFStudent> CFStudents { get; set; }
        public DbSet<CFStandard> CFStandards { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here .  Code-First gives precedence to Fluent API > data annotations > default conventions.
            //DbModelBuilder class includes important properties and methods to configure

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.HasDefaultSchema("CF");

            //EntityTypeConfiguration Class obtained by calling the Entity<TEntity>() method of DbModelBuilder class 

            EntityTypeConfiguration<CFStudent> SEConfig = modelBuilder.Entity<CFStudent>();
            EntityTypeConfiguration<CFStandard> StdEConfig = modelBuilder.Entity<CFStandard>();
            // EntityTypeConfiguration Class Fluent API methods - http://www.entityframeworktutorial.net/code-first/entitytypeconfiguration-class.aspx

            //Configure Table
            SEConfig.ToTable("Student", "CF");
            SEConfig.Map(m =>// Map single entity to multiple table/Split table
            {
                m.Properties(p => new { p.StudentID, p.StudentName });
                m.ToTable("StudentInfo");

            }).Map(m =>
            {
                m.Properties(p => new { p.StudentID, p.Height, p.Weight, p.Photo, p.DateOfBirth });
                m.ToTable("StudentInfoDetail");

            });
            StdEConfig.ToTable("StandardInfo");

            //Configure properties
            SEConfig.HasKey<int>(s => s.StudentID);//PK
            StdEConfig.HasKey<int>(s => s.StandardId);
            SEConfig.HasKey(s => new { s.StudentID, s.StudentName });//Composite PK
            SEConfig.Property(p => p.DateOfBirth)// property definition
                    .HasColumnName("DoB")
                    .HasColumnOrder(3)
                    .HasColumnType("datetime2")
                    .IsOptional()//NULL
                    .IsRequired();//NOT NULL
            SEConfig.Property(p => p.Height)
                    .HasPrecision(2, 2);
            SEConfig.Property(p => p.StudentName)
                    .HasMaxLength(50)//Lenghth
                    .IsConcurrencyToken();//Concurrency Column .can also use IsRowVersion() method for byte[] property to make it as a concurrency column

            //Below methods are required for making relation between 2 table
            // .Has[required/optional]    .With[required/many]

            ////One to One
            ////modelBuilder.Entity<Student>()
            ////  .HasOptional(s => s.Address) // Mark Address property optional in Student entity
            ////  .WithRequired(ad => ad.Student); // mark Student property as required in StudentAddress entity. Cannot save StudentAddress without Student
            //// Configure StudentId as PK for StudentAddress
            //modelBuilder.Entity<StudentAddress>()
            //    .HasKey(e => e.StudentId);
            //// Configure StudentId as FK for StudentAddress
            //modelBuilder.Entity<Student>()
            //            .HasOptional(s => s.Address)
            //            .WithRequired(ad => ad.StudentId);
            ////one-to-many 
            //modelBuilder.Entity<Student>()
            //            .HasRequired<Standard>(s => s.Standard) // Student entity requires Standard 
            //            .WithMany(s => s.Students); // Standard entity includes many Students entities
            //modelBuilder.Entity<Student>()
            //       .HasRequired<Standard>(s => s.Standard)
            //       .WithMany(s => s.Students)
            //       .HasForeignKey(s => s.StdId);
            //modelBuilder.Entity<Standard>()
            //      .HasMany<Student>(s => s.Students) Standard has many Students
            //        .WithRequired(s => s.Standard)  Student require one Standard
            //        .HasForeignKey(s => s.StdId); Student includes specified foreignkey property name for Standard
            ////Nullable foreign key for one-to-many relationship.
            // modelBuilder.Entity<Student>()
            //   .HasOptional<Standard>(s => s.Standard)
            //   .WithMany(s => s.Students)
            //   .HasForeignKey(s => s.StdId);
            //Many to Many relationship- http://www.entityframeworktutorial.net/code-first/configure-many-to-many-relationship-in-code-first.aspx
            //modelBuilder.Entity<Student>()
            //.HasMany<Course>(s => s.Courses)
            //.WithMany(c => c.Students)
            //.Map(cs =>
            //{
            //    cs.MapLeftKey("StudentRefId");
            //    cs.MapRightKey("CourseRefId");
            //    cs.ToTable("StudentCourse");
            //});

            //BydefaultCascade delte is enabled in Entity Framework, we can turn off by Fluent API
            //modelBuilder.Entity<Student>()
            //.HasOptional<Standard>(s => s.Standard)
            //.WithMany()
            //.WillCascadeOnDelete(false);

            //We can move all Student related configuration to StudentEntityConfiguration class
            modelBuilder.Configurations.Add(new StudentEntityConfiguration());

            //CodeFirst SPROC
            //Automatically creates a stored procedure for Student entity using Fluent API.
            SEConfig.MapToStoredProcedures();
            //Can also change the stored procedure and parameter names
            SEConfig.MapToStoredProcedures(p =>
            p.Insert(sp => sp.HasName("sp_InsertStudent").Parameter(pm => pm.StudentName, "name").Result(rs => rs.StudentID, "Student_ID"))
           .Update(sp => sp.HasName("sp_UpdateStudent").Parameter(pm => pm.StudentName, "name"))
           .Delete(sp => sp.HasName("sp_DeleteStudent").Parameter(pm => pm.StudentID, "Id"))
            );

            //If you want all your entities to use stored procedures
            //SEConfig.Types().Configure(t => t.MapToStoredProcedures());

            //base.OnModelCreating(modelBuilder);
			
			
			//For catching Entity model errors
			// try
// {
    // var user = model.GetUser();
    // var result = await UserManager.CreateAsync(user, model.Password);
// }
// catch (DbEntityValidationException dbEx)
// {
    // foreach (var validationErrors in dbEx.EntityValidationErrors)
    // {
        // foreach (var validationError in validationErrors.ValidationErrors)
        // {
            // Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
        // }
    // }
// }
			
        }

    }
    public class StudentEntityConfiguration : EntityTypeConfiguration<CFStudent>
    {
        public StudentEntityConfiguration()
        {
            this.ToTable("StudentInfo");
        }
    }
    public class SchoolDBInitializer : CreateDatabaseIfNotExists<CFDbContext>
    {
        protected override void Seed(CFDbContext context)
        {
            IList<CFStandard> defaultStandards = new List<CFStandard>();

            defaultStandards.Add(new CFStandard() { StandardName = "Standard 1", StandardId = 1 });
            defaultStandards.Add(new CFStandard() { StandardName = "Standard 2", StandardId = 2 });
            defaultStandards.Add(new CFStandard() { StandardName = "Standard 3", StandardId = 3 });

            foreach (CFStandard std in defaultStandards)
                context.CFStandards.Add(std);

            //var enrollments = new List<Enrollment>
            //{
            //new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            //new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            //new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            //new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            //new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            //new Enrollment{StudentID=3,CourseID=1050},
            //new Enrollment{StudentID=4,CourseID=1050,},
            //new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            //new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            //new Enrollment{StudentID=6,CourseID=1045},
            //new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            //};
            //enrollments.ForEach(s => context.Enrollments.Add(s));
            //context.SaveChanges();

            base.Seed(context);
        }
    }

}