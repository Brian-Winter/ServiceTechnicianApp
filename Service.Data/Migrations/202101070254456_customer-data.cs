namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerdata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customer", "MachineId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customer", "MachineId");
            AddForeignKey("dbo.Customer", "MachineId", "dbo.Machine", "MachineId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MachineId", "dbo.Machine");
            DropIndex("dbo.Customer", new[] { "MachineId" });
            DropColumn("dbo.Customer", "MachineId");
        }
    }
}
