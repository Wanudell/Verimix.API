using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VMix.Data.Migrations
{
    /// <inheritdoc />
    public partial class authEntitiesCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "Products",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "Products",
                newName: "modifiedAt");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Products",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Products",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "Products",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "Products",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Products",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Products",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ModifiedBy",
                table: "ConfigNavMenus",
                newName: "modifiedBy");

            migrationBuilder.RenameColumn(
                name: "ModifiedAt",
                table: "ConfigNavMenus",
                newName: "modifiedAt");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "ConfigNavMenus",
                newName: "isDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "ConfigNavMenus",
                newName: "isActive");

            migrationBuilder.RenameColumn(
                name: "DeletedBy",
                table: "ConfigNavMenus",
                newName: "deletedBy");

            migrationBuilder.RenameColumn(
                name: "DeletedAt",
                table: "ConfigNavMenus",
                newName: "deletedAt");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "ConfigNavMenus",
                newName: "createdBy");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "ConfigNavMenus",
                newName: "createdAt");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ConfigNavMenus",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "lineNo",
                table: "ConfigNavMenus",
                newName: "lineNr");

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "Products",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "createdBy",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "isDeleted",
                table: "ConfigNavMenus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "isActive",
                table: "ConfigNavMenus",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "createdBy",
                table: "ConfigNavMenus",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AuthPermissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    route = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    permission = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthPermissions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthRoles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthRoles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AuthUsers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qrToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    refreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    refreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    lastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    firstLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    createdBy = table.Column<int>(type: "int", nullable: false),
                    modifiedBy = table.Column<int>(type: "int", nullable: true),
                    deletedBy = table.Column<int>(type: "int", nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    modifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    deletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthUsers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthPermissions");

            migrationBuilder.DropTable(
                name: "AuthRoles");

            migrationBuilder.DropTable(
                name: "AuthUsers");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "Products",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "modifiedAt",
                table: "Products",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "Products",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "Products",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "Products",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "Products",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "Products",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Products",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "modifiedBy",
                table: "ConfigNavMenus",
                newName: "ModifiedBy");

            migrationBuilder.RenameColumn(
                name: "modifiedAt",
                table: "ConfigNavMenus",
                newName: "ModifiedAt");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "ConfigNavMenus",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "isActive",
                table: "ConfigNavMenus",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "deletedBy",
                table: "ConfigNavMenus",
                newName: "DeletedBy");

            migrationBuilder.RenameColumn(
                name: "deletedAt",
                table: "ConfigNavMenus",
                newName: "DeletedAt");

            migrationBuilder.RenameColumn(
                name: "createdBy",
                table: "ConfigNavMenus",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "ConfigNavMenus",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ConfigNavMenus",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "lineNr",
                table: "ConfigNavMenus",
                newName: "lineNo");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "ConfigNavMenus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "ConfigNavMenus",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedBy",
                table: "ConfigNavMenus",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    customerId = table.Column<int>(type: "int", nullable: true),
                    permissions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    roleId = table.Column<int>(type: "int", nullable: false),
                    route = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    roleName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    expiresInMinutes = table.Column<DateTime>(type: "datetime2", nullable: true),
                    firstLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    lastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    passwordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    profilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    qrToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    refreshToken = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    roleId = table.Column<int>(type: "int", nullable: true),
                    token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }
    }
}
