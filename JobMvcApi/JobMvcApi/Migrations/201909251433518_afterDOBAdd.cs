namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class afterDOBAdd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalDetails", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalDetails", "DOB");
        }
    }
}
