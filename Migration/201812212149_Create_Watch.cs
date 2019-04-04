using FluentMigrator;

namespace Migrations
{
    [Migration(201812212149)]
    public class Create_Watch : Migration
    {
        public override void Down()
        {
            Delete.Table("Watch");
        }

        public override void Up()
        {
            Create.Table("Watch")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Number").AsInt16().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                .WithColumn("Rating").AsDecimal(5, 2).Nullable()
                .WithColumn("Date").AsDate().Nullable()
                .WithColumn("Comment").AsString().Nullable();
        }
    }
}