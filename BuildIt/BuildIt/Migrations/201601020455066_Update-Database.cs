namespace BuildIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectInventories", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectInventories", new[] { "ProjectId" });
            DropColumn("dbo.ProjectInventories", "InventoryId");
            RenameColumn(table: "dbo.ProjectInventories", name: "ProjectId", newName: "InventoryId");
            DropPrimaryKey("dbo.Projects");
            AddColumn("dbo.Projects", "InventoryId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Projects", "InventoryId");
            AddForeignKey("dbo.ProjectInventories", "InventoryId", "dbo.Projects", "InventoryId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectInventories", "InventoryId", "dbo.Projects");
            DropPrimaryKey("dbo.Projects");
            AlterColumn("dbo.Projects", "ProjectId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Projects", "InventoryId");
            AddPrimaryKey("dbo.Projects", "ProjectId");
            RenameColumn(table: "dbo.ProjectInventories", name: "InventoryId", newName: "ProjectId");
            AddColumn("dbo.ProjectInventories", "InventoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectInventories", "ProjectId");
            AddForeignKey("dbo.ProjectInventories", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
        }
    }
}
