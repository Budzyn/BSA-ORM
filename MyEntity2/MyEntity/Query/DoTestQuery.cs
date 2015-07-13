using MyEntity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyEntity.Query
{
    public class DoTestQuery
    {
        private static Tests tt;

        public static void ShowDoTest()
        {
            using (var db = new MyContext())
            {
                var users = db.user.Select(item => item).ToList();
                var dts = new List<DoTest>
                {
                    new DoTest
                    {
                        Name = ".Net",
                        UserID = users[0].UserID,
                        Result = 30,
                        Time = 25,
                        Tests = tt,
                    },
                    new DoTest
                    {
                        Name = "JS",
                        UserID = users[1].UserID,
                        Result = 12,
                        Time = 50,
                        Tests = tt,
                    },
                    new DoTest
                    {
                        Name = ".Net",
                        UserID = users[2].UserID,
                        Result = 22,
                        Time = 15,
                        Tests = tt,
                    },
                    new DoTest
                    {
                        Name = "DB",
                        UserID = users[3].UserID,
                        Result = 26,
                        Time = 15,
                        Tests = tt,
                    },
                    new DoTest
                    {
                        Name = "JS",
                        UserID = users[4].UserID,
                        Result = 25,
                        Time = 15,
                        Tests = tt,
                    }
                };

                db.testdo.AddRange(dts);
                db.SaveChanges();
                var some = db.testdo.Select(item => item).ToList();
                Console.WriteLine("List of people who have passed the tests");
                var listTest = (from DoTest in dts where DoTest.Result > 22 select DoTest.UserID);
                foreach (var test in listTest)
                {
                    Console.WriteLine(test);
                }
                Console.WriteLine("Members list passed tests and invested in time");
                var listTest2 = (from DoTest in dts where DoTest.Result > 22 && DoTest.Time <= 20 select DoTest.UserID);
                foreach (var test2 in listTest2)
                {
                    Console.WriteLine(test2);
                }
                Console.WriteLine("Members list passed tests and is not invested in time");
                var listTest3 = (from DoTest in dts where DoTest.Result > 22 && DoTest.Time >= 20 select DoTest.UserID);
                foreach (var test3 in listTest3)
                {
                    Console.WriteLine(test3);
                }
                Console.WriteLine("List of successful students by city");
                var newResult = db.testdo.Where(item => item.Result > 22).GroupBy(s => s.Users.City, (key, g) => new { City = key, Count = g.Count() });
                foreach (var test in newResult)
                {
                    Console.WriteLine(test.City + ": " + test.Count);
                }
                Console.WriteLine("The result for each student");
                var rrr = (from DoTest in dts where DoTest.Result > 0 && DoTest.Time > 0 select new { DoTest.Result,DoTest.Time, DoTest.UserID});
                foreach (var rt in rrr)
                {
                    Console.WriteLine(rt);
                }
            }
        }
    }
}
