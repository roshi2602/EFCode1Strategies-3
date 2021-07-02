namespace CL.dll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "my report.Subjects",
                c => new
                    {
                        sid = c.Int(nullable: false, identity: true),
                        sname = c.String(),
                    })
                .PrimaryKey(t => t.sid);
            
            CreateTable(
                "my report.Teachers",
                c => new
                    {
                        tid = c.Int(nullable: false, identity: true),
                        tname = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.tid);
            
            CreateTable(
                "my report.TeacherSubjects",
                c => new
                    {
                        Teacher_tid = c.Int(nullable: false),
                        Subject_sid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Teacher_tid, t.Subject_sid })
                .ForeignKey("my report.Teachers", t => t.Teacher_tid, cascadeDelete: true)
                .ForeignKey("my report.Subjects", t => t.Subject_sid, cascadeDelete: true)
                .Index(t => t.Teacher_tid)
                .Index(t => t.Subject_sid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("my report.TeacherSubjects", "Subject_sid", "my report.Subjects");
            DropForeignKey("my report.TeacherSubjects", "Teacher_tid", "my report.Teachers");
            DropIndex("my report.TeacherSubjects", new[] { "Subject_sid" });
            DropIndex("my report.TeacherSubjects", new[] { "Teacher_tid" });
            DropTable("my report.TeacherSubjects");
            DropTable("my report.Teachers");
            DropTable("my report.Subjects");
        }
    }
}
