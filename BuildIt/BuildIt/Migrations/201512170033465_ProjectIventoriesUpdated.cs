namespace BuildIt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProjectIventoriesUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Inventories", "Project_ProjectId", "dbo.Projects");
            DropIndex("dbo.Inventories", new[] { "Project_ProjectId" });
            CreateIndex("dbo.ProjectInventories", "ProjectId");
            CreateIndex("dbo.ProjectInventories", "InventoryId");
            AddForeignKey("dbo.ProjectInventories", "InventoryId", "dbo.Inventories", "InventoryID", cascadeDelete: true);
            AddForeignKey("dbo.ProjectInventories", "ProjectId", "dbo.Projects", "ProjectId", cascadeDelete: true);
            DropColumn("dbo.Inventories", "Project_ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "Project_ProjectId", c => c.Int());
            DropForeignKey("dbo.ProjectInventories", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectInventories", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.ProjectInventories", new[] { "InventoryId" });
            DropIndex("dbo.ProjectInventories", new[] { "ProjectId" });
            CreateIndex("dbo.Inventories", "Project_ProjectId");
            AddForeignKey("dbo.Inventories", "Project_ProjectId", "dbo.Projects", "ProjectId");
        }
    }
}
