using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OatMilk.Backend.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Character",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Experience = table.Column<int>(type: "int", nullable: false),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    Dexterity = table.Column<int>(type: "int", nullable: false),
                    Constitution = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Wisdom = table.Column<int>(type: "int", nullable: false),
                    Charisma = table.Column<int>(type: "int", nullable: false),
                    ArmorClass = table.Column<int>(type: "int", nullable: false),
                    Initiative = table.Column<int>(type: "int", nullable: false),
                    SpeedInFt = table.Column<int>(type: "int", nullable: false),
                    CurrentHitPoints = table.Column<int>(type: "int", nullable: false),
                    MaxHitPoints = table.Column<int>(type: "int", nullable: false),
                    DeathSaveSuccesses = table.Column<int>(type: "int", nullable: false),
                    DeathSaveFailures = table.Column<int>(type: "int", nullable: false),
                    Acrobatics = table.Column<bool>(type: "bit", nullable: false),
                    AnimalHandling = table.Column<bool>(type: "bit", nullable: false),
                    Arcana = table.Column<bool>(type: "bit", nullable: false),
                    Athletics = table.Column<bool>(type: "bit", nullable: false),
                    Deception = table.Column<bool>(type: "bit", nullable: false),
                    History = table.Column<bool>(type: "bit", nullable: false),
                    Insight = table.Column<bool>(type: "bit", nullable: false),
                    Intimidation = table.Column<bool>(type: "bit", nullable: false),
                    Investigation = table.Column<bool>(type: "bit", nullable: false),
                    Medicine = table.Column<bool>(type: "bit", nullable: false),
                    Nature = table.Column<bool>(type: "bit", nullable: false),
                    Perception = table.Column<bool>(type: "bit", nullable: false),
                    Performance = table.Column<bool>(type: "bit", nullable: false),
                    Persuasion = table.Column<bool>(type: "bit", nullable: false),
                    Religion = table.Column<bool>(type: "bit", nullable: false),
                    SleightOfHand = table.Column<bool>(type: "bit", nullable: false),
                    Stealth = table.Column<bool>(type: "bit", nullable: false),
                    Survival = table.Column<bool>(type: "bit", nullable: false),
                    PersonalityTraits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ideals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bonds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flaws = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Backstory = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlliesAndOrganisations = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
