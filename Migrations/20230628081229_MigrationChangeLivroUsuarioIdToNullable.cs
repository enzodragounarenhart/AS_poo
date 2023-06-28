using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_poo.Migrations
{
    /// <inheritdoc />
    public partial class MigrationChangeLivroUsuarioIdToNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Usuario_UsuarioId",
                table: "Livro");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Livro",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Usuario_UsuarioId",
                table: "Livro",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Livro_Usuario_UsuarioId",
                table: "Livro");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Livro",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Livro_Usuario_UsuarioId",
                table: "Livro",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
