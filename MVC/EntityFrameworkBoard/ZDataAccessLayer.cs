using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Validation;
using MVC.EntityFrameworkBoard.CodeFirst;
using System.Threading.Tasks;
using MVC.EntityFrameworkBoard.DatabaseFirst;


namespace MVC.EntityFrameworkBoard
{
    public class ZDataAccessLayer
    {
        //Object/Relational Mapping(ORM) framework that enables to work with Relational DataStore through domain-specific objects 
        //using LINQ

        //Database First
        public void DatabaseFirstHandler()
        {
            EFDFEntities DFctx = new EFDFEntities();

            //SPROC CRUD
            IEnumerable<GetCourses_Result> Courses = DFctx.GetCourses();
            IEnumerable<GetCoursesByStudentId_Result> CourseByStudID = DFctx.GetCoursesByStudentId(1);
            int CreatedStudID = DFctx.sp_InsertStudentInfo(1, "NewInsertName");
            DFctx.sp_UpdateStudent(1, 1, "UpdatedName");
            DFctx.sp_DeleteStudent(1);

            //Atomic Entity Operation with LINQ http://www.tutorialsteacher.com/linq/linq-filtering-operators-where
            Student stud1 = DFctx.Students.Find(1);//Find takes primary key value
            Student stud2 = DFctx.Students
                .Where(s => s.StudentName.Contains("") & s.StandardId == 1)
                .SingleOrDefault<Student>();
            Student stud3 = DFctx.Students
                .Where(s => s.Standard.Description.Contains("") & s.StudentAddress.City.Contains(""))
                .FirstOrDefault<Student>();
            Student stud4 = DFctx.Students
                .Where(s => s.StudentID > 1).FirstOrDefault(s => s.StudentName.Contains(""));
            var stud5 = DFctx.Students //using var  for taking few properties of a single object to anonymous object
                .Where(s => s.StudentID > 1)
                .Select(s => new { StudentID = s.StudentID, StudentAddress = s.StudentAddress });
            var stud6 = DFctx.Students //using var  for taking few properties of a single object, Have to use foreach
                .Where(s => s.StudentID > 1)
                .Select(s => new Student { StudentID = s.StudentID, StudentAddress = s.StudentAddress });

            IEnumerable<Student> stud7 = DFctx.Students
                .Where(s => s.StudentID > 1)
                .OrderByDescending(S => S.StudentName).ThenByDescending(S => S.StudentID)
                .Select(s => new Student { StudentID = s.StudentID, StudentAddress = s.StudentAddress });

            var GroupingStudent = DFctx.Students.GroupBy(s => s.StudentName);
            foreach (var Studname in GroupingStudent)
            {
                Console.WriteLine("Age Group: {0}", Studname.Key);  //Each group has a key 
                foreach (Student s in Studname)  //Each group has a inner collection  
                    Console.WriteLine("Student Name: {0}", s.StudentID);
            }

            //Join(is like inner join) takes takes five input parameters (except the first 'this' parameter):
            //1) outer 2) inner 3) outerKeySelector 4) innerKeySelector 5) resultSelector.
            var innerJoin = DFctx.Students // outer sequence
                            .Join(DFctx.Standards,  // inner sequence 
                                  student => student.StandardId,    // outer sequence KeySelector
                                  standard => standard.StandardId,  // inner sequence KeySelector
                                  (student, standard) => new  // Projection result
                                  {
                                      StudentName = student.StudentName,
                                      StandardName = standard.StandardName
                                  });

            //GroupJoin performs the same task as Join operator except that it joins two sequences based on key 
            //and groups the result by matching key and then returns the collection of grouped result and key.
            var groupJoin = DFctx.Standards // outer sequence
                            .Join(DFctx.Students,  // inner sequence 
                                  standard => standard.StandardId,  // outer sequence KeySelector
                                  student => student.StandardId,    // inner sequence KeySelector
                                  (standard, studentgroup) => new  // Projection result
                                  {
                                      Students = studentgroup,
                                      StandardName = standard.StandardName
                                  });

            //The Quantifier operators evaluate the condition and return a boolean value -All,Any,Contain
            bool StudentexistALL = DFctx.Students.All(s => s.StudentID > 10);
            bool StudentexistANY = DFctx.Students.Any(s => s.StudentID > 10);
            //Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            //bool result = studentList.Contains(std, new StudentComparer()); //returns true

            //The Aggregation operators for mathematical operations like Average, Aggregate, Count, Max, Min and Sum, 
            //on the numeric property of the elements in the collection
            double AvgstudID = DFctx.Students.Average(s => s.StudentID);
            double CountstudID = DFctx.Students.Count(s => s.StudentID > 10);
            double MAXMINSUMstudID = DFctx.Students.Max(s => s.StudentID);

            //The DefaultIfEmpty() method returns a new collection with the default value if the given collection on which DefaultIfEmpty() is invoked is empty.
            //IList<string> emptyList = new List<string>();
            //var newList1 = emptyList.DefaultIfEmpty();

            IEnumerable<Student> DistinctStuds = DFctx.Students.Distinct();

            IEnumerable<Student> UnionStuds = DFctx.Students.Where(s => s.StudentID > 5).Distinct()
                                              .Union(DFctx.Students.Where(s => s.StudentID < 5).Distinct());

            IEnumerable<Student> IntersectStuds = DFctx.Students.Where(s => s.StudentID > 5).Distinct()
                                              .Intersect(DFctx.Students.Where(s => s.StudentID < 5).Distinct());

            IEnumerable<Student> ExceptStuds = DFctx.Students.Where(s => s.StudentID > 5).Distinct()
                                              .Except(DFctx.Students.Where(s => s.StudentID < 5).Distinct());

            IEnumerable<Student> SkipTakeWhileStuds = DFctx.Students.Where(s => s.StudentID > 5).Distinct()
                                              .Except(DFctx.Students.Where(s => s.StudentID < 5).Distinct())
                                              .SkipWhile(s => s.StudentName.Length < 4);
            IEnumerable<Student> SkipTakeStuds = DFctx.Students.Where(s => s.StudentID > 5).Distinct()
                                              .Except(DFctx.Students.Where(s => s.StudentID < 5).Distinct())
                                              .Skip(4);//Skip 1st 4 elements in ordered sequence

            //The AsEnumerable and AsQueryable methods cast or convert a source object to IEnumerable<T> or IQueryable<T> respectively.
            //IList<string> strList = new List<string>() {
            //                                "One",
            //                                "Two",
            //                                "Three",
            //                                "Four",
            //                                "Three"
            //                                };
            //string[] strArray = strList.ToArray<string>();// converts List to Array
            //IList<string> list = strArray.ToList<string>(); // converts array into list
            //IList<Student> studentList = new List<Student>() {
            //        new Student() { StudentID = 1, StudentName = "John" } ,
            //        new Student() { StudentID = 2, StudentName = "Steve" } ,
            //        new Student() { StudentID = 3, StudentName = "Bill" } ,
            //        new Student() { StudentID = 4, StudentName = "Ram"  } ,
            //        new Student() { StudentID = 5, StudentName = "Ron"  }
            //    };
            ////following converts list into dictionary where StudentId is a key
            //IDictionary<int, Student> studentDict =
            //                                studentList.ToDictionary<Student, int>(s => s.StudentID);

            //Func Delegate<ParamterType,ReturnType>
            Func<Student, bool> MiddleStudIDs = s => s.StudentID > 12 && s.StudentID < 20;
            //Action Delegate<ParameterType>
            Action<Student> PrintStudentDetail = s => Console.WriteLine("Name: {0}, StudID: {1} ", s.StudentName, s.StudentID);
            Student std = new Student() { StudentName = "Bill", StudentID = 21 };
            PrintStudentDetail(std);//output: Name: Bill, Age: 21

            ////Multi Parameter lambda expression
            //(Student s, int youngAge) => s.StudentID >= youngage;
            ////Multi Line lambda expression
            //(Student s, int youngAge) =>
            //{
            //    int a = 0;
            //    s.StudentID >= youngage;
            //}

            //Deferred Execution - possible in LINQ SQL Query like syntax, until using foreach loop on that query

            //Immediate Execution - possible in Extension methods using converstion like .Tolist() 

            var stud9 = DFctx.Students //Converstion operator for result
                .Where(s => s.StudentID > 1).ToList<Student>();

        }

