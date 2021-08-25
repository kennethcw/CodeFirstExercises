﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirstExercises.Migrations
{
    public partial class AddedboolHasRadio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasRadio",
                table: "Bilar",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasRadio",
                table: "Bilar");
        }
    }
}
