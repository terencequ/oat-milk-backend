using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OatMilk.Backend.Api.Data.Migrations
{
    public partial class AddAbilitiesEffectsModifiersUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Effect",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    ChanceToApplyToTarget = table.Column<float>(type: "real", nullable: false)
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
                name: "Ability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CostEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CooldownEffectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Magnitude = table.Column<float>(type: "real", nullable: false),
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
                name: "Modifier");

            migrationBuilder.DropTable(
                name: "Ability");

            migrationBuilder.DropTable(
                name: "Effect");
        }
    }
}
