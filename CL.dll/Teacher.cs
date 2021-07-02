using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.dll
{
    //many to many relationship

    //teacher can have multiple subjects and multiple teachers can have 1 subject
   //for this apply collection navigation property at both classes
    public class Teacher
    {
        //create constructor
        public Teacher()
        {
            this.Subjects = new HashSet<Subject>();  //using hashset to avoid duplicates and is a collection of unique elements
        }
        public int tid { get; set; }
        public string tname { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; } //collection navigation property
    }

    public class Subject
    {
        //create constructor
        public Subject()
        {
            //using hashset 
            //using hashset to avoid duplicates and is a collection of unique elements
            this.Teachers = new HashSet<Teacher>();
        }
        public int sid { get; set; }
        public string sname { get; set; }
        public virtual ICollection<Teacher> Teachers{ get; set; } //collection navigation property
    }
}
