using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using OdeToFood.Models;

namespace OdeToFood.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: false);
            migrationBuilder.AddColumn<int>(
                name: "Cuisine",
                table: "Restaurant",
                nullable: false,
                defaultValue: Cuisine.None);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Cuisine", table: "Restaurant");
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Restaurant",
                nullable: true);
        }
    }
}
