namespace TodoApp.Api.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        ItemId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Completed = c.Boolean(nullable: false),
                        ListId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Lists", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Guid(nullable: false),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Items", "ListId", "dbo.Lists");
            DropIndex("dbo.Items", new[] { "ListId" });
            DropTable("dbo.Lists");
            DropTable("dbo.Items");
        }
    }
}
