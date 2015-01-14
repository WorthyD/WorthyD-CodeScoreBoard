namespace WorthyD.CodeScoreBoard.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingIgnore : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "IgnoreRegex", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "IgnoreRegex");
        }
    }
}
