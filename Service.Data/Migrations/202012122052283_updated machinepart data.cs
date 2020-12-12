namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmachinepartdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MachinePart", "PartName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MachinePart", "PartName");
        }
    }
}
