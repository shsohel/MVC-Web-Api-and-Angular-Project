namespace JobMvcApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUpload : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonalDetails", "Photo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PersonalDetails", "Photo");
        }
    }
}
