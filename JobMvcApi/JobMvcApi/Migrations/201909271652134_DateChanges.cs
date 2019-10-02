namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PersonalDetails", "DOB", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PersonalDetails", "DOB", c => c.DateTime(nullable: false));
        }
    }
}
