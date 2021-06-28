using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication9.Data.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a", "13a780f2-cee3-4544-9796-3153c159f543", "ApplicationRole", "Admin", "ADMIN" },
                    { "878d4414-d052-4796-9128-e25811b6bde5", "7e7d94c3-28bc-43a5-ae14-1ade5a6fb114", "ApplicationRole", "Ethics Primary User", "ETHICS PRIMARY USER" },
                    { "c7f1717d-10c0-418e-8ae2-d796dd8893af", "df286099-1e5f-4cc4-8792-97bce2924a2d", "ApplicationRole", "IE Filer Secondary User", "IE FILER SECONDARY USER" },
                    { "d761ae56-7978-449c-af48-8ea55cc51cf2", "ece98eab-d910-4491-a09e-6fba7fd56069", "ApplicationRole", "IE Filer Primary User", "IE FILER PRIMARY USER" },
                    { "ff029abe-0cbb-41ea-9f31-65bc6c474d65", "9edb1dfe-f5ba-4441-a767-64a59dec7b6a", "ApplicationRole", "Other Lobbyost", "OTHER LOBBYOST" },
                    { "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a", "8ea00725-f3f3-45cd-b413-46f353fd8c06", "ApplicationRole", "Ethics Secondary User", "ETHICS SECONDARY USER" },
                    { "c9c80dbb-dea4-466c-8024-81c4d59d21ff", "d93a78c1-def6-448b-a34f-cc9108b61642", "ApplicationRole", "Officer", "OFFICER" },
                    { "952428ed-d144-4b77-bb68-46557285f730", "f8a5e7e1-deba-42b0-b4ce-3bd7873c07a8", "ApplicationRole", "Treasurer", "TREASURER" },
                    { "f8ee5677-2983-40ca-924d-fa131789457b", "2b9b6bfc-8fda-465f-a6bb-07b376913f27", "ApplicationRole", "Candidate", "CANDIDATE" },
                    { "db44c661-3aa3-4f69-b766-0dcdb95f9dec", "3a9c53e7-4f07-439d-b84b-7aa4719b71b4", "ApplicationRole", "Primary Registered Lobbyist", "PRIMARY REGISTERED LOBBYIST" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "5f094eb0-c08c-4c95-a085-9e93638d981c", 0, "c16dd032-f8c5-4968-a07a-d95e6abc7377", "ethicsprimaryuser@maplight.org", true, false, null, "ETHICSPRIMARYUSER@MAPLIGHT.ORG", "ETHICSPRIMARYUSER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEHxtAXyHKCWAH87MKqLA59fgKtddxTNJAsbSaHCxrBOj4UWlKTF6ifF8/55sAxkXfQ==", "255684811050", false, "e4dece80-7323-4465-85a9-24d80c3d4753", false, "ethicsprimaryuser@maplight.org" },
                    { "c2b0541f-4819-4a10-9e62-63d53c2bf8a8", 0, "a66fc890-e48f-4e38-af8a-f8f8ac1dd1b7", "admin@maplight.org", true, false, null, "ADMIN@MAPLIGHT.ORG", "ADMIN@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEE5OHKWPHhfzYMqrgZbJ4JrVHHQppQKl0LHCYKQDVftRPeViISVoTP9RAgl5CFIvow==", "255684811042", false, "9b952aa8-dce1-4d39-ac47-a48ea3b5bfb5", false, "admin@maplight.org" },
                    { "aff709de-7468-451e-9839-b538cc7e9941", 0, "5823ff7a-9553-49d6-b893-04be3b48fe57", "candidate@maplight.org", true, false, null, "CANDIDATE@MAPLIGHT.ORG", "CANDIDATE@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEKUz774XwUqrWIAyl0qIgjzEms6Lh+XK5fDg4C9zUPbEuseHoLlazkKI9Z8ddoPnqA==", "255684811043", false, "6e12dd91-f3b7-445c-ab5c-a67d0d08c0c3", false, "candidate@maplight.org" },
                    { "ad89b30a-695b-4296-8a60-fd8f3f2936d7", 0, "675dfae5-6aaa-441f-a8ab-1fd3caa54c82", "treasurer@maplight.org", true, false, null, "TREASURER@MAPLIGHT.ORG", "TREASURER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEISpeaVlCeqtQaWCeoemiF2dMF2PmwOWSCKKtA6NuI5QJZ2gk59D+u1xg9EfcLE5XQ==", "255684811044", false, "60d7f70a-89b2-4a48-9cd7-6dadc33cd862", false, "treasurer@maplight.org" },
                    { "1f4b26a9-d046-4513-97f8-784c4fd31486", 0, "1864406b-7db4-46f6-be79-2a077db9575e", "officer@maplight.org", true, false, null, "OFFICER@MAPLIGHT.ORG", "OFFICER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEJLAoZLucfbUJAh8Xm8ANiAIKnyw2Zs9RHfV6v08iwNgZ/yaWbEIxhx416E/1vA8LA==", "255684811045", false, "2aa61fe4-8720-45bf-b025-1aa360d9a888", false, "officer@maplight.org" },
                    { "23b03c1d-9439-42c3-989e-afc4caa371f6", 0, "161ab4b4-9be2-4531-b2b6-08c86cd98b57", "primaryregisteredlobbyist@maplight.org", true, false, null, "PRIMARYREGISTEREDLOBBYIST@MAPLIGHT.ORG", "PRIMARYREGISTEREDLOBBYIST@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEPDpk5d+ek1EMjNXMAyBW0ynxVSNUXbSFwLH8m7JtP2QEfDMtmeiFbMz0aL9N3eBRQ==", "255684811046", false, "97452989-c6be-4c7e-bb73-d345724f0507", false, "primaryregisteredlobbyist@maplight.org" },
                    { "c5facb3c-7289-4756-9afb-4e02f5a28740", 0, "ce919715-46ae-4741-9c27-6b515fe48b38", "otherlobbyost@maplight.org", true, false, null, "OTHERLOBBYOST@MAPLIGHT.ORG", "OTHERLOBBYOST@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAECt81gCCUJQnTrOD35w45io8V/IU5+/IpPaMnU2fiozgDeLBPKPrhMKpobgzsvbr1w==", "255684811047", false, "66e7187f-4e8e-492a-a4f9-c566b6fa830e", false, "otherlobbyost@maplight.org" },
                    { "0fb18dd5-9cff-4635-86d0-76416b16b570", 0, "040021a7-4266-4344-a53f-27c8142cfbb6", "iefilerprimaryuser@maplight.org", true, false, null, "IEFILERPRIMARYUSER@MAPLIGHT.ORG", "IEFILERPRIMARYUSER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEKYOgeoc4XfRVeM9dJ3Ispv9a08ocQp0CC8kRqkOtkfdb+lPz+vLCoekF8bNG2CQXA==", "255684811048", false, "17a9e822-5506-4b01-a9d0-5cf0d922d011", false, "iefilerprimaryuser@maplight.org" },
                    { "92465d77-d88d-487a-86aa-d8783fc8702d", 0, "7fe6591b-b6b0-4424-81ad-aab06f422658", "iefilersecondaryuser@maplight.org", true, false, null, "iefilersecondaryuser@MAPLIGHT.ORG", "IEFILERSECONDARYUSER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAEAEMzyAsSLhnDfcyzH5QMD0mYRirGO2yKJr0V8VUyMAGcFuYcahnhHlZb0oyAwPIrw==", "255684811049", false, "2e43dd0b-7c79-4344-8a3e-7463161aa2f6", false, "iefilersecondaryuser@maplight.org" },
                    { "aac55d50-3863-47ba-bfc0-bd68c0d770af", 0, "bef7a836-24fe-4d40-9dbf-d81812be613e", "ethicssecondaryuser@maplight.org", true, false, null, "ETHICSSECONDARYUSER@MAPLIGHT.ORG", "ETHICSSECONDARYUSER@MAPLIGHT.ORG", "AQAAAAEAACcQAAAAELgJRnGdGwwHaQIJHDme/jbbB05G0IRThgMJZyRt6m6AyjcCjB2l3GT8xrgr8WYbOQ==", "255684811051", false, "06207805-a6be-490a-bd0f-683811783b77", false, "ethicssecondaryuser@maplight.org" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[,]
                {
                    { "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a", "c2b0541f-4819-4a10-9e62-63d53c2bf8a8", "ApplicationUserRole" },
                    { "f8ee5677-2983-40ca-924d-fa131789457b", "aff709de-7468-451e-9839-b538cc7e9941", "ApplicationUserRole" },
                    { "952428ed-d144-4b77-bb68-46557285f730", "ad89b30a-695b-4296-8a60-fd8f3f2936d7", "ApplicationUserRole" },
                    { "c9c80dbb-dea4-466c-8024-81c4d59d21ff", "1f4b26a9-d046-4513-97f8-784c4fd31486", "ApplicationUserRole" },
                    { "db44c661-3aa3-4f69-b766-0dcdb95f9dec", "23b03c1d-9439-42c3-989e-afc4caa371f6", "ApplicationUserRole" },
                    { "ff029abe-0cbb-41ea-9f31-65bc6c474d65", "c5facb3c-7289-4756-9afb-4e02f5a28740", "ApplicationUserRole" },
                    { "d761ae56-7978-449c-af48-8ea55cc51cf2", "0fb18dd5-9cff-4635-86d0-76416b16b570", "ApplicationUserRole" },
                    { "c7f1717d-10c0-418e-8ae2-d796dd8893af", "92465d77-d88d-487a-86aa-d8783fc8702d", "ApplicationUserRole" },
                    { "878d4414-d052-4796-9128-e25811b6bde5", "5f094eb0-c08c-4c95-a085-9e93638d981c", "ApplicationUserRole" },
                    { "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a", "aac55d50-3863-47ba-bfc0-bd68c0d770af", "ApplicationUserRole" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d761ae56-7978-449c-af48-8ea55cc51cf2", "0fb18dd5-9cff-4635-86d0-76416b16b570" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c9c80dbb-dea4-466c-8024-81c4d59d21ff", "1f4b26a9-d046-4513-97f8-784c4fd31486" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db44c661-3aa3-4f69-b766-0dcdb95f9dec", "23b03c1d-9439-42c3-989e-afc4caa371f6" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "878d4414-d052-4796-9128-e25811b6bde5", "5f094eb0-c08c-4c95-a085-9e93638d981c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7f1717d-10c0-418e-8ae2-d796dd8893af", "92465d77-d88d-487a-86aa-d8783fc8702d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a", "aac55d50-3863-47ba-bfc0-bd68c0d770af" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "952428ed-d144-4b77-bb68-46557285f730", "ad89b30a-695b-4296-8a60-fd8f3f2936d7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f8ee5677-2983-40ca-924d-fa131789457b", "aff709de-7468-451e-9839-b538cc7e9941" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a", "c2b0541f-4819-4a10-9e62-63d53c2bf8a8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff029abe-0cbb-41ea-9f31-65bc6c474d65", "c5facb3c-7289-4756-9afb-4e02f5a28740" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1e67e9cd-bf7e-4621-9b04-68ed8573ad2a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "878d4414-d052-4796-9128-e25811b6bde5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8afc03f5-d7f3-4358-90b2-ddbecb8fe77a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "952428ed-d144-4b77-bb68-46557285f730");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c7f1717d-10c0-418e-8ae2-d796dd8893af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c9c80dbb-dea4-466c-8024-81c4d59d21ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d761ae56-7978-449c-af48-8ea55cc51cf2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db44c661-3aa3-4f69-b766-0dcdb95f9dec");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f8ee5677-2983-40ca-924d-fa131789457b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff029abe-0cbb-41ea-9f31-65bc6c474d65");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0fb18dd5-9cff-4635-86d0-76416b16b570");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1f4b26a9-d046-4513-97f8-784c4fd31486");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23b03c1d-9439-42c3-989e-afc4caa371f6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5f094eb0-c08c-4c95-a085-9e93638d981c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92465d77-d88d-487a-86aa-d8783fc8702d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aac55d50-3863-47ba-bfc0-bd68c0d770af");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ad89b30a-695b-4296-8a60-fd8f3f2936d7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aff709de-7468-451e-9839-b538cc7e9941");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2b0541f-4819-4a10-9e62-63d53c2bf8a8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c5facb3c-7289-4756-9afb-4e02f5a28740");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");
        }
    }
}
