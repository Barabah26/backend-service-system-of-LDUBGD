using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace statement_service.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    login = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    password = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    role = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    faculty = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    specialty = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    degree = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    student_group = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    phone_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    date_birth = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "statement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    full_name = table.Column<string>(type: "text", nullable: false),
                    year_birthday = table.Column<string>(type: "text", nullable: false),
                    group_name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false),
                    faculty = table.Column<string>(type: "text", nullable: false),
                    type_of_statement = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_statement_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statement_info",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false),
                    is_ready = table.Column<bool>(type: "boolean", nullable: true),
                    statement_status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_statement_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_statement_info_statement_id",
                        column: x => x.id,
                        principalTable: "statement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_statement_UserId",
                table: "statement",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_login",
                table: "users",
                column: "login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_name",
                table: "users",
                column: "name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "statement_info");

            migrationBuilder.DropTable(
                name: "statement");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
