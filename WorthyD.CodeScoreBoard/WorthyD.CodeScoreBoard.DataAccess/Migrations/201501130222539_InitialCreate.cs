namespace WorthyD.CodeScoreBoard.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CodeLogs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Project_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Projects", t => t.Project_ID)
                .Index(t => t.Project_ID);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProjectDetails = c.String(nullable: false, maxLength: 20),
                        ProjectPath = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodeLogs", "Project_ID", "dbo.Projects");
            DropIndex("dbo.CodeLogs", new[] { "Project_ID" });
            DropTable("dbo.Projects");
            DropTable("dbo.CodeLogs");
        }
    }
}
