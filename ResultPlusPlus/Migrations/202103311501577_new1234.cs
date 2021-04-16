namespace ResultPlusPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new1234 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "ClassId", "dbo.Classes");
            DropIndex("dbo.Students", new[] { "ClassId" });
            AddColumn("dbo.Students", "Class", c => c.String());
            DropColumn("dbo.Students", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ClassId", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "Class");
            CreateIndex("dbo.Students", "ClassId");
            AddForeignKey("dbo.Students", "ClassId", "dbo.Classes", "Id", cascadeDelete: true);
        }
    }
}
