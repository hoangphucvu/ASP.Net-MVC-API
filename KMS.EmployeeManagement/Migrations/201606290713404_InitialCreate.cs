namespace KMS.EmployeeManagement.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    FirstName = c.String(nullable: false),
                    MiddleName = c.String(),
                    LastName = c.String(nullable: false),
                    DOB = c.DateTime(nullable: false, storeType: "date"),
                    Gender = c.Boolean(nullable: false),
                    StartDate = c.DateTime(nullable: false, storeType: "date"),
                })
                .PrimaryKey(t => t.ID);
        }

        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}