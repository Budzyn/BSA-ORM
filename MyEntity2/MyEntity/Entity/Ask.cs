
using System.Collections.Generic;

namespace MyEntity.Entity
{
    class Ask
    {
        public int AskID { get; set; }
        public string Category { get; set; }
        public string NameAsk { get; set; }
        public ICollection<Tests> Tests { get; set; }
        public Ask()
        {
            this.Tests = new List<Tests>();
        }
    }
}
