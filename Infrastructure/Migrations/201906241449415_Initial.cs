namespace Infrastructure.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Teacher_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Rank = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        ExaminationTimeStart = c.DateTime(nullable: false),
                        ExaminationTimeEnd = c.DateTime(nullable: false),
                        Hall = c.String(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Score = c.Int(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                        Student_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Specialty = c.String(nullable: false),
                        Course = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Grades", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Exams", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Disciplines", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Grades", new[] { "Student_Id" });
            DropIndex("dbo.Grades", new[] { "Discipline_Id" });
            DropIndex("dbo.Exams", new[] { "Discipline_Id" });
            DropIndex("dbo.Disciplines", new[] { "Teacher_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Grades");
            DropTable("dbo.Exams");
            DropTable("dbo.Teachers");
            DropTable("dbo.Disciplines");
        }
    }
}
