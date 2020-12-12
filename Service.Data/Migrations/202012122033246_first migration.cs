namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machine", "MachineName", c => c.String(nullable: false));
            AddColumn("dbo.Machine", "MachinePart_MachinePartId", c => c.Int());
            CreateIndex("dbo.Machine", "MachinePart_MachinePartId");
            AddForeignKey("dbo.Machine", "MachinePart_MachinePartId", "dbo.MachinePart", "MachinePartId");
            DropColumn("dbo.Machine", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machine", "Name", c => c.String(nullable: false));
            DropForeignKey("dbo.Machine", "MachinePart_MachinePartId", "dbo.MachinePart");
            DropIndex("dbo.Machine", new[] { "MachinePart_MachinePartId" });
            DropColumn("dbo.Machine", "MachinePart_MachinePartId");
            DropColumn("dbo.Machine", "MachineName");
        }
    }
}
