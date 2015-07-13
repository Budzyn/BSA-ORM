using MyEntity.Entity;
using System.Collections.Generic;
using System.Linq;
using System;

namespace MyEntity.Query
{
    public class TestsQuery
    {

        private static ICollection<Tests> tt;
        public static void ShowTests()
        {
            tt = new List<Tests>
            {
                new Tests
                {
                    Name = "for .Net students",
                    Category = ".Net",
                    TimeMax = 30,
                    ListAsk = "What is a class?",
                    Pass = 38
                },
                new Tests
                {
                    Name = "for JS students",
                    Category = "JS",
                    TimeMax = 30,
                    ListAsk = "What is a class?",
                    Pass = 50
                },
                new Tests
                {
                    Name = "for PHP students",
                    Category = "PHP",
                    TimeMax = 30,
                    ListAsk="What is a HTML?",
                    Pass = 25
                },
                new Tests
                {
                    Name = "for DB students",
                    Category = "DB",
                    TimeMax = 25,
                    ListAsk="What is a DataBase?",
                    Pass = 20
                },
            };
            using (var db = new MyContext())
            {
                var ak = new List<Ask>
                {
                    new Ask
                    {
                       
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a class?"
                    },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a class?"
                       },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a HTML?"
                       },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a DataBase?"
                    },
                };
                db.ask.AddRange(ak);
                db.test.AddRange(tt);
                db.SaveChanges();
                Console.WriteLine("Popularity rating questions in tests");
                /*var result = db.ask.Select(item => new { Ask = item.NameAsk, CategoryCount = item.Category.Count() });
                foreach (var tst in result)
                {
                    Console.WriteLine(tst);
                }*/
            }
        }
    }
}
