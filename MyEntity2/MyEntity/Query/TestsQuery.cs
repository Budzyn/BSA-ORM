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
                        NameAsk = "What is a class?",
                        Tests=new List<Tests>{tt.FirstOrDefault(item => item.Category == "JS") }
                    },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a class?",
                        Tests=new List<Tests>{tt.FirstOrDefault(item => item.Category == ".Net") }
                       },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a HTML?",
                        Tests=new List<Tests>{tt.FirstOrDefault(item => item.Category == "PHP") }
                       },
                    new Ask
                    {
                        Category=tt.FirstOrDefault().Category,
                        NameAsk = "What is a DataBase?",
                        Tests=new List<Tests>{tt.FirstOrDefault(item => item.Category == "DB") }
                    },
                };
                db.ask.AddRange(ak);
                db.test.AddRange(tt);
                db.SaveChanges();
                Console.WriteLine("Popularity rating questions in tests");
                var result = db.ask.Select(item => new { Ask = item.NameAsk, dfg  = item.Tests.Count() });
                foreach (var tst in result)
                {
                    Console.WriteLine(tst);
                }
                Console.WriteLine("Average test by Category");
                var r = from Tests in tt group Tests by new { Category = Tests.Category, Pass = Tests.Pass } into grouped select new { Category = grouped.Key.Category, Pass = grouped.Key.Pass, Average=grouped.Average(x=>x.Pass) };
                foreach (var rt in r)
                {
                    Console.WriteLine(rt);
                }
            }
        }
    }
}
