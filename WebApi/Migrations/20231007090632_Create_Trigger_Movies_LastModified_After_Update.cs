using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_Trigger_Movies_LastModified_After_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE FUNCTION Update_Movies_LastModified()
                                    RETURNS TRIGGER AS $$
                                    BEGIN
                                        NEW.""LastModified"" = NOW();
                                        RETURN NEW;
                                    END;
                                    $$ LANGUAGE plpgsql;"
                                );

            migrationBuilder.Sql($@"CREATE TRIGGER TRG_Movies_LastModified_After_Update_GetDate
                                    BEFORE UPDATE ON ""Movies""
                                    FOR EACH ROW
                                    EXECUTE FUNCTION Update_Movies_LastModified();"
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS TRG_Movies_LastModified_After_Update_GetDate ON ""Movies"";");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS Update_Movies_LastModified();");
        }
    }
}