        ////Entity Framework Data Access Approaches / utilizing Database First Implementations
        //public void GenericDataAccessApproaches()
        //{
        //    EFDFEntities dbctx = new EFDFEntities();

        //    //Native SQL using SqlQuery()
        //    var stud1 = dbctx.Students.SqlQuery("Select studentid, studentname, standardId from Student where studentname='Bill'").FirstOrDefault<Student>();  
        // Using Parameterized query.
        //string query = "SELECT * FROM Department WHERE DepartmentID = @p0";
        //Department department = await db.Departments.SqlQuery(query, id).SingleOrDefaultAsync();
        //IQueryable<EnrollmentDateGroup> = from student in db.Students
        //           group student by student.EnrollmentDate into dateGroup
        //           select new EnrollmentDateGroup()
        //           {
        //               EnrollmentDate = dateGroup.Key,
        //               StudentCount = dateGroup.Count()
        //           };
        // SQL version of the above LINQ code.
        //string query = "SELECT EnrollmentDate, COUNT(*) AS StudentCount "
        //    + "FROM Person "
        //    + "WHERE Discriminator = 'Student' "
        //    + "GROUP BY EnrollmentDate";
        //IEnumerable<EnrollmentDateGroup> data = db.Database.SqlQuery<EnrollmentDateGroup>(query);
        //    ViewBag.RowsAffected = db.Database.ExecuteSqlCommand("UPDATE Course SET Credits = Credits * {0}", multiplier);

