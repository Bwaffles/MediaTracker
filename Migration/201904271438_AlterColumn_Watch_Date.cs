using FluentMigrator;
namespace Migrations
{
    [Migration(201904271438)]
    public class AlterColumn_Watch_Date : Migration
    {
        public override void Down()
        {
            Alter
                .Column("Date")
                .OnTable("Watch")
                .AsDate()
                .Nullable();
        }

        public override void Up()
        {
            Alter
                .Column("Date")
                .OnTable("Watch")
                .AsDate()
                .NotNullable();
        }
    }
}
