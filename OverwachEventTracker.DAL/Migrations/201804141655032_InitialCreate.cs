namespace OverwachEventTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        SeasonalName = c.String(maxLength: 100),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        EventType_SystemName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.EventTypes", t => t.EventType_SystemName)
                .Index(t => t.EventType_SystemName);
            
            CreateTable(
                "dbo.EventTypes",
                c => new
                    {
                        SystemName = c.String(nullable: false, maxLength: 50),
                        DisplayName = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.SystemName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "EventType_SystemName", "dbo.EventTypes");
            DropIndex("dbo.Events", new[] { "EventType_SystemName" });
            DropTable("dbo.EventTypes");
            DropTable("dbo.Events");
        }
    }
}
