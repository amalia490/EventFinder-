using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class TicketChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "TicketTypes",
                newName: "Description");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "TicketTypes",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "availableTickets",
                table: "TicketTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "availableTickets",
                table: "TicketTypes");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "TicketTypes",
                newName: "Email");
        }
    }
}
