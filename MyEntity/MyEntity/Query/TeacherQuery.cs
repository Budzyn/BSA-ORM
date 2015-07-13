using System.Collections.Generic;
using System.Linq;
using MyEntity.Entity;
using System;

namespace MyEntity.Query
{
    public class TeacherQuery
    {
        private static ICollection<Lecture> lc;

        public static void ShowTeacher()
        {
            lc = new List<Lecture>
            {
                new Lecture
                {
                    Name = "Lecture 1",
                    Category=".Net",
                    Discriptions="OOP"
                },
                new Lecture
                {
                    Name = "Lecture 2",
                    Category="JS",
                    Discriptions="HTML5"
                },
                new Lecture
                {
                    Name = "Lecture 3",
                    Category="PHP",
                    Discriptions="HTML"
                },
            };
            using (var db = new MyContext())
            {
                var tc = new List<Teacher>
                {
                    new Teacher
                    {
                        Name = "Ivan Filatov",
                        Lecture = lc
                    },
                    new Teacher
                    {
                        Name = "Roman Sokolov",
                        Lecture = lc
                    },
                    new Teacher
                    {
                        Name = "Roman Sergeev",
                        Lecture = lc
                    }
                };

                db.teachers.AddRange(tc);
                db.SaveChanges();
                Console.WriteLine("Rating teachers on the number of lectures");
                //var lectures = db.lect.Select(item => item).ToList();
                //var teachers = db.teachers.Select((item => item)).ToList();
                var result = db.teachers.Select(item => new { Teacher = item.Name, LectureCount = item.Lecture.Count() });
                foreach (var tst in result)
                {
                    Console.WriteLine(tst);
                }
            }
        }
    }
}
