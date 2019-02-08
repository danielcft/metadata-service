using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MetadataService.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorizationCookies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cookie = table.Column<string>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorizationCookies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CmsContents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ThemeId = table.Column<int>(nullable: false),
                    VideoInfoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CmsContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CmsContents_VideoInfos_VideoInfoId",
                        column: x => x.VideoInfoId,
                        principalTable: "VideoInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CmsContents_VideoInfoId",
                table: "CmsContents",
                column: "VideoInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorizationCookies");

            migrationBuilder.DropTable(
                name: "CmsContents");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "VideoInfos");
        }
    }
}
