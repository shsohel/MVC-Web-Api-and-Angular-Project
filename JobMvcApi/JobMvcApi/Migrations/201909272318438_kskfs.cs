namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kskfs : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "PresentAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.Addresses", "PermanentAddress", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "PermanentAddress", c => c.String(maxLength: 50));
            AlterColumn("dbo.Addresses", "PresentAddress", c => c.String(maxLength: 50));
        }
    }
}
