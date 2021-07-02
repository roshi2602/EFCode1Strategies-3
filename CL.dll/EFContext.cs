using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace CL.dll
{
  public  class EFContext:DbContext
    {
       public  EFContext() : base("TeacherDataBase")     //database name, also same in connection string app.config file -initial catalogue
        {
           
        }
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Subject> subjects { get; set; }

        //fluent api(used approach rather than data annotations attributes)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("my report");    //table will be my report.table name in database


            //to configure primary key
            modelBuilder.Entity<Teacher>().HasKey<int>(s => s.tid);       //to id

            modelBuilder.Entity<Subject>().HasKey<int>(f => f.sid);

            //for max length 
            modelBuilder.Entity<Teacher>().Property(p => p.tname).HasMaxLength(20);

            //for foreign key
         //   modelBuilder.Entity<Teacher>().HasRequired(x => x.tname).WithMany().HasForeignKey(y => y.tname);

        }

    }
}
//IMPORTANT-
//after making all this go to tools->nuget console ->select class library
//type commands
//Enable-Migrations
//Add-Migration
//Update-Database -verbose