namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseLessonLernedsPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LessonPerCourses", t => t.LessonId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.LessonId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LessonPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Status = c.Int(nullable: false),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        LessonPerCourse_Id = c.Int(),
                        Course_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.LessonPerCourses", t => t.LessonPerCourse_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.LessonPerCourse_Id)
                .Index(t => t.Course_Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Description = c.String(),
                        Price = c.String(),
                        Image1 = c.String(),
                        Image2 = c.String(),
                        Status = c.Int(nullable: false),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        UserAuthorId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAuthorId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.UserAuthorId);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ReviewsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.UserId);
            
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Credit", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsersPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.ReviewsPerCourses", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReviewsPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.LessonPerCourses", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Courses", "UserAuthorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLernedsPerStudents", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CourseLessonLernedsPerStudents", "LessonId", "dbo.LessonPerCourses");
            DropForeignKey("dbo.LessonPerCourses", "LessonPerCourse_Id", "dbo.LessonPerCourses");
            DropForeignKey("dbo.LessonPerCourses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.UsersPerCourses", new[] { "UserId" });
            DropIndex("dbo.UsersPerCourses", new[] { "CourseId" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "UserId" });
            DropIndex("dbo.ReviewsPerCourses", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "UserAuthorId" });
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.LessonPerCourses", new[] { "Course_Id" });
            DropIndex("dbo.LessonPerCourses", new[] { "LessonPerCourse_Id" });
            DropIndex("dbo.LessonPerCourses", new[] { "CategoryId" });
            DropIndex("dbo.CourseLessonLernedsPerStudents", new[] { "UserId" });
            DropIndex("dbo.CourseLessonLernedsPerStudents", new[] { "LessonId" });
            DropColumn("dbo.AspNetUsers", "Credit");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "Name");
            DropTable("dbo.UsersPerCourses");
            DropTable("dbo.ReviewsPerCourses");
            DropTable("dbo.Incomes");
            DropTable("dbo.Courses");
            DropTable("dbo.LessonPerCourses");
            DropTable("dbo.CourseLessonLernedsPerStudents");
            DropTable("dbo.Categories");
        }
    }
}