        //    //ExecuteSqlCommnad() method is useful in sending non-query commands to the database
        //    int noOfRowUpdated = dbctx.Database.ExecuteSqlCommand("Update student set studentname = 'changed student by command' where studentid = 1");
        //    int noOfRowInserted = dbctx.Database.ExecuteSqlCommand("insert into student(studentname) values('New Student')");
        //    int noOfRowDeleted = dbctx.Database.ExecuteSqlCommand("delete from student where studentid = 1");

        //    var stud2 = dbctx.Students.Find(1);
        //    dbctx.Students.Add(stud2);
        //    dbctx.Students.Remove(stud2);


        //    //Can get DBEntityEntry object of a particular entity by using Entry method of DBContext
        //    //to retrieve informations about the Entity 
        //    //-- Primarily usefull in Disconnected scenario[using same Dbcontext instance throughout the operation]
        //    stud1.StudentName = "UpdatedName";
        //    dbctx.Entry(stud1).State = System.Data.Entity.EntityState.Added;
        //    dbctx.Entry(stud1).State = System.Data.Entity.EntityState.Modified;
        //    dbctx.Entry(stud1).State = System.Data.Entity.EntityState.Deleted;
        //    //Parent Entity State              Entity State of child entities
        //    //Added                            Added
        //    //Modified                         Unchanged
        //    //Deleted                          All child entities will be null
        //    dbctx.SaveChanges();

        //    //We can add properties in entity with attribute [NotMapped] which wont have impact on DBTable
        //    //[NotMapped]
        //    //public int NoteMappedpropertyinEntity { get; set; }

        //    //RowVersion property /column in table generates unique binary number whenever the insert or update operation is performed in a table
        //    //[Timestamp]
        //    //public byte[] RowVersion { get; set; }
        //    //For concurrent update , if there is conflict , it will throw DbUpdateConcurrencyException
        //    //If Table created through Model , set concurrecy property to false

