using System.Collections.Generic;


namespace MyEntity.Entity
{
    class Teacher
    {
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public ICollection<Lecture> Lecture { get; set; }
        public Teacher()
        {
            this.Lecture = new List<Lecture>();
        }
    }
}
