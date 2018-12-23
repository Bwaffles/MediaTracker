using FluentMigrator;

namespace Migrations
{
    [Migration(201812212149)]
    public class Create_WatchHistory : Migration
    {
        public override void Down()
        {
            Delete.Table("WatchHistory");
        }

        public override void Up()
        {
            Create.Table("WatchHistory")
                .WithColumn("Id").AsInt32().PrimaryKey()
                .WithColumn("WatchNumber").AsInt16().NotNullable()
                .WithColumn("MovieId").AsInt32().NotNullable()
                .WithColumn("Rating").AsDecimal(5, 2).Nullable()
                .WithColumn("WatchDate").AsDate().Nullable()
                .WithColumn("Comment").AsString().Nullable();
        }
    }
}