namespace web_app_asp_net_mvc_export_xml.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DisciplineGoal = c.String(nullable: false),
                        DisciplineObjectives = c.String(nullable: false),
                        MainSections = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lessons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        DisciplineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.DisciplineId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false),
                        NumberOfStudents = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nationalities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Sex = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeacherImages",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Guid = c.Guid(nullable: false),
                        Data = c.Binary(nullable: false),
                        ContentType = c.String(maxLength: 100),
                        DateChanged = c.DateTime(),
                        FileName = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.GroupLessons",
                c => new
                    {
                        Group_Id = c.Int(nullable: false),
                        Lesson_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Group_Id, t.Lesson_Id })
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .ForeignKey("dbo.Lessons", t => t.Lesson_Id, cascadeDelete: true)
                .Index(t => t.Group_Id)
                .Index(t => t.Lesson_Id);
            
            CreateTable(
                "dbo.NationalityGroups",
                c => new
                    {
                        Nationality_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Nationality_Id, t.Group_Id })
                .ForeignKey("dbo.Nationalities", t => t.Nationality_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_Id, cascadeDelete: true)
                .Index(t => t.Nationality_Id)
                .Index(t => t.Group_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherImages", "Id", "dbo.Teachers");
            DropForeignKey("dbo.Lessons", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.NationalityGroups", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.NationalityGroups", "Nationality_Id", "dbo.Nationalities");
            DropForeignKey("dbo.GroupLessons", "Lesson_Id", "dbo.Lessons");
            DropForeignKey("dbo.GroupLessons", "Group_Id", "dbo.Groups");
            DropForeignKey("dbo.Lessons", "DisciplineId", "dbo.Disciplines");
            DropIndex("dbo.NationalityGroups", new[] { "Group_Id" });
            DropIndex("dbo.NationalityGroups", new[] { "Nationality_Id" });
            DropIndex("dbo.GroupLessons", new[] { "Lesson_Id" });
            DropIndex("dbo.GroupLessons", new[] { "Group_Id" });
            DropIndex("dbo.TeacherImages", new[] { "Id" });
            DropIndex("dbo.Lessons", new[] { "DisciplineId" });
            DropIndex("dbo.Lessons", new[] { "TeacherId" });
            DropTable("dbo.NationalityGroups");
            DropTable("dbo.GroupLessons");
            DropTable("dbo.TeacherImages");
            DropTable("dbo.Teachers");
            DropTable("dbo.Nationalities");
            DropTable("dbo.Groups");
            DropTable("dbo.Lessons");
            DropTable("dbo.Disciplines");
        }
    }
}
