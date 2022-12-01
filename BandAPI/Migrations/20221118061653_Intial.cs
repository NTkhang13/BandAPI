using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BandAPI.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Founded = table.Column<DateTime>(nullable: false),
                    MainGener = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true),
                    BandId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Bands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bands",
                columns: new[] { "Id", "Founded", "MainGener", "Name" },
                values: new object[,]
                {
                    { new Guid("bb445fe8-381f-4e97-ac73-66bbc90d4fd6"), new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Heavy Metal", "Metallica" },
                    { new Guid("f3f3149d-72b9-4b8c-bf18-4452a84dbdcf"), new DateTime(1985, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rock", "Guns N Roses" },
                    { new Guid("8a6e4004-2538-411c-8b63-1633a07ec5b2"), new DateTime(1965, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Disco", "ABBA" },
                    { new Guid("b821c173-011d-4ffe-a41a-bb377289ddbf"), new DateTime(1991, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alternative", "Oasis" },
                    { new Guid("73fb4c0d-144a-4e9d-822e-206540538249"), new DateTime(1981, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pop", "A-Ha" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "BandId", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("34b6a3f2-c75a-4c9b-9296-d2e78473236e"), new Guid("bb445fe8-381f-4e97-ac73-66bbc90d4fd6"), "One of the best heavy metal albums ever", "Master Of Puppets" },
                    { new Guid("3dfa8c72-94db-46f3-9fe9-3c3e2344abd5"), new Guid("f3f3149d-72b9-4b8c-bf18-4452a84dbdcf"), "Amzing Rock album with raw round", "Appetite for Destruction" },
                    { new Guid("efd96855-4b36-41d0-9cca-0eab30bcc4bd"), new Guid("8a6e4004-2538-411c-8b63-1633a07ec5b2"), "Very groovy album", "Waterloo" },
                    { new Guid("6b6a5d3c-1494-4b36-acd1-aba105074364"), new Guid("b821c173-011d-4ffe-a41a-bb377289ddbf"), "Arguably one of the best albums by Oasis", "Be Here Now" },
                    { new Guid("0e250b09-f6e4-4be1-a858-863782e60da7"), new Guid("73fb4c0d-144a-4e9d-822e-206540538249"), "Awesome Debut album by A-ha", "Hunting Hight and Low" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_BandId",
                table: "Albums",
                column: "BandId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Bands");
        }
    }
}
