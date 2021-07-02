using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CL.dll;

namespace EFCode1Strategy_3
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var ctx = new EFContext())
            {
                var tt = new Teacher() {  tname = "leena" };      //never pass id in this
                ctx.teachers.Add(tt);

                var ss = new Subject() { sname = "physics" };    //never pass id in this
                ctx.subjects.Add(ss);

                ctx.SaveChanges();

                //display data
                var teacher = ctx.teachers.ToList();
                var subject = ctx.subjects.ToList();
            
                //access then
                foreach(var x in teacher)
                {
                    Console.WriteLine( x.tname);

                }
                Console.WriteLine("teacher data displayed");

                //for subject
                foreach(var y in subject)
                {
                    Console.WriteLine(y.sname, y.Teachers);
                }
                Console.WriteLine("subject data displayed");

               
            }
            Console.ReadLine();
        }
    }
}
