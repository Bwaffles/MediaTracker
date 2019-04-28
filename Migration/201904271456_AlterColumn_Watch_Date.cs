using FluentMigrator;
namespace Migrations
{
    [Migration(201904271456)]
    public class AlterColumn_Watch_Date_Time : Migration
    {
        public override void Down()
        {
            Alter
                .Column("Date")
                .OnTable("Watch")
                .AsDate()
                .NotNullable();
        }

        public override void Up()
        {
            Alter
                .Column("Date")
                .OnTable("Watch")
                .AsDateTime()
                .NotNullable();
        }
    }
}
