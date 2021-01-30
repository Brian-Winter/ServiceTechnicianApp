namespace Service.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serviceformtwo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "MachineId", "dbo.Machine");
            AddColumn("dbo.ServiceForm", "CustomerId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceForm", "CustomerId");
            AddForeignKey("dbo.ServiceForm", "CustomerId", "dbo.Customer", "CustomerId");
            AddForeignKey("dbo.Customer", "MachineId", "dbo.Machine", "MachineId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "MachineId", "dbo.Machine");
            DropForeignKey("dbo.ServiceForm", "CustomerId", "dbo.Customer");
            DropIndex("dbo.ServiceForm", new[] { "CustomerId" });
            DropColumn("dbo.ServiceForm", "CustomerId");
            AddForeignKey("dbo.Customer", "MachineId", "dbo.Machine", "MachineId", cascadeDelete: true);
        }
    }
}
