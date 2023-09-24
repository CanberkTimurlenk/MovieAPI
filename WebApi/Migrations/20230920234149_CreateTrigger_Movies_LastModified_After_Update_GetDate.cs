using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrigger_Movies_LastModified_After_Update_GetDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE TRIGGER TRG_Movies_LastModified_After_Update_GetDate
                                    ON dbo.Movies
                                    AFTER UPDATE
                                    AS
                                        UPDATE dbo.Movies
                                        SET LastModified = GETDATE()
                                        WHERE ID IN (SELECT DISTINCT ID FROM Inserted)"
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER TRG_Movies_LastModified_After_Update_GetDate");
        }
    }
}
