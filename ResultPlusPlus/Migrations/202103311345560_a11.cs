namespace ResultPlusPlus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Email", c => c.String());
            AddColumn("dbo.Students", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "DOB");
            DropColumn("dbo.Students", "Email");
        }
    }
}
