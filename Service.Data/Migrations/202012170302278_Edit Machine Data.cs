namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMachineData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Machine", "MachinePart_MachinePartId", "dbo.MachinePart");
            DropIndex("dbo.Machine", new[] { "MachinePart_MachinePartId" });
            DropColumn("dbo.Machine", "MachinePart_MachinePartId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machine", "MachinePart_MachinePartId", c => c.Int());
            CreateIndex("dbo.Machine", "MachinePart_MachinePartId");
            AddForeignKey("dbo.Machine", "MachinePart_MachinePartId", "dbo.MachinePart", "MachinePartId");
        }
    }
}
