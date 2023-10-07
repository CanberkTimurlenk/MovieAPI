using Microsoft.EntityFrameworkCore.Migrations;
using Models.Concrete.Entities;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Create_Trigger_Prevent_Duplicate_Awards_for_AwardTypeId_and_DateAsYear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE FUNCTION Prevent_Duplicate_Awards()
                                    RETURNS TRIGGER AS $$
                                    BEGIN
                                    
                                        IF EXISTS (
                                            SELECT 1
                                            FROM ""Awards"" a
                                            WHERE a.""AwardTypeId"" = NEW.""AwardTypeId""
                                            AND EXTRACT(YEAR FROM a.""Date"") = EXTRACT(YEAR FROM NEW.""Date"")
                                        ) THEN
                                            RAISE EXCEPTION 'Duplicate Awards Not Allowed!';
                                        ELSE
                                    
                                            RETURN NEW;
                                        END IF;
                                    END;
                                    $$ LANGUAGE plpgsql;"
                                );

            migrationBuilder.Sql($@"CREATE TRIGGER TRG_Insert_Awards
                                    BEFORE INSERT ON ""Awards""
                                    FOR EACH ROW
                                    EXECUTE FUNCTION Prevent_Duplicate_Awards();"
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TRIGGER IF EXISTS TRG_Insert_Awards ON ""Awards""");
            migrationBuilder.Sql("DROP FUNCTION IF EXISTS Prevent_Duplicate_Awards()");

        }
    }
}
