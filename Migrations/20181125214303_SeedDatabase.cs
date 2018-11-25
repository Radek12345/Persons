using Microsoft.EntityFrameworkCore.Migrations;

namespace Persons.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Cities (name) VALUES ('City1')");
            migrationBuilder.Sql("INSERT INTO Cities (name) VALUES ('City2')");
            migrationBuilder.Sql("INSERT INTO Companies (name) VALUES ('Company1')");
            migrationBuilder.Sql("INSERT INTO Companies (name) VALUES ('Company2')");
            migrationBuilder.Sql("INSERT INTO CompanyBranches (name, companyid) VALUES ('Company1A', (SELECT id FROM Companies WHERE name = 'Company1'))");
            migrationBuilder.Sql("INSERT INTO CompanyBranches (name, companyid) VALUES ('Company1B', (SELECT id FROM Companies WHERE name = 'Company1'))");
            migrationBuilder.Sql("INSERT INTO CompanyBranches (name, companyid) VALUES ('Company2A', (SELECT id FROM Companies WHERE name = 'Company2'))");
            migrationBuilder.Sql("INSERT INTO CompanyBranches (name, companyid) VALUES ('Company2B', (SELECT id FROM Companies WHERE name = 'Company2'))");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Cities WHERE name IN ('City1', 'City2')");
            migrationBuilder.Sql("DELETE FROM CompanyBranches WHERE name IN ('Company1A', 'Company1B', 'Company2A', 'Company2B')");
            migrationBuilder.Sql("DELETE FROM Companies WHERE name IN ('Company1', 'Company2')");
        }
    }
}
