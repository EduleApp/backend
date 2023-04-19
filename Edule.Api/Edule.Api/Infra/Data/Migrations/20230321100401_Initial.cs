using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Edule.Api.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Establishment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Slug = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Color = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    AtHome = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MaxDistance = table.Column<int>(type: "int", nullable: true),
                    Inactive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Title = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Slug = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Postcode = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LineOne = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    LineTwo = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    City = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    State = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Country = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Geolocation = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    FormattedAddress = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EstablishmentId = table.Column<Guid>(type: "char(36)", nullable: true),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Establishment_EstablishmentId",
                        column: x => x.EstablishmentId,
                        principalTable: "Establishment",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventField",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    FieldName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    FriendlyName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Type = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventField_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScheduleAvailability",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleAvailability_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScheduleEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleEvent_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleEvent_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ScheduleException",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Day = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Begin = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    End = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    EndRecurrentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ScheduleId = table.Column<Guid>(type: "char(36)", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleException", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleException_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Address_EstablishmentId",
                table: "Address",
                column: "EstablishmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EventField_EventId",
                table: "EventField",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleAvailability_ScheduleId",
                table: "ScheduleAvailability",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEvent_EventId",
                table: "ScheduleEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleEvent_ScheduleId",
                table: "ScheduleEvent",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleException_ScheduleId",
                table: "ScheduleException",
                column: "ScheduleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "EventField");

            migrationBuilder.DropTable(
                name: "ScheduleAvailability");

            migrationBuilder.DropTable(
                name: "ScheduleEvent");

            migrationBuilder.DropTable(
                name: "ScheduleException");

            migrationBuilder.DropTable(
                name: "Establishment");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Schedule");
        }
    }
}
