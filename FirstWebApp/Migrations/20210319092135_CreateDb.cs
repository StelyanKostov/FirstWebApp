using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FirstWebApp.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Charging = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battery", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Body",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dimensions = table.Column<string>(nullable: true),
                    Weight = table.Column<string>(nullable: true),
                    SIM = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Body", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Connect",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WLAN = table.Column<string>(nullable: true),
                    Bluetooth = table.Column<string>(nullable: true),
                    GPS = table.Column<string>(nullable: true),
                    NFC = table.Column<string>(nullable: true),
                    Radio = table.Column<string>(nullable: true),
                    USB = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connect", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Announced = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Display",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true),
                    Size = table.Column<string>(nullable: true),
                    Resolution = table.Column<string>(nullable: true),
                    Protection = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Display", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sensors = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hardware",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OS = table.Column<string>(nullable: true),
                    Chipset = table.Column<string>(nullable: true),
                    CPU = table.Column<string>(nullable: true),
                    GPU = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hardware", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MainCamera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quad = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainCamera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardSlot = table.Column<string>(nullable: true),
                    Internal = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Network",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Technology = table.Column<string>(nullable: true),
                    TwoGBands = table.Column<string>(nullable: true),
                    TreeGBands = table.Column<string>(nullable: true),
                    FourGBands = table.Column<string>(nullable: true),
                    FiveGBands = table.Column<string>(nullable: true),
                    Speed = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Network", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelfieCamera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Single = table.Column<string>(nullable: true),
                    Features = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfieCamera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sound",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Loudspeaker = table.Column<string>(nullable: true),
                    TreeFiveMMJack = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sound", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "View",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(nullable: true),
                    Models = table.Column<string>(nullable: true),
                    Other = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
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
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Smartphones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    batteryId = table.Column<int>(nullable: true),
                    bodyId = table.Column<int>(nullable: true),
                    connectId = table.Column<int>(nullable: true),
                    displayId = table.Column<int>(nullable: true),
                    featuresId = table.Column<int>(nullable: true),
                    dateId = table.Column<int>(nullable: true),
                    mainCameraId = table.Column<int>(nullable: true),
                    memoryId = table.Column<int>(nullable: true),
                    viewId = table.Column<int>(nullable: true),
                    networkId = table.Column<int>(nullable: true),
                    hardwareId = table.Column<int>(nullable: true),
                    selfieCameraId = table.Column<int>(nullable: true),
                    soundId = table.Column<int>(nullable: true),
                    imageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Smartphones_Battery_batteryId",
                        column: x => x.batteryId,
                        principalTable: "Battery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Body_bodyId",
                        column: x => x.bodyId,
                        principalTable: "Body",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Connect_connectId",
                        column: x => x.connectId,
                        principalTable: "Connect",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Date_dateId",
                        column: x => x.dateId,
                        principalTable: "Date",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Display_displayId",
                        column: x => x.displayId,
                        principalTable: "Display",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Features_featuresId",
                        column: x => x.featuresId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Hardware_hardwareId",
                        column: x => x.hardwareId,
                        principalTable: "Hardware",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Image_imageId",
                        column: x => x.imageId,
                        principalTable: "Image",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_MainCamera_mainCameraId",
                        column: x => x.mainCameraId,
                        principalTable: "MainCamera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Memory_memoryId",
                        column: x => x.memoryId,
                        principalTable: "Memory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Network_networkId",
                        column: x => x.networkId,
                        principalTable: "Network",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_SelfieCamera_selfieCameraId",
                        column: x => x.selfieCameraId,
                        principalTable: "SelfieCamera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_Sound_soundId",
                        column: x => x.soundId,
                        principalTable: "Sound",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Smartphones_View_viewId",
                        column: x => x.viewId,
                        principalTable: "View",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_batteryId",
                table: "Smartphones",
                column: "batteryId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_bodyId",
                table: "Smartphones",
                column: "bodyId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_connectId",
                table: "Smartphones",
                column: "connectId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_dateId",
                table: "Smartphones",
                column: "dateId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_displayId",
                table: "Smartphones",
                column: "displayId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_featuresId",
                table: "Smartphones",
                column: "featuresId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_hardwareId",
                table: "Smartphones",
                column: "hardwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_imageId",
                table: "Smartphones",
                column: "imageId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_mainCameraId",
                table: "Smartphones",
                column: "mainCameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_memoryId",
                table: "Smartphones",
                column: "memoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_networkId",
                table: "Smartphones",
                column: "networkId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_selfieCameraId",
                table: "Smartphones",
                column: "selfieCameraId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_soundId",
                table: "Smartphones",
                column: "soundId");

            migrationBuilder.CreateIndex(
                name: "IX_Smartphones_viewId",
                table: "Smartphones",
                column: "viewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Smartphones");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Battery");

            migrationBuilder.DropTable(
                name: "Body");

            migrationBuilder.DropTable(
                name: "Connect");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "Display");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Hardware");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropTable(
                name: "MainCamera");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropTable(
                name: "Network");

            migrationBuilder.DropTable(
                name: "SelfieCamera");

            migrationBuilder.DropTable(
                name: "Sound");

            migrationBuilder.DropTable(
                name: "View");
        }
    }
}