        //    //Enum properties can be used  
        //    //public int GrnderEnumType{ Male=1,Female=2 };
        //    //public GrnderEnumType Gender {get;set;}

        //    //Table - valued functions are similar to stored procedure with one key difference: 
        //    //the result of TVF is composable which means that it can be used in a LINQ query.
        //    // USE[SchoolDB]
        //    // GO
        //    // /****** Object:  UserDefinedFunction [dbo].[GetCourseListByStudentID]  */
        //    // SET ANSI_NULLS ON
        //    // GO
        //    // SET QUOTED_IDENTIFIER ON
        //    // GO
        //    // CREATE FUNCTION[dbo].[GetCourseListByStudentID]
        //    // (
        //    //     --Add the parameters for the function here
        //    //     @studentID int
        //    //)
        //    //             RETURNS TABLE
        //    // AS
        //    // RETURN
        //    // (
        //    //     --Add the SELECT statement with parameter references here
        //    //     select c.courseid, c.coursename, c.Location, c.TeacherId
        //    // from student s left outer join studentcourse sc on sc.studentid = s.studentid left outer join course c on c.courseid = sc.courseid
        //    // where s.studentid = @studentID
        //    // )
        //    //Execute TVF and filter result
        //    //var courseList = ctx.GetCourseListByStudentID(1).Where(c => c.Location.SpatialEquals(DbGeography.FromText("POINT(-122.360 47.656)"))))
        //    //                .ToList<GetCourseListByStudentID_Result>();


        //    //Eager Loading - Loads Child Entities by using Include() method on entity
        //    //can also use linq lambda expression in Include method. For this, take a reference of System.Data.Entity namespace or else as string "Standard.Teachers"
        //    var stud4 = dbctx.Students.Include(s => s.Standard.Teachers)
        //                            .Where(s => s.StudentName == "Student1")
        //                            .FirstOrDefault<Student>();

        //    //Lazy Loading - Loads Child Entities only when it is required through separate query
        //    dbctx.Configuration.LazyLoadingEnabled = false;//Can be disabled and its subset of dbctx.Configuration.ProxyCreationEnabled = false;
        //    //Loading students only
        //    IList<Student> studList = dbctx.Students.ToList<Student>();
        //    //Loads Student address for particular Student only (seperate SQL query)
        //    StudentAddress add = studList.ElementAtOrDefault<Student>(0).StudentAddress;

        //    //Even with lazy loading disabled, it is still possible to lazily load related entities using Reference()/Collection() and Load() method
        //    dbctx.Entry(stud4).Collection(s => s.Courses).Load();

        //    //Custom Entity validation at server side by override ValidateEntity method of DBContext - Reference Link http://www.entityframeworktutorial.net/EntityFramework4.3/validate-entity-in-entity-framework.aspx
        //    try
        //    {
        //        using (var ctx = new EFDFEntities())
        //        {
        //            ctx.Students.Add(new Student() { StudentName = "" });
        //            ctx.Standards.Add(new Standard() { StandardName = "" });

        //            ctx.SaveChanges();
        //        }
        //    }
        //    catch (DbEntityValidationException dbEx)
        //    {
        //        foreach (DbEntityValidationResult entityErr in dbEx.EntityValidationErrors)
        //        {
        //            foreach (DbValidationError error in entityErr.ValidationErrors)
        //            {
        //                Console.WriteLine("Error Property Name {0} : Error Message: {1}",
        //                                    error.PropertyName, error.ErrorMessage);
        //            }
        //        }
        //    }

        //}


