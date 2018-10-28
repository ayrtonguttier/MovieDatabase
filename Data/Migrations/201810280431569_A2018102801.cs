namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A2018102801 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TITLE = c.String(),
                        IMAGE = c.Binary(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
