namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterDOBAdd2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.PersonalDetails", "UserId");
            DropColumn("dbo.Employers", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "UserId", c => c.String());
            AddColumn("dbo.PersonalDetails", "UserId", c => c.String());
        }
    }
}
