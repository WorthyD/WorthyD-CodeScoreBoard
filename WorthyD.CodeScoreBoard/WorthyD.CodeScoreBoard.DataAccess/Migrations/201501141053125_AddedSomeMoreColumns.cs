namespace WorthyD.CodeScoreBoard.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSomeMoreColumns : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CodeLogs", "Project_ID", "dbo.Projects");
            DropIndex("dbo.CodeLogs", new[] { "Project_ID" });
            RenameColumn(table: "dbo.CodeLogs", name: "Project_ID", newName: "ProjectID");
            AddColumn("dbo.CodeLogs", "FileCount", c => c.Int(nullable: false));
            AddColumn("dbo.CodeLogs", "Language", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CodeLogs", "BlankLines", c => c.Int(nullable: false));
            AddColumn("dbo.CodeLogs", "CommentLines", c => c.Int(nullable: false));
            AddColumn("dbo.CodeLogs", "CodeLines", c => c.Int(nullable: false));
            AddColumn("dbo.CodeLogs", "LogTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CodeLogs", "ProjectID", c => c.Int(nullable: false));
            CreateIndex("dbo.CodeLogs", "ProjectID");
            AddForeignKey("dbo.CodeLogs", "ProjectID", "dbo.Projects", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CodeLogs", "ProjectID", "dbo.Projects");
            DropIndex("dbo.CodeLogs", new[] { "ProjectID" });
            AlterColumn("dbo.CodeLogs", "ProjectID", c => c.Int());
            DropColumn("dbo.CodeLogs", "LogTime");
            DropColumn("dbo.CodeLogs", "CodeLines");
            DropColumn("dbo.CodeLogs", "CommentLines");
            DropColumn("dbo.CodeLogs", "BlankLines");
            DropColumn("dbo.CodeLogs", "Language");
            DropColumn("dbo.CodeLogs", "FileCount");
            RenameColumn(table: "dbo.CodeLogs", name: "ProjectID", newName: "Project_ID");
            CreateIndex("dbo.CodeLogs", "Project_ID");
            AddForeignKey("dbo.CodeLogs", "Project_ID", "dbo.Projects", "ID");
        }
    }
}