        //We can take advantage of asynchronous execution of.Net 4.5 with Entity Framework.EF 6 has the ability to execute a query and command asynchronously using DbContext.
        //Asynchronous Query:
        private static async Task<CFStudent> GetStudent()
        {
            CFStudent myStudent = null;
            using (var context = new CFDbContext())
            {
                Console.WriteLine("Start GetStudent...");
                myStudent = await (context.CFStudents.Where(s => s.StudentID == 1).FirstOrDefaultAsync<CFStudent>());
                Console.WriteLine("Finished GetStudent...");
            }
            return myStudent;
            //student.wait().This means that the calling thread should wait until the asynchronous method completes, so we can do another process, until we get the result from the asynchronous method.
        }

        //Code First  
        //Domain Driven Design
        public void CodeFirstHandler()
        {
            //Once Domain class and Context class is created ,
            //if we instantiate the context class for any CRUD  then the DB Objects will be created at first
            using (var ctx = new CFDbContext())
            {
                CFStudent stud = new CFStudent() { StudentName = "New Student" };

                ctx.CFStudents.Add(stud);
                ctx.SaveChanges();
            }

            //Refer default Entity framework conventions on DB Object mapping - http://www.entityframeworktutorial.net/code-first/code-first-conventions.aspx

            //EF logs all the activity[Command queries] performed by EF using context.database.Log
            //Context.Database.Log is an Action<string> so that you can attach any method which has one string parameter and void return type.For example:
            //public class Logger
            //{
            //    public static void Log(string message)
            //    {
            //        Console.WriteLine("EF Message: {0} ", message);
            //    }
            //}        
            //using (var context = new CFDbContext())
            //{
            //    context.Database.Log = Logger.Log;
            //}
            //public class MyLogger
            //{
            //    public void Log(string component, string message)
            //    {
            //        //Can pass on the same to Log4Net as Info
            //        Console.WriteLine("Component: {0} Message: {1} ", component, message);
            //    }
            //}
            //using (var context = new BlogContext()) 
            //{ 
            //    var logger = new MyLogger();
            //    context.Database.Log = s => logger.Log("EFApp", s);
            //    var blog = context.Blogs.First(b => b.Title == "One Unicorn");
            //    blog.Posts.First().Title = "Green Eggs and Ham"; 
            //    blog.Posts.Add(new Post { Title = "I do not like them!" }); 
            //    context.SaveChangesAsync().Wait(); 
            //}
            //https://msdn.microsoft.com/en-us/library/dn469464(v=vs.113).aspx



            //Transaction Support
            //using (System.Data.Entity.DbContextTransaction dbTran = context.Database.BeginTransaction())
            //{
            //    try
            //    {

            //DbSet.AddRange/RemoveRange adds/remove collection(IEnumerable) of entities to the DbContext

            //CodeFirst SPROC


            //Inheritance Strategy in Code - First: not discissed in detail - http://www.entityframeworktutorial.net/code-first/inheritance-strategy-in-code-first.aspx
        }

    }
}

//////Refer Join Practices here D:\Holder\HTech\LINQ\LinqPad Queries



////Disposing can be done by Implementing IDisposable interface in CRUD Class as below
//// implements the IDisposable interface to ensure that the database connection is released when the object is disposed.
//public class SchoolRepository : IDisposable
//{
//    private SchoolEntities context = new SchoolEntities();

//    public IEnumerable<Department> GetDepartments()
//    {
//        return context.Departments.Include("Person").ToList();
//    }

//    //private bool disposedValue = false;

//    //protected virtual void Dispose(bool disposing)
//    //{
//    //    if (!this.disposedValue)
//    //    {
//    //        if (disposing)
//    //        {
//    //            context.Dispose();
//    //        }
//    //    }
//    //    this.disposedValue = true;
//    //}
//    //Below method is IDisposable interface member
//    //public void Dispose()
//    //{
//    //    Dispose(true);
//    //    GC.SuppressFinalize(this);
//    //}
//}

//As populating of million records takes time, I also increased command timeout to 15 minuntes.

//public class FooInitializer : DropCreateDatabaseIfModelChanges<FooContext>
//{
//    protected override void Seed(FooContext context)
//    {
//        ((IObjectContextAdapter)context).ObjectContext.CommandTimeout = 900;
