using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace MyEntity.Entity
{
    class Users
    {
        [Key]
        public int UserID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string University { get; set; }
        public string Category { get; set; }
        public ICollection<DoTest> DoTest { get; set; }
        public Users()
        {
            this.DoTest = new List<DoTest>();
        }
    }
}
