using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AS_poo.Migrations
{
    /// <inheritdoc />
    public partial class DadosIniciais : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData
            (
                table: "Usuario",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Fulano", "111.111.111-11", "rua tal 111", "(51)11111-1111"}
            );
            migrationBuilder.InsertData
            (
                table: "Usuario",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Ciclano", "222.222.222-22", "rua mal 222", "(51)22222-2222"}
            );
            migrationBuilder.InsertData
            (
                table: "Usuario",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Beltrano", "333.333.333-33", "rua gal 333", "(51)33333-3333"}
            );
            migrationBuilder.InsertData
            (
                table: "Autor",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Fulano", "111.111.111-11", "rua tal 111", "(51)11111-1111"}
            );
            migrationBuilder.InsertData
            (
                table: "Autor",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Ciclano", "222.222.222-22", "rua mal 222", "(51)22222-2222"}
            );
            migrationBuilder.InsertData
            (
                table: "Autor",
                columns: new[] {"nome", "cpf", "endereco", "contato"},
                values: new object[] {"Beltrano", "333.333.333-33", "rua gal 333", "(51)33333-3333"}
            );
            migrationBuilder.InsertData
            (
                table: "Livro",
                columns: new[] {"ano", "emprestado", "genero", "nome", "paginas"},
                values: new object[] { 1990, 0, "fantasia", "nome fantasia", 230}
            );
            migrationBuilder.InsertData
            (
                table: "Livro",
                columns: new[] {"ano", "emprestado", "genero", "nome", "paginas"},
                values: new object[] { 2005, 0, "romance", "nome romance", 200}
            );
            migrationBuilder.InsertData
            (
                table: "Livro",
                columns: new[] {"ano", "emprestado", "genero", "nome", "paginas"},
                values: new object[] { 1991, 0, "culinaria", "nome culinaria", 100}
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData
            (
                table: "Usuario",
                keyColumn: "id",
                keyValues: null
            );
            
            migrationBuilder.DeleteData
            (
                table: "Livro",
                keyColumn: "id",
                keyValues: null
            );
            migrationBuilder.DeleteData
            (
                table: "Autor",
                keyColumn: "id",
                keyValues: null
            );
        }
    }
}
