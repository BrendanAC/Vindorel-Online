using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace OnlineVindorel.Migrations
{
    public partial class Vindorel_Online : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });
            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRoleClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityRoleClaim<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserClaim<string>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdentityUserClaim<string>_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserLogin<string>", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_IdentityUserLogin<string>_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<string>", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_IdentityRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IdentityUserRole<string>_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    From = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    SendTime = table.Column<DateTime>(nullable: false),
                    To = table.Column<string>(nullable: true),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Coordinate_X = table.Column<int>(nullable: false),
                    Coordinate_Y = table.Column<int>(nullable: false),
                    LastUpdated = table.Column<DateTime>(nullable: false),
                    MaxFOOD = table.Column<int>(nullable: false),
                    MaxIRON = table.Column<int>(nullable: false),
                    MaxWOOD = table.Column<int>(nullable: false),
                    TownGOLD = table.Column<int>(nullable: false),
                    TownGOLD_perHour = table.Column<int>(nullable: false),
                    TownIRON = table.Column<int>(nullable: false),
                    TownIRON_perHour = table.Column<int>(nullable: false),
                    TownMEAT = table.Column<int>(nullable: false),
                    TownMeat_perHour = table.Column<int>(nullable: false),
                    TownName = table.Column<string>(nullable: true),
                    TownWHEAT = table.Column<int>(nullable: false),
                    TownWHEAT_perHour = table.Column<int>(nullable: false),
                    TownWOOD = table.Column<int>(nullable: false),
                    TownWOOD_perHour = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                    table.ForeignKey(
                        name: "FK_Towns_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "UserGameSettings",
                columns: table => new
                {
                    SettingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnarchyRate = table.Column<int>(nullable: false),
                    ArmySpeed = table.Column<int>(nullable: false),
                    BattleStat = table.Column<int>(nullable: false),
                    BuildSpeed = table.Column<int>(nullable: false),
                    CultureRate = table.Column<int>(nullable: false),
                    DefeatStat = table.Column<int>(nullable: false),
                    God = table.Column<string>(nullable: true),
                    NaturalAttack = table.Column<int>(nullable: false),
                    NaturalBreedRate = table.Column<int>(nullable: false),
                    NaturalDef = table.Column<int>(nullable: false),
                    Point_Culture = table.Column<int>(nullable: false),
                    Point_Economy = table.Column<int>(nullable: false),
                    Point_Exp = table.Column<int>(nullable: false),
                    Point_Karma = table.Column<int>(nullable: false),
                    Point_Military = table.Column<int>(nullable: false),
                    TraderRate = table.Column<int>(nullable: false),
                    TrainSpeed = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    VictoryStat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGameSettings", x => x.SettingID);
                    table.ForeignKey(
                        name: "FK_UserGameSettings_Account_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "UserTechnologyTree",
                columns: table => new
                {
                    TechnologyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CULTURE_BTimeReduction = table.Column<int>(nullable: false),
                    CULTURE_Morale = table.Column<int>(nullable: false),
                    ECONOMY_Obey = table.Column<int>(nullable: false),
                    ECONOMY_SafeRoad = table.Column<int>(nullable: false),
                    MILITARY_Defence = table.Column<int>(nullable: false),
                    MILITARY_Power = table.Column<int>(nullable: false),
                    UserID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTechnologyTree", x => x.TechnologyID);
                    table.ForeignKey(
                        name: "FK_UserTechnologyTree_Account_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
            migrationBuilder.CreateTable(
                name: "Mission",
                columns: table => new
                {
                    MissionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Army_Bowman = table.Column<int>(nullable: false),
                    Army_Rider = table.Column<int>(nullable: false),
                    Army_Swordman = table.Column<int>(nullable: false),
                    MissionType = table.Column<int>(nullable: false),
                    Time = table.Column<DateTime>(nullable: false),
                    TownFrom = table.Column<int>(nullable: false),
                    TownFromGod = table.Column<string>(nullable: true),
                    TownId = table.Column<int>(nullable: false),
                    TownTo = table.Column<int>(nullable: false),
                    TownToGod = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mission", x => x.MissionID);
                    table.ForeignKey(
                        name: "FK_Mission_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TownArmy",
                columns: table => new
                {
                    TownArmyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Bowman = table.Column<int>(nullable: false),
                    Rider = table.Column<int>(nullable: false),
                    Swordman = table.Column<int>(nullable: false),
                    TownId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownArmy", x => x.TownArmyID);
                    table.ForeignKey(
                        name: "FK_TownArmy_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TownBuildings",
                columns: table => new
                {
                    BuildingsID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Barracks = table.Column<int>(nullable: false),
                    CityWall = table.Column<int>(nullable: false),
                    Farm = table.Column<int>(nullable: false),
                    MeatCamp = table.Column<int>(nullable: false),
                    Mine = table.Column<int>(nullable: false),
                    TaxHouse = table.Column<int>(nullable: false),
                    TechnologyCamp = table.Column<int>(nullable: false),
                    Temple = table.Column<int>(nullable: false),
                    TownCenter = table.Column<int>(nullable: false),
                    TownID = table.Column<int>(nullable: false),
                    TradeHouse = table.Column<int>(nullable: false),
                    Warehouse = table.Column<int>(nullable: false),
                    WoodCutterHut = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownBuildings", x => x.BuildingsID);
                    table.ForeignKey(
                        name: "FK_TownBuildings_Towns_TownID",
                        column: x => x.TownID,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "TownPopulations",
                columns: table => new
                {
                    PopulationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AggressivePop = table.Column<int>(nullable: false),
                    BreedRate = table.Column<int>(nullable: false),
                    CulturalPop = table.Column<int>(nullable: false),
                    TownId = table.Column<int>(nullable: false),
                    TraderPop = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TownPopulations", x => x.PopulationID);
                    table.ForeignKey(
                        name: "FK_TownPopulations_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateTable(
                name: "UpgradeQueue",
                columns: table => new
                {
                    UpgradeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildingINDEX = table.Column<int>(nullable: false),
                    ProductionTime = table.Column<DateTime>(nullable: false),
                    TownID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpgradeQueue", x => x.UpgradeID);
                    table.ForeignKey(
                        name: "FK_UpgradeQueue_Towns_TownID",
                        column: x => x.TownID,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName");
            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");
            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("AspNetRoleClaims");
            migrationBuilder.DropTable("AspNetUserClaims");
            migrationBuilder.DropTable("AspNetUserLogins");
            migrationBuilder.DropTable("AspNetUserRoles");
            migrationBuilder.DropTable("Messages");
            migrationBuilder.DropTable("Mission");
            migrationBuilder.DropTable("TownArmy");
            migrationBuilder.DropTable("TownBuildings");
            migrationBuilder.DropTable("TownPopulations");
            migrationBuilder.DropTable("UpgradeQueue");
            migrationBuilder.DropTable("UserGameSettings");
            migrationBuilder.DropTable("UserTechnologyTree");
            migrationBuilder.DropTable("AspNetRoles");
            migrationBuilder.DropTable("Towns");
            migrationBuilder.DropTable("AspNetUsers");
        }
    }
}
