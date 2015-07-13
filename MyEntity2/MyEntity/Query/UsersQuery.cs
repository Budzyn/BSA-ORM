using MyEntity.Entity;
using System;
using System.Linq;
using System.Collections.Generic;


namespace MyEntity.Query
{
    public class UsersQuery
    {
        private static ICollection<DoTest> dts;

        public static void ShowUsers()
        {
            using (var db = new MyContext())
            {
                var us = new List<Users>
                {
                    new Users
                    {
                        Name = "Yaroslav",
                        Age = 26,
                        City = "Lviv",
                        University = "LDFA",
                        Category = ".Net",
                        DoTest = dts
                    },
                       new Users
                    {
                        Name = "Oleg",
                        Age = 23,
                        City = "Lviv",
                        University = "LP",
                        Category = ".Net",
                        DoTest = dts
                    },
                    new Users
                    {
                        Name = "Taras",
                        Age = 21,
                        City = "Kiev",
                        University = "KNP",
                        Category = "JS",
                        DoTest = dts
                    },
                    new Users
                    {
                        Name = "Igor",
                        Age = 22,
                        City = "Kiev",
                        University = "LP",
                        Category = "PHP",
                        DoTest = dts
                    },
                    new Users
                    {
                        Name = "Oleg",
                        Age = 23,
                        City = "Donetsk",
                        University = "DNI",
                        Category = "JS",
                        DoTest = dts
                    },
                    new Users
                    {
                        Name = "Dima",
                        Age = 21,
                        City = "Kiev",
                        University = "KPI",
                        Category = "DB",
                        DoTest = dts
                    },
                };
                db.user.AddRange(us);
                db.SaveChanges();

                Console.WriteLine("List of cities");
                db.user.GroupBy(u => u.City).ToList().ForEach(user => Console.WriteLine(user.Key + " " + user.Count()));
     
            }
        }
    }
}
