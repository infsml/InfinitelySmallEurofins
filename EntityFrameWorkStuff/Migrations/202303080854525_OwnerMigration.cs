namespace EntityFrameWorkStuff.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OwnerMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Owner", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Owner");
        }
    }
}
