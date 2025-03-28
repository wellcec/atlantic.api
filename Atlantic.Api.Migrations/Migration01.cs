using FluentMigrator;
using Atlantic.Api.Data.NotificationTemplatesContext.Entities;

namespace Atlantic.Api.Migrations
{
    [Migration(2023122145000, "v1.0.1")]
    public class Migration01 : Migration
    {
        public override void Up()
        {
            #region Tables
            Create.Table($"ststblwtpwpptemplates")
            .WithColumn("wtpseq").AsInt64().NotNullable()
            .WithColumn("wtpnomtemplate").AsString(250).NotNullable()
            .WithColumn("wtpdesprevtpl").AsString(250).Nullable()
            .WithColumn("wtpcodblcbottpl").AsString(250).NotNullable()
            .WithColumn("wtpidttypentfcapi").AsString(100).NotNullable()
            .WithColumn("hdrdthins").AsDateTime().NotNullable()
            .WithColumn("hdrdthhor").AsDateTime().NotNullable()
            .WithColumn("hdrcodusu").AsString(30).NotNullable()
            .WithColumn("hdrcodlck").AsInt32().NotNullable()
            .WithColumn("hdrcodetc").AsString(15).Nullable()
            .WithColumn("hdrcodprg").AsString(50).NotNullable();
            #endregion
        }

        public override void Down()
        {
        }
    }
}
