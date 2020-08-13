using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoalsManager.Migrations
{
    public partial class TaskTableChangedToGoalTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Tasks_TaskId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_TaskId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "DateTimeStart",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "Notifications");

            migrationBuilder.AddColumn<long>(
                name: "GoalId",
                table: "Notifications",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "NotificationStartTime",
                table: "Notifications",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Group = table.Column<string>(nullable: true),
                    DateTimeStart = table.Column<DateTime>(nullable: false),
                    DateTimeEnd = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_GoalId",
                table: "Notifications",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Goals_GoalId",
                table: "Notifications",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Goals_GoalId",
                table: "Notifications");

            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_GoalId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "GoalId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "NotificationStartTime",
                table: "Notifications");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStart",
                table: "Notifications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TaskId",
                table: "Notifications",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TaskParentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Tasks_Tasks_TaskParentId",
                        column: x => x.TaskParentId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_TaskId",
                table: "Notifications",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskParentId",
                table: "Tasks",
                column: "TaskParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Tasks_TaskId",
                table: "Notifications",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "TaskId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
