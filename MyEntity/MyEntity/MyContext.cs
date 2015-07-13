using MyEntity.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEntity
{
    class MyContext : DbContext
    {
        public MyContext() : base("MyDB")
        {

        }
        public DbSet<Users> user { get; set; }
        public DbSet<Tests> test { get; set; }
        public DbSet<Ask> ask { get; set; }
        public DbSet<DoTest> testdo { get; set; }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Lecture> lect { get; set; }
        public DbSet<Category> categ { get; set; }
    }
}
