namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class teacherGenderMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "GenderId");
            AddForeignKey("dbo.Teachers", "GenderId", "dbo.Genders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "GenderId", "dbo.Genders");
            DropIndex("dbo.Teachers", new[] { "GenderId" });
            DropColumn("dbo.Teachers", "GenderId");
        }
    }
}
