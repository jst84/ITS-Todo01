using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.DAL
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Task { get; set; }
        public DateTime InsertedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public DateTime DueDate { get; set; }
    }
}
