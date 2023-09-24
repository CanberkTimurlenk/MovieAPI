using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class CreateTrigger_Prevent_Duplicate_Awards : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($@"CREATE TRIGGER TRG_PreventDuplicateAwards
                                    ON Awards
                                    INSTEAD OF INSERT
                                    AS
                                    BEGIN
                                        IF EXISTS 
                                        (
                                            SELECT 1
                                            FROM AWARDS a
                                            INNER JOIN INSERTED i ON a.AwardTypeId = i.AwardTypeId AND YEAR(a.DATE) = YEAR(i.DATE)       
                                        )
                                        BEGIN
                                            ROLLBACK TRANSACTION
                                            RAISERROR('Duplicate Awards Not Allowed!',16,1)
                                        END
                                        
                                        ELSE

                                        BEGIN
                                        INSERT INTO AWARDS (AwardTypeId, DATE,Description,MovieId)
                                            SELECT AwardTypeId, DATE,Description,MovieId
                                            FROM INSERTED
                                        END

                                    END;
                                    "
                                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER TRG_PreventDuplicateAwards");
        }
    }
}
