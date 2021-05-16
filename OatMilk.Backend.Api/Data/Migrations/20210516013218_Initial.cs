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
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Experience = table.Column<int>(type: "int", nullable: false),
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
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Character", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Character_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    ChanceToApplyToTarget = table.Column<float>(type: "real", nullable: false),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Effect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Effect_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseValue = table.Column<double>(type: "float", nullable: false),
                    CurrentValue = table.Column<double>(type: "float", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_Character_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Character",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CooldownEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ability_Effect_CooldownEffectId",
                        column: x => x.CooldownEffectId,
                        principalTable: "Effect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ability_Effect_CostEffectId",
                        column: x => x.CostEffectId,
                        principalTable: "Effect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ability_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Modifier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Magnitude = table.Column<double>(type: "float", nullable: false),
                    Operation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modifier_Effect_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AbilityEffect",
                columns: table => new
                {
                    AbilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityEffect", x => new { x.AbilityId, x.EffectId });
                    table.ForeignKey(
                        name: "FK_AbilityEffect_Ability_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "Ability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbilityEffect_Effect_EffectId",
                        column: x => x.EffectId,
                        principalTable: "Effect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ability_CooldownEffectId",
                table: "Ability",
                column: "CooldownEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_CostEffectId",
                table: "Ability",
                column: "CostEffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Ability_UserId",
                table: "Ability",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilityEffect_EffectId",
                table: "AbilityEffect",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_CharacterId",
                table: "Attribute",
                column: "CharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_Character_UserId",
                table: "Character",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Effect_UserId",
                table: "Effect",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Modifier_EffectId",
                table: "Modifier",
                column: "EffectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityEffect");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "Modifier");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Character");

            migrationBuilder.DropTable(
                name: "Effect");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
