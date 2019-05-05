namespace AppStore.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update_Product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Version", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Developer", c => c.String());
            AddColumn("dbo.Products", "License", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "License");
            DropColumn("dbo.Products", "Developer");
            DropColumn("dbo.Products", "Version");
        }
    }
}
