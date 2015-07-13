using MyEntity.Entity;
using MyEntity.Query;



using System;
namespace MyEntity
{
    class Program
    {

        static void Main(string[] args)
        {
            UsersQuery.ShowUsers();
            TestsQuery.ShowTests();
            DoTestQuery.ShowDoTest();
            TeacherQuery.ShowTeacher();
            Console.ReadKey();
        }
    }
}
