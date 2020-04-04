namespace Persistence.DatabaseContext.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class SprintV20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LessonPerCourses", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.LessonPerCourses", "LessonPerCourse_Id", "dbo.LessonPerCourses");
            DropForeignKey("dbo.LessonPerCourses", "Course_Id", "dbo.Courses");
            DropIndex("dbo.LessonPerCourses", new[] { "CategoryId" });
            DropIndex("dbo.LessonPerCourses", new[] { "LessonPerCourse_Id" });
            DropIndex("dbo.LessonPerCourses", new[] { "Course_Id" });
            RenameColumn(table: "dbo.LessonPerCourses", name: "Course_Id", newName: "CourseId");
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Category_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.CourseLessonLernedsPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CourseLessonLernedsPerStudent_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.LessonPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LessonPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Course_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityId = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Income_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ReviewsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ReviewsPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UsersPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: null, newValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition")
                    },
                });
            
            AddColumn("dbo.Categories", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "CreatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "UpdatedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.Categories", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.Categories", "DeletedBy", c => c.String(maxLength: 128));
            AddColumn("dbo.CourseLessonLernedsPerStudents", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.LessonPerCourses", "Content", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Video", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Courses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Incomes", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ReviewsPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.UsersPerCourses", "Deleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.LessonPerCourses", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "CreatedBy");
            CreateIndex("dbo.Categories", "UpdatedBy");
            CreateIndex("dbo.Categories", "DeletedBy");
            CreateIndex("dbo.LessonPerCourses", "CourseId");
            AddForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Categories", "DeletedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Categories", "UpdatedBy", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.LessonPerCourses", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
            DropColumn("dbo.LessonPerCourses", "Slug");
            DropColumn("dbo.LessonPerCourses", "Description");
            DropColumn("dbo.LessonPerCourses", "Price");
            DropColumn("dbo.LessonPerCourses", "Image1");
            DropColumn("dbo.LessonPerCourses", "Image2");
            DropColumn("dbo.LessonPerCourses", "Status");
            DropColumn("dbo.LessonPerCourses", "Vote");
            DropColumn("dbo.LessonPerCourses", "CategoryId");
            DropColumn("dbo.LessonPerCourses", "LessonPerCourse_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LessonPerCourses", "LessonPerCourse_Id", c => c.Int());
            AddColumn("dbo.LessonPerCourses", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.LessonPerCourses", "Vote", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.LessonPerCourses", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.LessonPerCourses", "Image2", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Image1", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Price", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Description", c => c.String());
            AddColumn("dbo.LessonPerCourses", "Slug", c => c.String());
            DropForeignKey("dbo.LessonPerCourses", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Categories", "UpdatedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "DeletedBy", "dbo.AspNetUsers");
            DropForeignKey("dbo.Categories", "CreatedBy", "dbo.AspNetUsers");
            DropIndex("dbo.LessonPerCourses", new[] { "CourseId" });
            DropIndex("dbo.Categories", new[] { "DeletedBy" });
            DropIndex("dbo.Categories", new[] { "UpdatedBy" });
            DropIndex("dbo.Categories", new[] { "CreatedBy" });
            AlterColumn("dbo.LessonPerCourses", "CourseId", c => c.Int());
            DropColumn("dbo.UsersPerCourses", "Deleted");
            DropColumn("dbo.ReviewsPerCourses", "Deleted");
            DropColumn("dbo.Incomes", "Deleted");
            DropColumn("dbo.Courses", "Deleted");
            DropColumn("dbo.LessonPerCourses", "Deleted");
            DropColumn("dbo.LessonPerCourses", "Video");
            DropColumn("dbo.LessonPerCourses", "Content");
            DropColumn("dbo.CourseLessonLernedsPerStudents", "Deleted");
            DropColumn("dbo.Categories", "DeletedBy");
            DropColumn("dbo.Categories", "DeletedAt");
            DropColumn("dbo.Categories", "UpdatedBy");
            DropColumn("dbo.Categories", "UpdatedAt");
            DropColumn("dbo.Categories", "CreatedBy");
            DropColumn("dbo.Categories", "CreatedAt");
            DropColumn("dbo.Categories", "Deleted");
            AlterTableAnnotations(
                "dbo.UsersPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Completed = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_UsersPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ReviewsPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Vote = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CourseId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_ReviewsPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Incomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityType = c.Int(nullable: false),
                        IncomeType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EntityId = c.String(),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Income_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
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
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Course_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.LessonPerCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Content = c.String(),
                        Video = c.String(),
                        CourseId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_LessonPerCourse_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.CourseLessonLernedsPerStudents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LessonId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_CourseLessonLernedsPerStudent_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Slug = c.String(),
                        Icon = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(),
                        CreatedBy = c.String(maxLength: 128),
                        UpdatedAt = c.DateTime(),
                        UpdatedBy = c.String(maxLength: 128),
                        DeletedAt = c.DateTime(),
                        DeletedBy = c.String(maxLength: 128),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DynamicFilter_Category_IsDeleted",
                        new AnnotationValues(oldValue: "EntityFramework.DynamicFilters.DynamicFilterDefinition", newValue: null)
                    },
                });
            
            RenameColumn(table: "dbo.LessonPerCourses", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.LessonPerCourses", "Course_Id");
            CreateIndex("dbo.LessonPerCourses", "LessonPerCourse_Id");
            CreateIndex("dbo.LessonPerCourses", "CategoryId");
            AddForeignKey("dbo.LessonPerCourses", "Course_Id", "dbo.Courses", "Id");
            AddForeignKey("dbo.LessonPerCourses", "LessonPerCourse_Id", "dbo.LessonPerCourses", "Id");
            AddForeignKey("dbo.LessonPerCourses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
