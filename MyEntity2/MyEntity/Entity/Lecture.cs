using System.Collections.Generic;


namespace MyEntity.Entity
{
    class Lecture
    {
        public int LectureID { get; set; }
        public int TeacherID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Discriptions { get; set; }
        public ICollection<Teacher> Teacher { get; set; }
        public Lecture()
        {
            this.Teacher = new List<Teacher>();
        }
    }
}
