using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeetourAPI.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityLevel",
                table: "TourGuides");

            migrationBuilder.DropColumn(
                name: "IDCardPhoto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0021dedb-763e-4422-b3d9-945930428104",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "29ae0e5c-95b2-4f23-92e4-9943dff3c9aa", "AQAAAAIAAYagAAAAEEmVDmDd9XVEZLA+1X3ED72p4q9haq9sLzCZGyjg7PhawKtWyqspSI83zE2SYgncNg==", "6baa4e40-2fc9-482b-bc39-681186b2ab47" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0106fda0-5757-4caf-9e2c-f582c48ee029",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41eff6ac-2cc1-4771-a268-80fdb31b12d3", "AQAAAAIAAYagAAAAELZY1Q0xI3nl/GZDUlTP8KxdRE+4AuBORXMzlfANjYxxW5odhxS+UJI2kLxP7EFt+w==", "8a0de6d5-258b-44d3-89be-63f83b2f38f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017e9b5b-1b27-4dd8-9c52-76bd328a6c83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de7ac231-a08b-4027-af03-1aa85240d1d2", "AQAAAAIAAYagAAAAEEIW4beh7PMbIQ+00HfnM3ulil5UeZwvtDX69DK3OllgCwYCfEKDZfsp49I61537/A==", "c16b97aa-b898-434c-86ce-573255ffe734" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02fd99ed-3b83-4245-8a29-1d5688f97897",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4600dc4-57d7-42ce-8ed5-e929529192a7", "AQAAAAIAAYagAAAAEABDUv2E4R2o+l2kyr/yCnG9ilDl4VEZhrlOTTLf9ls4nFJfHDRCfaStkicrj2N8Lg==", "76e1c8fe-f076-4490-a42e-c318e856293a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0938efa8-a702-41bd-af20-4e38eedd5125",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7bea4e18-51fc-4516-a669-cef3bd6758c7", "AQAAAAIAAYagAAAAEAL/x9QjHx8ZfhzAEzg8WEaxPW/CcxyIVNI4BPAOTqzTIsokxy0FNsA7woiaddHpzA==", "cd1b100b-472f-4d90-a114-dfa71f5f2430" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c9c7596-4439-4b1a-86fb-1d1507ec6197",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f221135-758b-4f98-9ff0-b6d1a2e99de6", "AQAAAAIAAYagAAAAEEh1BuJ1O0KqQkwu5KsTtWkURydh7pN5YPNA49HoT3QojcCZKIxHXkPMVgSkvVDTEA==", "fc177555-2e0c-4423-84e1-e9b55e250f89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f47ed8c-875e-4f78-b746-8094302d5fca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7809ed2c-b719-4728-8e33-d1e1fab30df6", "AQAAAAIAAYagAAAAEN3Q5/ysjFgSRWp7AxjTZyycDNLhNKdA6RKhXWSxyGP0jhB6yHtbQuyHANZekA5V8g==", "f84a62ae-f71e-4acd-bba3-8d230adf3b84" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12b54922-5fc0-4668-8610-08d0daea1c23",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "18fdf80b-6791-439c-bc13-b9c1aa3106dc", "AQAAAAIAAYagAAAAEG3klT5aZlaE1jK17Bs9//kjx7Sm75ri7hVKGbxJd6ZAFK8cTlZJmm20QxaLE3LI5g==", "5b0da0c0-1985-4b56-8563-c923b4796d3f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13f4d8d9-b5ae-4b79-9178-6aa26d6c5dd5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "932ed6cb-aec8-4686-a2e7-402b5b5c5e72", "AQAAAAIAAYagAAAAEE+4+O0vOEveZIY24d4Hqz59TspEPHURaq5I5FAH01MfDKlDGpz28YqV2G9tQH/LnA==", "d6b02a81-8b9a-4a36-a9ac-961a57ab3249" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1927b325-2a3b-47d4-b4ef-cb1b9071d3af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7265ce9-c1e0-499f-ab84-3f8d1ee5034e", "AQAAAAIAAYagAAAAEDsbjn48FxIiRmgB5bZrF2LGlOr606jAeO8EUJcQNjBxksP3pgpfQWRemD4HARunoA==", "375417f8-c259-4ba3-bab6-87ee43d5cc75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a8b75f1-76f7-4227-bd1c-ce54728ec12d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3bd91897-8b7c-4edd-b7f1-ff81b24a0f39", "AQAAAAIAAYagAAAAEPvugYIaxU6C4YTJkWjUREukXsx1sgy3Lsudl0azL/rZZOGyiujpJlSDE7ZdMFC5iA==", "88af33ca-d332-4799-89fa-7ab979191c4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1de1c9e4-0cac-45e4-91d3-42559c3ef16d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b0b4107-38f1-43cd-9e70-69ae26c08a1e", "AQAAAAIAAYagAAAAEJFnfTZpGV7A54vrnRaRL3vqHXEAUoneqMyNfju6Mpqtg092XpQTq/VGMSpioOXDOA==", "b231ca78-8521-4e85-a10c-c3600b2e6ce3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e754177-f905-4164-965d-570e46d12e8a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e63b5cc6-5c37-4673-a2eb-670e43a31aa8", "AQAAAAIAAYagAAAAEHaUz75CtokksbtWDtAWY78EaNvnxfN4oniyAbIXGav9O62uipwXpeQQIbCU7TYaRA==", "895622ef-183c-46c5-83eb-eb940872174f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "210db6ec-1ba5-4148-b9ae-ab2d9c58d37b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15dc9aa8-e15e-49c1-997f-4e94e1cca466", "AQAAAAIAAYagAAAAEFVGD4ZE7GyeB2GK0GSPm7hfWjZbbzo+4HLSyh7D+7efI3AN1VX7JLpDZ+mRjdJDCw==", "8be85ab0-f15b-4d3b-8fb2-44c12789c073" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "233204b6-ed56-42ce-851f-3a514b7b0a41",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4bd24123-c681-4c41-958f-17d24a3ad839", "AQAAAAIAAYagAAAAEO8YK9OzGYBatVXUHR2TPKIHjNIR7BbkCbBXu2LEPwxzaWpUvl+9YbWARXRHFDg1ZQ==", "610e7f30-5226-4e43-b28d-65e0d2cbaec0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "236c86d6-0ad1-4e1e-9461-1c19ddac9d1c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ffb26667-0a92-43e0-9517-9fb6e2c813c4", "AQAAAAIAAYagAAAAEC0oOdXn13f52GUm6F2IF/KsxzjTZR9YkwMaulysP6qUkmHHtv/IoSHyrEqJMEKr6w==", "64596af7-c9ca-4e1f-894c-292c5bbf4e0e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24ecccc3-5251-4072-bf3c-2c704a334ebe",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6aaf3aaf-c1fe-4bb2-a0c9-98177380cdc6", "AQAAAAIAAYagAAAAELXphM/tzM6LqZPwk4xQNb1fWTUg5NeIlCf5tb9oDuHmCC9shsYQUEp/yUtPahV2hQ==", "cc13f436-4881-460b-b56a-88b797999d73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26e3041d-41c5-443d-a863-0e41ea866599",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54043101-9eb0-4e43-a199-ddf5e47b43fe", "AQAAAAIAAYagAAAAEK0XjPyCAamXixcTlIm/OgcZfAJd9YNP//fOrnR4r3K5uO3Mx/gU3+DKYfs0nt9zdQ==", "cdfcbee0-692c-4b1a-82fd-5f8cc5bddf3a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26ebb4da-2ee5-465c-8d5f-16658eda4c2c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5f73d97b-7bf1-4267-9265-4ae67ea12fe5", "AQAAAAIAAYagAAAAEPhkIC1uLoKAmSr4GGpLDIdMNYfDZv5L8ZUxVLpRbSBsBdIxuCtJlWIqX7EXUFsaAA==", "6893a756-6b34-43c9-a196-a1430a273445" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29206f1f-b8c7-4745-8e70-41c5c0ff9c12",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48848b92-75ad-4394-a46d-0dd5c2c66e73", "AQAAAAIAAYagAAAAEIHYLvk6c02H7TTnxK4H5emzt8MluvXlfHj0HH8blYahR3VVU0D32UlTjJeJQm1pQw==", "8f6683c4-9fb5-4af4-aed2-03d0f141f710" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2906f2-c035-416a-88a5-00426bac05af",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "289ccb35-246f-405d-af10-4def5826dd58", "AQAAAAIAAYagAAAAEM3ro7mQEaFNW6dtvNcd8QrxkAN6D7DKQzlmSgiWDR5xDOHQpHpGIED0MYbmxei0Ew==", "54ed6552-9ead-4321-9d12-60b27b19916c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33a9a6ec-70c3-4805-80c9-500160908954",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35bccbfc-93b7-4dd8-b1fb-fef620ef70cc", "AQAAAAIAAYagAAAAEJ8YBL2+lj+3IAoY29L5BcQ4g+cDjCN3+0zjDqOT0JrconrG4j8+uNTPwchWUbAHNA==", "6bdbfe1d-7666-4bc6-9f4d-f16604bdb800" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "350441e3-9e3a-42e6-bc48-c850fffcf57c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b0dc650-596d-4c29-bb71-0e5c19324892", "AQAAAAIAAYagAAAAEO8CdpE3QhB5/NM1mQgzJTjsTC44Wt6AUacQOJ2zkUBgpB+uDX4Px96AzYxqb3nk3w==", "11f6119f-b446-4d34-8ee0-de5814aa231d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3650ad9b-2414-4ca1-aa61-86fcb032fc52",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0345c79d-edde-4e82-8e01-62160fee208b", "AQAAAAIAAYagAAAAEJmYgLPDRQQlY/H+wb/MMRPe+36dkArm2QIy1watsNTKlTg1M2A7pAURdI0u1ejb5w==", "bb614fc5-0777-4501-980c-3a2d1da4ba83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b350e2b-85a6-470f-b4bf-f8fd6756762c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e485e4fe-6e69-45cd-970a-9caea63ab3e6", "AQAAAAIAAYagAAAAEHPa5bZeo62fS86w+3N/Z8CsiJy+qnQEvf7Wd9h3RvM1yrdGQOxNUBuOb+ap9iAz+A==", "8814a028-63d1-4510-91ce-9fdbbf630f20" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dbd348c-bf90-47f8-8604-1e35728154d5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76adecb1-2ca5-4f48-aeed-6ede5681e587", "AQAAAAIAAYagAAAAEIlvuh4rcIj/uWjKwKfkWOSqUHIi76d0ZuZ+VymBofNb+QRSOxf9NAWmau6nUEACnw==", "617fcb53-5a9b-4ae6-b623-cf994da691aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41fc1316-906d-4566-903f-a11e66b4e372",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a1ba3db-060e-4512-aa06-c166608e8a1d", "AQAAAAIAAYagAAAAEAETrzD7+qLPR2Yd1A8fSuaTXD8iISrg/AGdiNZWXDLLJZcjhM2wBjyAidkY8A1eSQ==", "681739ea-8413-43ca-bc16-9f4902294e89" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4324ed86-46ec-42f9-9c73-a345ae59ddf6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1df6e02e-9f77-4640-8aa5-bb95a73d7a92", "AQAAAAIAAYagAAAAEI65gS4Ax+76tcos08F+UuN53ehwyH5Znw0xGOJDuZBSIA0yyNHH0EjrcCHbOdVtsg==", "d01267c0-7137-46c3-b1fa-5044a1757016" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a7843c3-2c0b-4014-a240-fbd929b540e7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "64c4d056-148f-470f-ac38-781c15c3508d", "AQAAAAIAAYagAAAAEKTdVGyfgYgpDmgqK+YBbu0bnNAP/OuKWEEZGZMVcN6V9A5q8YyPFkOtuNTDdZVYGA==", "9d9a5087-6fc4-4ae5-8190-e201f42b37d0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ae7cec5-933a-4c94-9579-13e6b8c1249c",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21ab7dcc-f8c5-4d83-a8e2-ea9c799f076c", "AQAAAAIAAYagAAAAEPK8vXX/qWWCdFTY3SOxmedFvGA44Xcsqnb51aS0+Cx1u6fMeUqV4eONoFKD+5C+uw==", "984b7e4b-3421-4a1b-8e17-28a75eb67775" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ba710fa-360d-410d-a40b-13081c0a400e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de56846d-1579-451e-946f-a810ad34d8f5", "AQAAAAIAAYagAAAAEENjiw77YahkHrffKnfsmhdhnDbOw6Dk4oHAYzC8RVWq6tKTikzW9kGfaU76vZ5adw==", "f0a2e435-ad46-4d6a-a486-10fc98de89b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4df29187-fa62-46e3-a55a-1c7f35c550c2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "20a87d1a-3619-4a59-920f-670dd16f714a", "AQAAAAIAAYagAAAAEP+T+CwMQ7sUBt0x0hmkii2STpk2EejOx6aaBIHD0+6FcDMoBlE78s7MpM5YZKjwwg==", "5687a627-1087-4e98-a10a-4f0a8977fac3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "535eca35-db7e-4aed-b238-32e7e50a0ee2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abc6c69b-4e41-4e03-bfec-ff84a9a341ac", "AQAAAAIAAYagAAAAEAQBa9JyFikym+Yc1ujEvbeqZg6BSmSeoCqNI1KSq9HjYrPnF4xQ4AbfHSE7V8fXng==", "da9c6608-58db-4d19-9ea3-4cd82222584b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53bc79ab-fb93-4514-9712-6ab1398a9c0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "eb364086-5670-4716-8ceb-2570cb24f5e0", "AQAAAAIAAYagAAAAEFodsEGoNIeY+NZS+4xMa9diJJLBoRp6cKASjhvS+oZyMdjrYgYAZQ+eB2fG855XcA==", "d2c1d166-e076-4bfc-9dcc-1f36c261032d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53dd648b-1ed1-4f6e-b90a-457d1a1a67f5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb7ed193-5443-4c5f-b1bb-d1514d3df6da", "AQAAAAIAAYagAAAAEEM5fvL/KiGSNBMBFe6ZR43pucoxswaTOuoxeKtamGMhKfcmN8tGTpiV6w4EDeKNvA==", "a8a2f638-134f-4cd0-a246-c126ac9013c5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55adccdf-c235-454e-a7e7-5a9b27423f99",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a02d9c95-203c-4163-860c-a9211edfeac7", "AQAAAAIAAYagAAAAEKp/dx/nWYx//M2+IqZCVXlE9GNm8hY9RCjOAGzajf6KB4VMaKH8p+/7RUsZR1UKyg==", "ce9353b6-b846-45f2-b870-14e0ab8ff32c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c3de5e5-2a6f-4250-b3d9-485a9f54bfbb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aac1df59-f5fd-47a6-a76c-a8fb1c13235e", "AQAAAAIAAYagAAAAEATNp6ZyDjBAExJf9r90vuW/4XvE3OgZR8Shw5s1bjNm/ccb0gn+PJvazZzYLGP8TA==", "41823613-5320-41f0-b11c-eb9ccfc81727" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e809e0c-d7db-4115-8351-64f04a8c7ecc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "863d819f-7ded-4aab-8c5c-49a715f71fea", "AQAAAAIAAYagAAAAENknq507ukv4JJ7NaaF6vnIGlkvVWfc3Yp+pPhSTZbISZbp2NEBZSaSiGyZOcQYG7Q==", "31de608d-37f2-4861-ad48-bc809b809b0a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6181a79d-254d-4340-9dfa-1690373e526b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af1322e6-25e7-4f6c-a89a-c714e86e479c", "AQAAAAIAAYagAAAAEFAqVed3uqDEizpzFnWuqe6QjqVgop+LRM8Uu89R84vUjNfzs77+SumAcLbBxezFLA==", "a5da07c7-628b-40c8-8980-f0f0ccdf5de1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "631c00da-96c9-46ce-83b4-0082437e4d95",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14b93945-72f4-41bb-b0bc-02a1236c0bde", "AQAAAAIAAYagAAAAEKsbC/ZUzQIbAaHVApbUzS03pnSBFwQ3JslWNnVaVf9vFArxzO2ue1EQuIIzTtugmA==", "64d75106-9386-44f5-8d78-c109dee20a86" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "662a8514-e266-4c0f-907e-cdc9832a7880",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a55d2af-0973-48d2-bf85-8f6e3ec4f96d", "AQAAAAIAAYagAAAAEBkIbhV6U3hk+08pM71HdgsC+u2hIZZJK75P/ZwW6GF/ZMB7idOyNwLUYe5p59OvSQ==", "a54a5dee-1fcb-4726-a1be-18923843f684" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "679e8b7a-08b2-4ad7-8221-24db718fc6c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c68c84e9-7c37-44c5-9b5f-018a119ae85a", "AQAAAAIAAYagAAAAEPO+2w28wfyyIq37I0nsf66xXBAuWeLySZtnGnylGCN+Yj4ntBRpoOXRCNUK3ieyfQ==", "26ec2666-0762-4294-8eef-304f18e168e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f77d308-4454-4be0-93fa-8e33b9c0a552",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7fdfc48-e378-4b4e-9ee6-2290ff1e50e4", "AQAAAAIAAYagAAAAEGL/BfsqsPXzWdoY4JltS2dSfyXpt2u390XeldVLAFAasYauM0G9vKf+JvKlevzb2g==", "d2a4a7a5-a17e-41fa-a418-b40a8835d0a0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7039693b-862b-4bce-84d4-62359729742a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "badbc91c-ed2a-4756-a8ba-cc5d459e3371", "AQAAAAIAAYagAAAAENHYH7dAhMKtdG/BpyHIM7DBIAqqI1RbfsQZY/BjEPlHHZZ/E3p6xnaNWr7tWrPbYw==", "73b39141-0b9c-4343-81f8-894a5cd62741" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7225b7e2-63bb-43d9-90bb-c7fd33435af9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bcb80914-72a6-45bd-9757-db8f473f2f21", "AQAAAAIAAYagAAAAENmmT28wVhkmOyqrQ0mOmz8JlT+hNL6GIED3zalTOvL+4E3IskHukGWU4B4KhXkVVA==", "f2a7361c-70b7-4be1-9fe6-729f07f2c6af" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7613aed1-25fa-4dd3-877b-0073d0c0f570",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06d1fb30-41ab-43d1-90a2-f6239cf9dbdb", "AQAAAAIAAYagAAAAEEcOmDNgrVoFowlpjxa5eEC5TUZzltB7hbobNHd3LYf3NkcyXsiEQjq76STUDPsyoQ==", "920c25b1-b9eb-410f-8bd9-5ecbcb5edf19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "777b3eae-82a6-4c97-9e73-97e3fd40fd89",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83592889-0f42-440e-b222-a54b7763af40", "AQAAAAIAAYagAAAAEBguD/cfVTyXgkqQN6RLTI3s6mhJtfIci0aQJjd9McXRu3P/08NnEQIa6AWFXYtofw==", "de03faf0-6099-484e-857d-3fd3e0b612bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aa83480-9577-4289-aa8b-93e1ee163261",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6d24fb4-ce98-4a86-9340-af97e470a592", "AQAAAAIAAYagAAAAEAZ+JOWzW/Dfh8h6buJ4ZqWTiMPKJjwJzRejs+vJ1/J40aSeV/9zEo347DIpExRMHQ==", "eab621e5-30a1-48b3-abc5-d6fd6871eaa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bfefab8-626a-4cb6-95fe-87f796d51c06",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "439008ba-6b66-4db0-b52d-bbe29e6e1333", "AQAAAAIAAYagAAAAEBvEN5/2QW5RgXQU4qQdoKwKobGPHGUlaTTZbucbEuHt/wveimVAcagTTEc2zKm2lw==", "f7eb921a-8d7f-4a56-bb48-0d2a35853ec7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dabd73b-e1a6-48c3-8aa6-fb90f973d0be",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5fa73ff-e741-4fa6-9564-4084d7090df3", "AQAAAAIAAYagAAAAEDdNpH8z0niDrSfeWsANr1wTtddQcEs+oVP/RcyWndaTjWrj7NV6QBkuXX2rh3llXQ==", "9160dbdf-1439-41a5-80b1-ba9c0415a8b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82712fd4-3d4c-4569-bbb7-a29e65de36ec",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7c474d0-140f-49c2-bde3-9f47eae80600", "AQAAAAIAAYagAAAAEK3AOq9yQUWHXOL9+56jPvtZ2WWwhnGseEmVOgLGnSZYdX9JNoFPNWR+/Rud0w5iBQ==", "5f35716d-c407-4b7c-b77e-106daadee5b1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86a336f6-2c13-472d-8b16-fc13f23c1b29",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c52e45cc-e55d-42c9-8c8e-61e3a55ea94c", "AQAAAAIAAYagAAAAEECdZiYu3M4OPhF5Lzze/46v2V+entT4u0A/M9+YRiQ3ffxeJROr8kO0zA1pZNmHUw==", "bfcb8d54-5047-4c9b-a79f-1d715b8b65cf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "896cbfed-e191-4714-b2f9-92ffa4bc7a36",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1de81827-b12c-4e83-b702-560941a059f9", "AQAAAAIAAYagAAAAEHYr+iwmLF3ib4qGwmEr2b7ISUxKNbVVoc1x5CNT4mRzh2ABLfyZ63c6gu6JkSj4lQ==", "ee584993-7d8c-49f5-96ff-05281df5bf9c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a1e1c7f-aa3f-4342-b384-e4b483eee994",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36657e98-ca79-4903-9280-15e278a23ffa", "AQAAAAIAAYagAAAAEFf9o9bI/koAMZJHnCjN5pL0DAOgflrLfFPF5SQRIq8tKbJGpNoHXPZ/dqmA48mrzA==", "62835fac-2c75-4672-a7f0-58122536f8b5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95c789dd-3122-4427-9eb6-b8cbc4d21510",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b45efea3-f9ee-4b88-abfd-edcdaf608e38", "AQAAAAIAAYagAAAAECVWffjkc7Nr+2My2mnGi+IndEXfDnqTIjS2OffLpze/nlcCVFJeIg+eywc9HYUXVA==", "6c92758a-0b97-4f72-81df-6b22013021ef" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9730cf9e-1c2f-40f1-8b16-ee576bcb1214",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14e703ab-1d9f-4b3b-aa9b-59e588f2779a", "AQAAAAIAAYagAAAAEKm/8R2/I/hgBqEte+lD8zUmIj7zMEHoWMZE66KcgB3Lls+qXSGDamfL7EE4bn7nyg==", "6fc0080d-50de-4ad3-bdad-544a74f9e5c1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99125d4c-801c-4aa8-acfc-8a7452efe1ff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6b79ece-c876-4ad5-b853-5385088f553d", "AQAAAAIAAYagAAAAEBDoqVFi7/799l5+IaVf7kXb3yNTk0J6q2VU/89Ji6vlgGrYrmkeXkWu1EZH4MYSTQ==", "9362f3dd-92ee-46b1-8ef8-a0e98f162dc0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ae7c82f-c4aa-4af7-806e-ddd244fa8a34",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8f74c717-ef2b-464f-ab61-8c2d5dca067c", "AQAAAAIAAYagAAAAEOJse02t1xkX5X6GOXkKRygjNSwVzDGA6VQ34Mithtabuyci+h/r1PTSJZTXCbe/oA==", "670befce-60bf-4e21-b6d1-a60ad2c074ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e9f948d-8d01-44ed-82a8-9445131b70ca",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8ebb84e-8a91-4c4b-a62e-9ebeb74d5eb4", "AQAAAAIAAYagAAAAEEu7d6yK30nz/IOLX67cUB674sgzvVBdpOp06FMc7soV9wdJp8oyb4foGcrV6a9LQA==", "ccca0753-af10-4bd1-90ff-3b439077caf9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18db6dd-6625-4193-987b-5ab70c5e6a9a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "55e487c1-152d-473f-8af9-05161747d82b", "AQAAAAIAAYagAAAAEKRy2x70qNpZUAsj28eTD05adWTkelWL0RaflL0Vsn0F39FRYOb/spI6rYre5jnM8Q==", "2641de26-d710-4365-86a3-0d8640510921" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2fedcc6-d568-44d4-a976-7e491a93a997",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5fb4bbae-957d-41b2-8636-3e7304ce74c4", "AQAAAAIAAYagAAAAEP8T2137N54AfUGo1PoGLeEN9l71otdMFooW8Zs5l/dk5QRSHZSjrx+YB9iKXnCUfw==", "bf014175-b147-44ae-816d-4ff4aee3fa32" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a31cc91e-4cc0-41ad-935d-d2831c41e1fa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43330a1f-70bd-47df-9941-a28d21c491f2", "AQAAAAIAAYagAAAAELzsKbsFmA1GIdVtNISPWP4QuNG7E+U+YBl379u4lDnthK0eRR/1r1PqtKhapvO/rA==", "0cfdb397-fd03-4077-a9d2-e74aeace69f4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8c78ec5-e91a-48f8-916d-56ff7d71f0f9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76c74063-8a8a-4024-904f-560843195282", "AQAAAAIAAYagAAAAECFPCHz0saWS0nU7Xsop1KgbP791+Z9dUBcE5rMflEO/IZJK3npL7VHpfqCidrCd7g==", "b7c5eb86-055f-45ed-9515-835ce5f317a7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa5c56c8-6237-4c86-9ddb-ae133fe2e4e0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4c536f4-7b5d-4465-bb86-def3014e04fb", "AQAAAAIAAYagAAAAEOKTqWjJxX6rrLqwBlg+3NBMqRGPR94sVkKRUe++6ynOTQFkJOGXsPcXEm0fuoHsDg==", "8c812cb9-0fbe-45c9-8994-ed081937067e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac898650-93bb-4702-a4c5-417703cd6c0d",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9d6656d2-b070-4b59-9219-f81353cb5f74", "AQAAAAIAAYagAAAAEFmkiuLmDMGYl3fbVyYFV7GCX7BTUbUwhBSi7YG+mA5WaqFJ6N9Gx4d5CkIJads9Dg==", "d44dc2fc-a811-4939-b148-f92d6ea455c6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b02da1c1-91bb-4195-8a16-d85d35b6811f",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca07553b-ec28-4dfa-8789-5c402dbd9f03", "AQAAAAIAAYagAAAAELzFp2356xEkhOpic5Cj8tMlcS3D+2R2HHlGprtv8WsfUOsmUmVKkcIdEf+dby+ZrA==", "d26f79ef-9332-428d-bd19-934d2368d836" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c5c8e-0409-4c55-aaf8-9cde500f0c00",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f706c40b-c54e-496e-a714-5fe6641d8243", "AQAAAAIAAYagAAAAEA/ieSVIyTT9LVAMzxJjwl6ki8NiR4hbFAT00B5L9EXD1DSTp4cAz4kmiuwq9Qd7sg==", "bf253268-46f9-46be-88ec-9fd877b8cce4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b14256b2-a21e-4c04-a82f-bae02c4d2337",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fbccbe25-e053-494f-8792-f6b84a38aa17", "AQAAAAIAAYagAAAAEFCK8tRN6B6Ll6QW4RfEpjaltNrve1YK+aEs3HBnTUnDbQ5MjFCjD1J0AIvVWrgA7A==", "691627a4-9a14-44af-a9a9-d4e148053e5e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2255e20-6cc8-45a0-ac92-065f5c545e2b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f05f20e7-0b1a-4a30-a7ad-77ecf7f4d978", "AQAAAAIAAYagAAAAEOsWig5x226WLRAJ35cYgnk/Zld9kOrSVjulIkPElqriQ4rYOEA1yueEcVsBIs0wvw==", "4eb45ced-f09d-4389-9936-0b678618e8dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b63d22eb-7cc0-4617-8add-c39d70d477c9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9a76a81d-7fae-4494-9536-8673708e6c2f", "AQAAAAIAAYagAAAAECFCUjkVGLNHxM72oiMLGS+TNhNkRJzxoKkBeL4+nVTzeznW0JpqIvjG526dz6M5rw==", "bd618b22-b238-4068-9bc2-b407aecd59e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f1694-9a78-4228-9753-4a02452f50f3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a18328b5-799d-49e3-a483-608637e7ad1f", "AQAAAAIAAYagAAAAEJNDfxEcQ7IW/s69j+mlAfRVdhrCFHzRJToepBDrnjqJ5jqpwmyccxOid4SjRDFoZg==", "55c4aebb-a15f-4ea0-818f-80ae36af57d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7499973-bc96-4d68-8908-01eb38d8b2a4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78032c46-d606-4623-aa6d-159c78d01e49", "AQAAAAIAAYagAAAAELgi07uuRAqJiDtEro2ryt/fxlQ8W2s7AKld0M8lmQOZkSdyDHDMrR+3SZAZV8Z42A==", "a676c3de-1639-4a37-83e3-23e076b822d6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b78623ab-38a0-49be-be8d-d2fc51741cde",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aed7dd57-ad93-4810-b325-3737f1247fc7", "AQAAAAIAAYagAAAAEEgapF+pJL7tu/FKROSvF5Ona1nvu4GdZ1bRZ9EOPbRu6JL7GZ7uhNfGwxH2JGCFlA==", "79c7a37d-ba0c-40ca-973d-9f483aafdb27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8c525b4-4405-4a24-a789-854c5e10d044",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9efe1a6-0c46-46b1-942f-7e1f941f1f82", "AQAAAAIAAYagAAAAEIf4bBaCg3VSbglEJvmhoI+HV5KRePRHXr9dJTVxmTc2uypRLol++7CPwnP3ieDBFw==", "ac6f6b4b-ab5a-4e8d-b7ca-3919e7edb0ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd0958a-fac3-4de0-9db6-14e3eea05676",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36761146-d1d1-49ff-a345-a147f04627d3", "AQAAAAIAAYagAAAAEOzQspZEV8mZH1dqzNj5GPSegc/tp+8iNXoo7kUdd6xNYurmyHCYB0CI1eY/Wo5Cwg==", "a67128f8-c376-4c50-8d25-31371e7ba7b8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be233685-9ea1-4452-a0b6-6ccdbabe89bd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dda17195-739e-4531-be09-c2e6cbef43ec", "AQAAAAIAAYagAAAAEFa4330RflYZeVzqO90xa2CdP6q8OTdpyZ+Bq9DsjcVGrJk1IcgC/tpOcjMT9w9tKg==", "80218f58-9c3a-4f5c-9e26-951722032acf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2fa731f-643c-4bfd-8482-6299920a12c5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "42848d25-e74c-473e-8b98-050b1c716977", "AQAAAAIAAYagAAAAEB9v7QFYtjtNyJRUtZ9tRp7VKeoPxzpHPZo40+zC6V1mEfmwoVRWX085D3owKvcbOA==", "82c99d30-fc03-4769-9c3f-3dec05e0d269" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6223c47-7d54-49dd-9387-fc5d276fd705",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "367c2e22-a0b6-488b-a953-cd7f5b384b79", "AQAAAAIAAYagAAAAEODLjku3l/mP3vUvbfQ+VACxf3nLRX6pn15bvtR8iCb45qegcappa96R3L8ihfXrvg==", "f383a582-7746-4b17-b4a0-a4c8d97961ec" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7394daf-c04a-4b2b-8eb1-4d529e9154cb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63aefd47-89e5-4952-9875-014c8349a53d", "AQAAAAIAAYagAAAAEGkpouuqPcMmPUEIX31WcnGSj1sPxED2A62H3Ae20+zipr0tCJ5cgkgHF+foLY5Twg==", "47e38150-028d-4f31-8ab2-b18989802d62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8147e38-d648-443c-86a4-613134b29e50",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e622819f-0e75-4cd7-941b-0378f29f6326", "AQAAAAIAAYagAAAAEOIHEfC9sywI4lZ8eaufDZ5J5bMOrQW+tqCgPxxQd6whj3/sgTpgqQEkMQtxGUsxGA==", "9b1d0aa6-08fc-45d3-8098-b74211578557" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9dd6e91-4d35-41fa-8f26-7e77850b9238",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4d5a5597-b097-4fea-8579-fc016341679f", "AQAAAAIAAYagAAAAEEMz6he4awTt8BrnK+zJGrpDzk3Zcth1g5fWsa6xoEoCwDon6eDnak9QcvkVSy5wGA==", "75761a58-84ad-4b03-a96b-9148c72172be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccff2fdd-8cf4-488d-b71d-87611e378cbc",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48b04900-2f0d-4942-a6de-645da5772454", "AQAAAAIAAYagAAAAEBcGXjV2l2QycYN3vbtBThSatmjv3VimqH9V/BrwgVsB0vAT83awDWNLiAfZxK02zg==", "6d425cf4-47f3-4062-814f-de6ae0ca8c41" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfea451d-086b-457c-810c-9f886104ef22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3be271f2-d57a-4bf9-b59a-f9295f362a52", "AQAAAAIAAYagAAAAEOobfBYtVYjCE8oOI9ZwUTRw+PXYlbWfcXyOK3UcPiDWvF9oSGROMAYdr5Pq+BNmuA==", "c465a6a8-bb36-4983-b456-4b40d7b25bd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d333af68-2dd4-457a-a95f-332b92633488",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987dea8b-0535-4900-8bc6-80324a2e31f0", "AQAAAAIAAYagAAAAEM+1Do2MyfnaiOmaBGXP1Kb/9g2PizhSnTO1JrDNRMjj1qzo0DN98flShOSKenYaKA==", "79ac4994-8c2a-4884-be2a-7f72e5724e21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc58b575-8fdb-4f38-9786-2cff9819e7cd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "19528d8e-4ae9-474c-9bbd-d070bfe74031", "AQAAAAIAAYagAAAAEBi1To/XPBNzOq8/wqAPvSrXPU8N+yvoeGrLpwkvczXut0q4pD2gOz64ZsazxQah2g==", "a7e7878b-4655-4af9-970e-9ac378146e96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dce7e74a-8755-46b7-aae5-07203a97c338",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c25cc900-e065-4ab0-9405-e5e4f9bd9cb3", "AQAAAAIAAYagAAAAEHx4As1vRrNnlbWaEqDUGkmczCg69NArNe76MExxgIzunqpEqFOlkMFIJeZclMaKdg==", "61a9a748-f72f-445e-9562-3553265fe1f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcf7ae35-fa23-4b3e-b87f-c14b8512d7cd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "149e8ff6-48a8-4366-8a64-a79d3faf492a", "AQAAAAIAAYagAAAAEKN0ZMFlqeJoad6k5aK3mICNCjEWP0YX3KM/GOmdqO/vtNV8HbvwaYXtQV8aSQvD1Q==", "2b59090f-4dfd-4cc6-879f-a2fb23995a3c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd1d4e98-5425-4263-a13b-3248c0fe735a",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "33abfd14-e098-4a3c-9461-bb1f94358e40", "AQAAAAIAAYagAAAAEDYQsjJLTzWAnkMzZ8FbqlFrU82bBfaUvR3cOFrGAOoY2cqlCoocZHs5zclK0cRpwQ==", "61ba2857-5787-45ec-bad0-c4a35d1a55ff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e05f6ad4-7303-4e23-8b80-31655916aa24",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1346957c-3fe7-46a5-baa1-fce739367c9e", "AQAAAAIAAYagAAAAEBPw3J8DDbhDHF6lpasnK7wlp/16Hd4EJjSIpeHGgEiKJSFj+R/5+wEv9O74SgMyLg==", "24657a86-dac8-473c-aa9e-2cb73f2160a4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3a6195a-894c-4e33-923a-7a6c5c15dff5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b5606bb-4487-45a4-ba6a-b8997a458f6f", "AQAAAAIAAYagAAAAED5aSi4GUGlFUufCipVDpEdoG8/i9Qd5C9aPbCX8wvUzyNM4uqzAW7cFzWdDpQZOmA==", "83996458-c550-461e-86cd-d65a79bc4606" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7b7408e-4749-44c8-b27d-684141616adb",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b8c59ee-34e3-4922-ae06-ed8e144e2a74", "AQAAAAIAAYagAAAAEMW186L/FtVxAt4qfMhBbarb5FQv0t4dYJnu0qm5gjRckKDoKwoiDWxdSSHcZ7yDUg==", "e7d77ac5-951e-4769-8740-2b8dbd99c0a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea43c83c-ae12-496e-a44f-0fcd70917a07",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c735a3b4-b9f1-4cb6-af58-dd297f6bad9b", "AQAAAAIAAYagAAAAEA/ntrHGf6r+xmknsMlsKQZnO19QNX/vG9skzgZkRteyQC6pettwMxDfAMBOZhsHHw==", "fbc069a8-c0ac-4d58-9eb6-f6539150bf9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb353c76-e454-4e82-9e75-8214a212bbe1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f168a848-52fe-4895-9d0d-80c92f13993b", "AQAAAAIAAYagAAAAENg8FW8euswhl9WbQXAEWFlXifmYgZJ3UzNFKIUlsZpRI8xjUsDB0gaukP/aOjJFMw==", "38476486-c12d-48a8-8f2d-1cf8060a20ab" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed4df161-1fa4-49f6-a1a9-8b3ea1f2dfba",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c409f0ed-786d-4932-ba6c-dfbc0dca8bb0", "AQAAAAIAAYagAAAAEH7flzu57Z3Bw0BzlpGCkKrnERHns9RvkOeR3EmoNtj3IhaH6x9J1mmC5u8UY3sW7Q==", "dad81d48-1511-4471-9744-bc3f1a9e4518" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f11f2379-20f6-4de8-81f6-e2d27ff4e2be",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ca2e00e-5221-44cb-a235-2bb0060bc5a0", "AQAAAAIAAYagAAAAEAgpjMu4EDFVN3wpZIjzQlTiPtDhRbzAzu3lZ/HH3H1cdbO50Jj3aKHh5O5E6dJchg==", "9178e762-03f7-477e-b836-81c90295422e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f29dfb76-a809-42e3-a13a-0be728a84762",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e61bd20c-1884-4e46-b6a6-2b3445fda0f9", "AQAAAAIAAYagAAAAELhOGitk2opYZ5Whewu+3uNHtcs7cjCg2FMFkzAZE08WhW3+ZLIgoDtduZt6moAeSg==", "9e76f296-9128-4652-9f5a-631f9ef75317" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f359ad89-c00c-4ebe-b4bd-7c1a8b0969a3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c5b4ffe8-fa98-4c57-88f1-ebe46e953aa9", "AQAAAAIAAYagAAAAEGTc/mDFYp79VIBqkVya4hTLDl8WIIlkh1ywroBDWDI5qExtdxvxL5Lur2K1Z+aQuQ==", "6102369a-d08f-4caa-b00a-ed4dbb008b62" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8f20479-f22b-490a-9a97-692213146c70",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb4bd4c4-e20a-463a-b165-0a8bbdbea195", "AQAAAAIAAYagAAAAEDnjQEyut77b8+r6s4OzSbkCbrLBriswbh+6GjtmoRYrEJEl0NaRFDR9LICfrGLKig==", "181ecc06-cb50-413b-a919-e8e421ae5432" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f95d97e3-23ec-41cb-ad21-850d3d5ff794",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "04a78728-67c7-4403-902a-add01c1d02c8", "AQAAAAIAAYagAAAAEPqFg8ceXXvk2p8e6p62zI01U1H2MLju62hXjc1QDl8B4biRL5Ejgc5V0Yld3XvFoA==", "60e90337-4a55-444d-b241-53161082aff5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb2607d1-2cd9-419a-93fe-35b618274d4b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8858cc65-5529-4484-af29-d0bc2131fc8a", "AQAAAAIAAYagAAAAEA4EWmMAqveACJ7zgFcmDvNog+DIJ70GkIW5+722Adh6BM73H0aDLPRV3HJOuNPgsg==", "7db8229c-736a-45f1-a0aa-e3caa10cc738" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurityLevel",
                table: "TourGuides",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IDCardPhoto",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0021dedb-763e-4422-b3d9-945930428104",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b168bea7-7bcc-4705-b9a4-fc194aa24c04", "", "AQAAAAIAAYagAAAAEBPWLf+oeLNkpFE0Ac33i4GhY1xLLFNSwre7lcYDW0QQoAgFofVeMjx6WJTmqer1Xw==", "195fa187-b053-467a-b756-c584972b2803" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0106fda0-5757-4caf-9e2c-f582c48ee029",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4812f132-8286-4fe6-b8ac-3c2a59954f7f", "", "AQAAAAIAAYagAAAAEDemX3PoPldFAXr5TIzZKKmt+DxMJ3byGZhwuZg3zSTu4gSZPB9DvS8qMzjTMkimXQ==", "c4218976-08e0-43cc-a272-eafd879beaa6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "017e9b5b-1b27-4dd8-9c52-76bd328a6c83",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f283bbbd-6249-4a8d-abc1-1e855c4137bd", "", "AQAAAAIAAYagAAAAELuW76qC9JCScfLbfpLID6aSbJxhcL5WHq3JNrhCCvCLViul/knDhcNscQWC9GS/Jg==", "0c7e1d3d-0d92-4127-9c26-dde68196f6e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02fd99ed-3b83-4245-8a29-1d5688f97897",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e244870d-d19a-43e5-819d-bdf9da3548e6", "", "AQAAAAIAAYagAAAAEDxQKbXrgOV73o7O84YrVCjNUm8q5ceSdYMWbyFFUw+ViJgMKlh9EwaHpPhJqvvsKQ==", "0aa6b6df-b831-499a-b613-7343846279fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0938efa8-a702-41bd-af20-4e38eedd5125",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f0890d3-ce97-4899-992c-52767613f3df", "", "AQAAAAIAAYagAAAAEMg7Ie6rc/wxWj5qizJDrnt1uIJSP8mpRjO+xcPwQHdc6HXKEAN/wnrr8B727u/LQA==", "1f8157a6-521c-49d7-9d89-9b32d85d4ac4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0c9c7596-4439-4b1a-86fb-1d1507ec6197",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c518e53b-1cfe-43d0-af3a-904727ffad90", "", "AQAAAAIAAYagAAAAEDGVKotI90h5XZL7Kjh8349FcggfAChe8xeJZgo7jQHhFLmElj24QsuNg4dR8+gqzA==", "a79ed579-221a-4f65-a125-130923bb4379" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0f47ed8c-875e-4f78-b746-8094302d5fca",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0535e257-6839-434d-bdd7-55d2a5c64208", "", "AQAAAAIAAYagAAAAECcZaYs/W0vx+J7SfbgQQWba3Q1ts7878UvvSIq3s1JBdZ3dvspcahuaHGwkeKiOVA==", "39314cc1-0582-4c6e-bc75-0bd0f809c16d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "12b54922-5fc0-4668-8610-08d0daea1c23",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf0ac24-9091-45ea-a8dc-86db95f075b9", "", "AQAAAAIAAYagAAAAEG00qAWBIxSYLCU7KAFzF8h4qwcSwiHn8n8p9JClUWMOJo14xmvptppWBMlx5a4hgg==", "3da6b87a-93d1-491f-a604-88521cc58b02" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "13f4d8d9-b5ae-4b79-9178-6aa26d6c5dd5",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b098e961-ec8b-41c3-a811-4987c3bed78b", "", "AQAAAAIAAYagAAAAEPFY4A/3BNXTC+b83GTrNSVqcRQ/qAvs7mC2WyTm4BVB+Vj2v72DcOPQ6NZbJgIZ9g==", "765aa116-4460-4f07-a377-14610fcc5188" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1927b325-2a3b-47d4-b4ef-cb1b9071d3af",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d4c3cfd-a406-418b-9888-a08db19cae1d", "", "AQAAAAIAAYagAAAAEMr9xR5jRUEZF7i4zGFkKinhx3O0plX1r6clDc7fNnWYMWhgpoeEDlC2N+6NVLhuFg==", "39c68ab1-31a9-439d-8126-dbadc3398b55" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a8b75f1-76f7-4227-bd1c-ce54728ec12d",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "871919fa-c8ed-461b-b62b-dc5d25a7bd11", "", "AQAAAAIAAYagAAAAED4NV2VoRk6coB/6daEAv23urnk7m7HbEn7byS+GDltXmQew/P3P68i7qyZc3isdsQ==", "42ad1d61-d5ed-4e5f-98c7-1429f7babd1c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1de1c9e4-0cac-45e4-91d3-42559c3ef16d",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "721cf1f2-3bf6-4945-a9b1-5662466862dd", "", "AQAAAAIAAYagAAAAEG5JSHDo5+gwG/GIl2KZaKK9PMX8TgWStGD2VtWgVtPMilcAsiNW8iR6LkY0lw/O/g==", "d4f63e34-d4a6-462a-989b-bd22b145ebfb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1e754177-f905-4164-965d-570e46d12e8a",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8940ff0d-3375-4230-9cf7-7ded7332083b", "", "AQAAAAIAAYagAAAAEOPtZLmmRYprBviVDII3slZy7ISJ4j+TPV4Qi0vdebnQ1jrdvjneDsNaBogZp7k5fg==", "f5e90090-934f-4c73-a393-8512a220fac8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "210db6ec-1ba5-4148-b9ae-ab2d9c58d37b",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0b538b54-a58f-494e-a2f6-07218fc816e7", "", "AQAAAAIAAYagAAAAEHleiUp2JY6KA5320kC3C21mIeZ8Vuetet92vRxH8IxwKYhZkWZrm1usHt6x9zEh1w==", "2981b84f-498c-493d-bff7-d6002284171c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "233204b6-ed56-42ce-851f-3a514b7b0a41",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b39eddd-ef2c-46da-aa81-35c213234766", "", "AQAAAAIAAYagAAAAEIrqu1UF4Vc9OpRGKeyCTzrO3Y5Kt8jfceGAarNV0G/N5avLMYsMY7cbaO/Zm3VKCQ==", "1b04692b-b8f0-4c43-9df0-05f2b0e8d43d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "236c86d6-0ad1-4e1e-9461-1c19ddac9d1c",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ce10099-5622-4633-9ab7-a6faa82e77e8", "", "AQAAAAIAAYagAAAAEJoLEx8OBNwyDwgjhzOURPfqyImzrIhnGeUQ/2Wxe+bOnQRXMpnwCK927GO65RlJMg==", "88b5c0c0-925e-48e3-9951-5cc7979b4f83" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "24ecccc3-5251-4072-bf3c-2c704a334ebe",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2c12a718-b12d-45a5-9f90-170a8357a3de", "", "AQAAAAIAAYagAAAAEBz48mE5zrZMe2VXYiUwvksmxSPTmoFv9XZ7cfdIRaf833Mlp4lEUIu2fj4c+8QyEA==", "57454b5d-53ea-43e5-bea0-7a044981494f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26e3041d-41c5-443d-a863-0e41ea866599",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02798416-a914-4a01-bb73-b6644968ac90", "", "AQAAAAIAAYagAAAAEFPPMwYH5tAO1AWz05inHT7wH4zLr6lHYJ0GJXmHMEFXrhJDxncIFa/WWOabaacwLw==", "ae246f69-c9cc-423d-8b1b-b179c451b331" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "26ebb4da-2ee5-465c-8d5f-16658eda4c2c",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26ddcded-9206-4af3-a2a3-e15457494438", "", "AQAAAAIAAYagAAAAEDFqhfmWThnwGW1cKMFTNiIyGBG+DWKb4jJjxE4hL10QDK+PE+FOrS9y+RcmI48CEQ==", "9c98affe-3068-4d72-9c13-6a85e30b76be" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "29206f1f-b8c7-4745-8e70-41c5c0ff9c12",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5696f978-d8fb-4ee7-a6e7-7198322e0332", "", "AQAAAAIAAYagAAAAEMTjNSOelGQUECtskzyLqrJp0anORA9DpTwrzlCRkE5Wnu+vARq0RQ/Vz/YGbguUfw==", "6ef593c4-77ea-4ae2-9de5-75dcf82dd418" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2a2906f2-c035-416a-88a5-00426bac05af",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cc95903-1f4b-415d-8edc-e85ba1780629", "", "AQAAAAIAAYagAAAAENm2knb0Z7sTC9B3EKT5DoPZwMc5RrxlfTgJDs+DVb1QM3qmnS/RuVHuv0V9VyIRHw==", "3dafedea-f30a-4f0a-9dc3-f6ceb297a756" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "33a9a6ec-70c3-4805-80c9-500160908954",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f081f002-5558-4c5a-8d59-eedd674adde0", "", "AQAAAAIAAYagAAAAEKd8c3Qo6Uu/PYngFRwXtW8VlqURXdUr08y4EZ5TveuUkO5J76IHnMStS3zWJPTCBA==", "4253c2ec-8dc2-446f-b5cd-25c8477fb2d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "350441e3-9e3a-42e6-bc48-c850fffcf57c",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc20024e-c301-46e8-8408-3ade7e1affc9", "", "AQAAAAIAAYagAAAAEIodH48g3bHCzKfri4LMijSuOBDviyzI0Xh7IRwaE8YPB9O4xRvUaB2TE5Y3Ovp2Gw==", "a9f4aa7f-3693-487e-977e-431803635a67" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3650ad9b-2414-4ca1-aa61-86fcb032fc52",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "31f064d7-f8a9-4bf4-a9e3-96a68d5e1926", "", "AQAAAAIAAYagAAAAELML7cPCAGHZMrKQztG2Iq7QTaPgXECqztg445PIWiXvOMzJWHQqrdj19k3bNmttag==", "a9fa1c22-c7ed-4b03-85c4-5c9e7f417eeb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3b350e2b-85a6-470f-b4bf-f8fd6756762c",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d14e3f8c-ba02-4cac-a391-697dbbc1a99f", "", "AQAAAAIAAYagAAAAEMwFyu2mL8wXVxfdxTve7cS0UKYm728iiyErLgO1mCMX5jcCX16H0/rFh/wbdoULAQ==", "875e13ea-a4d7-4062-851e-6b4096759705" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3dbd348c-bf90-47f8-8604-1e35728154d5",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "667ba4cc-1c08-41f8-9bd4-54147384df38", "", "AQAAAAIAAYagAAAAEA6mbjTb+0QcKQdZkwQI7LxFe9zbAcG/ytAoRKWJPCjXUy+eEFH7RWgEKd4qtQrIiw==", "dd0f93cf-060d-473a-80d1-ef6c3632ad97" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41fc1316-906d-4566-903f-a11e66b4e372",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6efaa52f-f8ac-4c55-a185-8ec5ec58793f", "", "AQAAAAIAAYagAAAAEPjHlKU0oK+TktLO23BSQnJ8nHsOg5wZWfd+8Gdw9gC6gxssWhNV0uyujj9Pb+LyBA==", "82e99032-8b34-4c00-b572-e4b1867ead7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4324ed86-46ec-42f9-9c73-a345ae59ddf6",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8aeafb5b-32a0-4bf4-8c48-0def7a3b7862", "", "AQAAAAIAAYagAAAAEJYd8ev11J7e27VY+OQmNvCdSl9hRLudzRQY7B42lbTyr6YjHG9sMp9yRH1YajIl7Q==", "8de341a6-7b51-4262-b1ac-f525279037b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4a7843c3-2c0b-4014-a240-fbd929b540e7",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7fcc400b-28ea-47d6-9cd7-e01173cee00d", "", "AQAAAAIAAYagAAAAEAyd0oXo4fX12+4mvWRpk/YpqVWX/URUDfqiWA2MILwuYjD3fkRo50WQw1u9sOIYoQ==", "392d340d-0225-428d-93f8-1a66f08031cd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ae7cec5-933a-4c94-9579-13e6b8c1249c",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "494e1f25-680c-4ef6-b5c0-c157c9eab2d6", "", "AQAAAAIAAYagAAAAEKkPtbWvqED1xcf5QZ2cxM9vwXKSRj8h9hJDEuk5OPTRF9CI8imx8zYOJZ30QajedA==", "44e0a848-567d-40a4-b48e-3a1765841314" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ba710fa-360d-410d-a40b-13081c0a400e",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87e378d1-d2b3-4eb4-b23f-f44d0bf04a84", "", "AQAAAAIAAYagAAAAEGlRJxn166ue69KIb/FY61e5d1RK6GZF71UDZkA/H6IFLFsTU38FGOGqasuS8ih+dw==", "d306613e-bf78-4ad0-88e6-bd5d8fc22b98" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4df29187-fa62-46e3-a55a-1c7f35c550c2",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73b1ab7e-dac4-4914-8354-eab09abb7be5", "", "AQAAAAIAAYagAAAAEAmKV5MzUWIkuC+qXkb8pGQsfBPz84UQnuSHkS0xMh21DAOd2PTkmbc59oLq4v9wrQ==", "205b1079-6c8a-4ea8-b7e6-52015c52b573" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "535eca35-db7e-4aed-b238-32e7e50a0ee2",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "68f59c5c-26e7-4341-9298-d2d8e7e2ffd4", "", "AQAAAAIAAYagAAAAEOiI3q25Jt0hu2AaAaa1zkedqLkEF+pJ0mqUr4QUO3p4OfUGHEcwoi70p1FODftxcQ==", "be7c3300-5aac-412a-a55a-7ef074460a59" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53bc79ab-fb93-4514-9712-6ab1398a9c0d",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9b4582ae-3db9-4346-9643-e6ddbd8886f2", "", "AQAAAAIAAYagAAAAELaNVxWXX91PfxaEewJiFMDT3m3PbMRxjl3+GJdZ28ZXs2DgRzcSrIyoNVuzJD/g2Q==", "80acca51-7f37-4263-a670-8ad1d0215a13" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "53dd648b-1ed1-4f6e-b90a-457d1a1a67f5",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "45e193c3-1f08-4e24-832f-65adddd49122", "", "AQAAAAIAAYagAAAAEKiW11p0cswEyMbppfptt5ECjST4adtwQcUjNLItBxWgaQ18iI5IBIeUZmbNGMLraA==", "ab6ed209-64a5-4a50-b519-7a192ff09126" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "55adccdf-c235-454e-a7e7-5a9b27423f99",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35b46049-9572-457b-9d16-e1d7a9e441de", "", "AQAAAAIAAYagAAAAEB+MhfATl3QtTNYgPeHumE2mcNqBTy3nha3GCyOZ1cGTrIxEbUujwUdMXCLLsg/hAw==", "973563f7-3b0e-4afa-8234-4d9b41880f22" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5c3de5e5-2a6f-4250-b3d9-485a9f54bfbb",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ac146ba5-d7b8-41fa-b1b3-2d1cb9c7bc1f", "", "AQAAAAIAAYagAAAAEDNr/1PII/sUSj8poaTF/g1ijrYr4u8PCdPnA+/a/d+SSESSkPegqaMwV5Um6ftOhg==", "8dd0837d-ea51-4616-9fde-5a4bfc80f149" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e809e0c-d7db-4115-8351-64f04a8c7ecc",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7799296b-42c7-406d-b528-a160fc31a68f", "", "AQAAAAIAAYagAAAAEF6ZseScdNbZxV/9Rp5xLC6sEygWeeJdo2PB1UKC9Gp6727GI7No97a4L0fSJKGgnQ==", "f6c54dd8-86f6-4e19-aebd-b5b56e2c627d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6181a79d-254d-4340-9dfa-1690373e526b",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "400f78ae-450c-400d-9192-d28c10d42b1f", "", "AQAAAAIAAYagAAAAEKpF6NGVpB7W6sGwrb/2tQkWExm2HuM2UgSlHIHbvdA/tkQF9gZ0LKeQgNbNvRp7Lg==", "d17b80d7-938c-434a-97d1-b2e2683fc298" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "631c00da-96c9-46ce-83b4-0082437e4d95",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc0a3be2-306b-4a81-b420-b8faff567590", "", "AQAAAAIAAYagAAAAEDw/6Zeku0OGlLEpGf6zzfTVJvbOu855mGTfXgYaw9hjNKZMoqyMBW6pw0xHQq1UUQ==", "067ca62e-5e22-46f8-8ee3-728f7c860098" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "662a8514-e266-4c0f-907e-cdc9832a7880",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a09de829-d13f-4d38-b586-80b62621116e", "", "AQAAAAIAAYagAAAAEGp5qNMuSsOQ7xva5ti4loZNeRsMleu840EOjVn00Sz8GtoJfbvKfXMp8bshNEYcuA==", "23f8a2f4-5aed-4b5c-b60a-501cbba2c291" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "679e8b7a-08b2-4ad7-8221-24db718fc6c9",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "175c2a0a-962b-434d-b296-cda27608d949", "", "AQAAAAIAAYagAAAAEP3m9Wy+xur1Fl+qfEi8XIhwO9c6N09hg+JnvA1oePyawRDYdX5QFRcq7S3/W7LPhg==", "bd90c5a1-ca00-43c9-a2b3-d0749d799e4c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6f77d308-4454-4be0-93fa-8e33b9c0a552",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "163001ce-6200-49d0-a98f-ab9bcfcd7fbc", "", "AQAAAAIAAYagAAAAEG2QiuZ2Zfxwrn37qtTy1oxCiy3tVXJu7h82y/E/WUC24sWHzA94q5+k1TOZJ2ecxg==", "ed873ac1-a424-41e6-a7a8-994039dccb4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7039693b-862b-4bce-84d4-62359729742a",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fb59180-2820-4c36-b03a-99b95304dd1c", "", "AQAAAAIAAYagAAAAEFkw7wyRqIuQvK3ot7mLnE0wt5Jdr5cUD1Z3j/iBwed7IIUnZVqJUU7Yv+bqHZAZNQ==", "737fe994-cbcd-4875-bfc4-7d5f50b7d4de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7225b7e2-63bb-43d9-90bb-c7fd33435af9",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84f57fb5-2aae-4f04-8096-a0537f9b5925", "", "AQAAAAIAAYagAAAAEGwcXlltiXmT8TzhHFh2X7l8yd+L/Go3GkNS5hhGlk381oGrdImzuzBXE0ZCsldQ2w==", "8741daa8-760c-4ab4-984a-f13c067b158f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7613aed1-25fa-4dd3-877b-0073d0c0f570",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "57c2ce09-b147-48eb-919c-99b89945244c", "", "AQAAAAIAAYagAAAAEOlpKlwmtQgDCx9di7EuiIWDL0spGRwuikErGqmwWO94yqV2C1a1xrpTXnQlj5p50A==", "1aa1baed-89db-4cb9-8b05-35e68d4114cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "777b3eae-82a6-4c97-9e73-97e3fd40fd89",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "332c1f35-f881-42dc-b9cc-094d01a59036", "", "AQAAAAIAAYagAAAAEMhfZfS5A/BE9+pERYqQkZPSBvwoRsyoDbkmNYILkPH5/QwfBJ+btob6cKA8FYNpkw==", "51c98706-9062-4edb-8d8f-40f6d862f35e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aa83480-9577-4289-aa8b-93e1ee163261",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e6f23b57-aa24-4e11-90cd-ca48dca8ea98", "", "AQAAAAIAAYagAAAAENqgrjn5/sizdg7SHeDhVmf/WXvh3YljCPbVlPl/ZW2zEqWbXslms8kT97f3C10Zvw==", "b8c00cbc-f561-4879-bcaf-0779bed7561e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7bfefab8-626a-4cb6-95fe-87f796d51c06",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a72bc5d5-bb26-4a94-8c96-f530fdbce6b4", "", "AQAAAAIAAYagAAAAEKzXA89WwB+o2JcdQvB41jiXdTcOMEV9L9rLPs4sBidVH1hXvn+G8cIgVdnLOtuFKA==", "6987a39b-1062-4dd5-8532-b1b954ecabb0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7dabd73b-e1a6-48c3-8aa6-fb90f973d0be",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4446e454-199c-479c-a946-c1f63638066e", "", "AQAAAAIAAYagAAAAENcExVovkd/9CXmkGC4bR1NSXCr9fEMA6DPaVgtdAA4pz5qB4nHSlmSkMltSrTUDNg==", "bf4fad57-5bc6-483d-a1f8-bd5c8914c869" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "82712fd4-3d4c-4569-bbb7-a29e65de36ec",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8416d75f-cd2c-4b0b-9cd8-a95371a683c4", "", "AQAAAAIAAYagAAAAEEsg8SuVCytopaDebNxoV6Ta24gdO955Ds3ZX7PQoXKhy9JBRRuOd1drsz4e1A57Aw==", "51000a0a-90b5-4759-b740-0063e40a69e2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86a336f6-2c13-472d-8b16-fc13f23c1b29",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3308df66-ee57-402a-b3b4-ac76f5657c39", "", "AQAAAAIAAYagAAAAELEzzMv3MSehJxnbnHQNiQlGbXhitXAZBS8lc98BRW4sroiLq2KZIegHSH1XvhKXJA==", "c2d763f2-5d72-4ccb-91b6-0175e7b2da18" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "896cbfed-e191-4714-b2f9-92ffa4bc7a36",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d8c10ae-12b0-4c0a-952d-b9c5d64f3e70", "", "AQAAAAIAAYagAAAAEJ7i28ZnoLBfOtvjM8uxh/yEwDli3fVoI/lR+FGAtiw6iHufsxvvERNNd2lsbX3XEw==", "aefc2d0c-6a8e-449a-bf29-2ca328cd99e3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a1e1c7f-aa3f-4342-b384-e4b483eee994",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9996021d-c2b8-4bfd-abdd-7595a40d0670", "", "AQAAAAIAAYagAAAAEAATQDXaZ80a2o/VtzCrcit4gG/fZnXwkwRQlnHVR3Z4Z5LDsSMLqRTrqKskXVTXtA==", "7e3c83e4-d21e-4a74-a9e1-d2ea656ded21" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "95c789dd-3122-4427-9eb6-b8cbc4d21510",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cb4394a0-7870-40c2-adcc-bb8ecc03d0a3", "", "AQAAAAIAAYagAAAAECRosGZ816+KOAZCNJb9YsMGIwyeiJHW0oHO3pDfpq36yeaARSd3mazzluOP7pHdeA==", "96ee012b-6034-4a9d-b29d-f9f0d23f8165" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9730cf9e-1c2f-40f1-8b16-ee576bcb1214",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2cfff334-e5cf-4518-9274-c390a1e3b917", "", "AQAAAAIAAYagAAAAEKCpypFRBE7VW9t5xPd3VmpAc5DQoVEe2a7JiF79DOAlqzIaWjAz8DrKCT5yf+JizA==", "cad82b66-d942-4c8f-9d12-9deb85eba2dc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "99125d4c-801c-4aa8-acfc-8a7452efe1ff",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea4e479c-e8a6-4460-b040-bb96cf99a1d6", "", "AQAAAAIAAYagAAAAEPWTVWIdYJdWm8xEktxh0gxKx6aSNDvYfcCILXxy2wo/RlzlV2K1V5Z9wZVWRf/DOw==", "cc7dd839-a8b8-461f-9e67-2534ab6a4b85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ae7c82f-c4aa-4af7-806e-ddd244fa8a34",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4afed93c-cc07-447f-951e-3328842d44ca", "", "AQAAAAIAAYagAAAAEOK2xrVWB47XfG+F9AIa1Zgcc2woqyzzRR4m4Est6+Pln/QzXQwEAq1fEEah8k/nEQ==", "e02ee5da-49d4-4e10-905e-ee55f50d7044" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e9f948d-8d01-44ed-82a8-9445131b70ca",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "002528f2-cfc4-4087-ace5-ce15669ccd93", "", "AQAAAAIAAYagAAAAEGSJBTilcxHkVl8+E9qXj96Fd5rvMYfKBHfsyoJyQIp3bqkaOkMku4GhlhJof/IbyA==", "7f1f8a40-7529-4a3c-ac20-3ef20ba33a7d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18db6dd-6625-4193-987b-5ab70c5e6a9a",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d7945853-2ee5-4835-9973-27d287e52d26", "", "AQAAAAIAAYagAAAAEBZv3Bpic5PvRmLfqIEmMh07Yu6ZYa0ElPa0TIqqcpcq9dFNRyqPTPSb2g8+rNjhFw==", "e9d49fb3-cd55-41e6-82ed-701ad4fe47e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a2fedcc6-d568-44d4-a976-7e491a93a997",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80e19940-7fa6-4e6a-9f16-9a90d871e0d8", "", "AQAAAAIAAYagAAAAENpy+ISJat5pJcYk589wzXa+CJZ3uAAPFhA4/lDujvU7uFtA/GRZ8L/NGPpzpwNV5w==", "af152382-b89b-4e9e-897f-109367ca0968" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a31cc91e-4cc0-41ad-935d-d2831c41e1fa",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b211a26c-81c1-4c05-acc0-862ce0faaab8", "", "AQAAAAIAAYagAAAAEFE2O5x7F2SMqet8HnsPZSg4fiKfy4RrQBncEmzApz3zOihbTl4DgAu7fJKfnHcgLg==", "f8d36e86-a907-4935-b519-3f3d52b9d783" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8c78ec5-e91a-48f8-916d-56ff7d71f0f9",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8939acd-0740-49c9-b0f1-6c99a1fd00c9", "", "AQAAAAIAAYagAAAAEM20j2x/oL8CrbKb5xck7kz97yrutqAnMHETMlnh1+PzvdVB9xvH8SE+chYvyMD3kQ==", "c5de7e88-d9d3-4106-a90b-5528124f0d53" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aa5c56c8-6237-4c86-9ddb-ae133fe2e4e0",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "25579d31-79e4-4a1d-bf85-fe15fe6d5346", "", "AQAAAAIAAYagAAAAEHyniwC+Ws4DswTtyMS87NuPhkJ000pds7lh7SZfUr1O/Cz8lsbSzjcjYP+E7X7Lxw==", "57fe8d0a-2dd6-4d76-ad57-cb63faa11ee6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac898650-93bb-4702-a4c5-417703cd6c0d",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09cf76aa-18bf-4c3c-a34f-e5126f96084c", "", "AQAAAAIAAYagAAAAEHxdy5OPRd8vzLSGR/TWUXu21YFGvjF4fdi241nWqePtHohax3b4t6Z52MUU5K3S7Q==", "d0bba450-b754-49f4-9c59-7a84ffde40f7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b02da1c1-91bb-4195-8a16-d85d35b6811f",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "073cf1a9-a887-4e76-ae4b-8a0f303f612c", "", "AQAAAAIAAYagAAAAEAIsPY7uIht5pfD85ot9y+GKKPSLo+SkQ9s8cm2GhXMNrzfWpfcSxkdazyHgfOCu2Q==", "cfb8e93b-1675-4a0e-a6ac-7f9ba4ce27ad" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b04c5c8e-0409-4c55-aaf8-9cde500f0c00",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "df0fa549-4e31-46cf-9c8d-da0c3b9fa6b1", "", "AQAAAAIAAYagAAAAEPOHJubAEHJwOOhM6xxed6HaBQs+3efVLbpyIma4MMhOrgiIaOqGLRV2fwkFKcdwCw==", "344d1c70-36da-429d-a90e-214b4e8d650e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b14256b2-a21e-4c04-a82f-bae02c4d2337",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "62f0ea4b-a1ec-417a-aa0b-c407ed4a5a69", "", "AQAAAAIAAYagAAAAEBb7lzz/4bgDRkIXYJqCQ3UbjQu2HWYwTPs8CIKK8csfpc8BoQlllEIyBs5UnBY9jA==", "34d1a302-76c6-454d-b3b9-19963ee45dce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b2255e20-6cc8-45a0-ac92-065f5c545e2b",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d8d6ba8-c353-4027-aec8-5b8521cdce9d", "", "AQAAAAIAAYagAAAAEPVxqwSyvn2FuBJ+CntuFGmZEodg5IkxmoIu3ghmH79uhLpWo+uANxL0SVGK4oet0w==", "f0dc760c-6bc6-4699-ac2d-f14b9bb71d48" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b63d22eb-7cc0-4617-8add-c39d70d477c9",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "41bb0869-5b90-42a2-9f7a-6baed5e0a126", "", "AQAAAAIAAYagAAAAEEZ0opjeW/+VLhJOGIt0/hIUCb241NQClwMwH/AYgIgk3c7CmUGf3WOMNliFEd9LJw==", "89df0e3c-10a0-451c-966a-beea2213a5cb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b68f1694-9a78-4228-9753-4a02452f50f3",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b79fc41c-3439-4d90-b436-6c6e0afab5e4", "", "AQAAAAIAAYagAAAAEDHI1QUjrIUg1B0nrIuyNWHx3jsuo5Ag5+g9jbqPmgplCPdxlYYcySaFoYa1+AAeXw==", "57a732b4-d421-4819-9751-16b0da783734" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b7499973-bc96-4d68-8908-01eb38d8b2a4",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52d2bef0-8850-4c05-a0a3-ad997254d4bc", "", "AQAAAAIAAYagAAAAEM+xHlOQqenB7/oz1RpFnkEsg7lzMlhvOUndjzDh8lveq42TPmyORJ4X2/dTwTMpPw==", "b0a4d85b-6ab8-4167-9a7e-14fa17c50a96" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b78623ab-38a0-49be-be8d-d2fc51741cde",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "65fd8985-a65d-4922-bc61-db20ce48c616", "", "AQAAAAIAAYagAAAAEEztNakSTBJTNDIFK/L4bIZ8nph1s5TNSfBi9YT0ga0Kbf4dUpeec4Bo+DHlk9S4Xg==", "5e2a7eaa-deb3-413e-9463-10c9c85ed6c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b8c525b4-4405-4a24-a789-854c5e10d044",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e34e8560-af0a-4354-8573-95c806f471cd", "", "AQAAAAIAAYagAAAAELzfQnqwcSxQezkbMTJKRFQJe8zebG/2ykk0Guszo8gzVD3BlWNqiDkbftjQk6oWYw==", "a24b51f1-1efc-41da-97a3-9f0eac2e2982" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bbd0958a-fac3-4de0-9db6-14e3eea05676",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1ea66042-bb0b-4b84-9fe0-41a0fdf5de28", "", "AQAAAAIAAYagAAAAEMXYH7nzfPjbwa+69xzus8PkCI5eJk9uIS4Z4mcV3CWtLM+8BeDdJUyG8WOtavmq4g==", "3be31d6f-d963-43a1-828f-11d9cdfd2b42" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "be233685-9ea1-4452-a0b6-6ccdbabe89bd",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "202c8c10-b1cb-427a-b237-aad4141735d6", "", "AQAAAAIAAYagAAAAEEhBWGt6SIKGs99HuMgqQEzLzm/QvdqQcWrxqufv5Gagyj5sROLF8xAA4zeBgrlgQA==", "af1139d8-87f2-44a4-aac5-539d07c06b9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c2fa731f-643c-4bfd-8482-6299920a12c5",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c069559-f189-4ebf-a636-5ecb2d420df1", "", "AQAAAAIAAYagAAAAECd00JppGK/yXg++Gs2aUB2HKEZ3wWEzOnhnmAiUCAiY5kuLBH2y2NEclxnPyI9EAQ==", "41af3e30-bf5a-41b3-807a-8899609ba8aa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c6223c47-7d54-49dd-9387-fc5d276fd705",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c7b3f40-db23-48c6-8970-3c63564d9211", "", "AQAAAAIAAYagAAAAENIVRfW5WCEAyc+BpUx//QFU0t61nqXkfdhLTU2/Qchf50f3eXW3GhXUowofbAq11Q==", "2060481e-11a0-439a-907b-1d58282ab099" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7394daf-c04a-4b2b-8eb1-4d529e9154cb",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87ddb647-c8f3-4ccb-8713-830ca469665e", "", "AQAAAAIAAYagAAAAEF7fmZtNxF9RUh5UO1rtofrfWniBeYzzhLehUJw2k/VvFv4ZjcfYzPCDA95Ta7Yxkg==", "1406fcb8-ff92-4180-b888-6b9c938166d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c8147e38-d648-443c-86a4-613134b29e50",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ff09c40-029d-4bcc-bb45-e3e9480b734c", "", "AQAAAAIAAYagAAAAEE7ccFrLgzbCPm7i4mWDLnb6I9Je4H61azUdfycwfImzddmJagj8dapCBMypdVIn8w==", "0eee9aec-baa5-424c-b6ed-4cdd18a21b0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c9dd6e91-4d35-41fa-8f26-7e77850b9238",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de24512d-1a13-4737-87a6-b38bba99263f", "", "AQAAAAIAAYagAAAAEIPI84DejCSUuIkQx/Ky0GSG98t0sCravuV+GPfQkXjI9eOtIINtTkrsdYb3SdyVTg==", "a2c49a19-98be-41d7-a0a0-190dc01c040e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccff2fdd-8cf4-488d-b71d-87611e378cbc",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99d1cfe6-4e2b-4872-bc6a-a05dbe25dc05", "", "AQAAAAIAAYagAAAAEGY+hlDzc0QyXKh9RXHAw/y3DX86pJ8ujUiPo6fFj1P5D4xLWHYP056ktQ9Rns80Xg==", "b3d0cd62-7ddc-4a16-b133-b695a90f2c87" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cfea451d-086b-457c-810c-9f886104ef22",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "87f11243-7238-4976-80ca-b6221b156197", "", "AQAAAAIAAYagAAAAEBvw190JBSNfwDBBPOHg+pp7um9mHogRUsBb6kjx9NCj7pD3FA7etBcbOgVKBlTtFA==", "96696e83-7900-47c1-88f6-1b17568c1175" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d333af68-2dd4-457a-a95f-332b92633488",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71780255-843a-48de-affd-df821bc48955", "", "AQAAAAIAAYagAAAAEJlKpo5kxIW21kFfg2QmoGg3lx23ogFdZNtNOr+eKUY0j1NgI0UnC67CD+lK3cFrbw==", "ed987a94-8558-46ed-9b03-9ae2cb1a9fc6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc58b575-8fdb-4f38-9786-2cff9819e7cd",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c0e22e1b-07df-4365-bd90-7ff0f9d41599", "", "AQAAAAIAAYagAAAAEP1Ax1Mx/mc5t47h/f3wTR+Yrhn+Iq+crQ0t0FV1J5R5LTgilvZPObDKsaaCC4ZreQ==", "a98ad85f-92ea-48c3-8020-31015ce1d434" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dce7e74a-8755-46b7-aae5-07203a97c338",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34cab34c-96d6-479a-a033-86b09992adb3", "", "AQAAAAIAAYagAAAAEMct92ToANIBYojHJzoEQOVhUfEs1lT3ilaW20BdP4Xp/Bc9Mzgzt03m2INiwLBeDg==", "5a5d6553-bc5d-4cff-889a-657dd3235fd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dcf7ae35-fa23-4b3e-b87f-c14b8512d7cd",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7458283c-3c1c-471c-acbb-53ceaa9b2337", "", "AQAAAAIAAYagAAAAEOwCuzQiRRizY8OCROHBeTY+1ZXmCYE1YX2MXONKqf+FwdWu7y1YUhAqEzCA/bSQUg==", "3002c7b2-426e-45cd-98cf-ba0e49524cff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dd1d4e98-5425-4263-a13b-3248c0fe735a",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "920058ba-265d-4b6e-91a3-14eb5f4453ad", "", "AQAAAAIAAYagAAAAELWQ+m50Aj9czSZRs6042c1GGNYGhxxNFMrS97uZZsHhy3JbDiVjxXpw1ozQa+8Vmw==", "44d41fd8-2f86-440e-8bae-017e6f46dd36" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e05f6ad4-7303-4e23-8b80-31655916aa24",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9baa6b2a-bd84-4ac9-82aa-6becfbbd15f9", "", "AQAAAAIAAYagAAAAEEk9Fyxnl7OsYGB/wOmJbCSQ6cL11c5qKgfOnqgEO1J4g+lK270AiGcWfvF/Tv7lyw==", "b9157a81-1e8c-45d6-8896-fed2b5cad36d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e3a6195a-894c-4e33-923a-7a6c5c15dff5",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e58ed3c9-ded6-4d96-82ae-0de4913ac775", "", "AQAAAAIAAYagAAAAEBfbYuQk1i2f6wu8lIZyX+hRLjoK8WQ1LEX+RpGZoO9oLBIUEjIAAhfcK0zN6X12+Q==", "8481dea5-f624-4233-8a81-187f8d46ce1d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e7b7408e-4749-44c8-b27d-684141616adb",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a0dc1a3d-917a-4e78-9546-fb3dd268fbae", "", "AQAAAAIAAYagAAAAEKRNe5pL6HGgwEUVOAqu8QnB2uk7T0ZU8lg0w/FpyF31+jWrM0fxfjwFPqUN4mYIvg==", "a07c7ef1-8f47-4180-887a-0b10ea04c3b9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea43c83c-ae12-496e-a44f-0fcd70917a07",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "322801a2-f40b-4069-bf1c-a95cc9a0ca96", "", "AQAAAAIAAYagAAAAEF6akj2RJo/nUZutNGdd2gUqxh57mxqdxCPmViTfZ30mrS6j10mXDx/es79kHHP9sg==", "39a1d9b6-6f71-4370-8c02-bef6a7b1d3e7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb353c76-e454-4e82-9e75-8214a212bbe1",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "70b23709-7611-4632-880f-b917977b2e68", "", "AQAAAAIAAYagAAAAEKZcsm8Dlr8sDW2aYG6hQew+AtI1ykODTIZHdjCJ1ui/YD/RtJuXSHmy+K7d5CeuYA==", "14f0db1a-91be-446a-b4b5-722df2c3edba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed4df161-1fa4-49f6-a1a9-8b3ea1f2dfba",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3638a903-9e8d-4a6b-a066-4fd83d5e5c92", "", "AQAAAAIAAYagAAAAEE182ivEhnv40bVO6A2XsSTyluae27P3TxsoeTwB7Xxk3XSV0yD3FZPcBgBS4dOvmA==", "0707e63d-4fef-4c82-a90a-15789fdf1c4e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f11f2379-20f6-4de8-81f6-e2d27ff4e2be",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a98d2718-6ec7-424d-9571-183c80380b02", "", "AQAAAAIAAYagAAAAEH2skrzrhY5sdYJmiYYvhXtYU7+1FkXke4Wo5agCalHEUbz7jnJvNGje5ySC/MMU7Q==", "8982bd88-ce2f-4f94-b4df-c4cdad91b6b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f29dfb76-a809-42e3-a13a-0be728a84762",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "48ac02c7-8c4e-482d-9847-ba470071abbb", "", "AQAAAAIAAYagAAAAELvE12hn3UEkiNP+VVu7T6sXj6m7AToZqF+TCvBryCnnZfEcISEDl8qEkhOOtrGHug==", "d731853f-471c-4b20-9297-888c9c4ef359" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f359ad89-c00c-4ebe-b4bd-7c1a8b0969a3",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12c13189-39f8-44c6-84b0-024bd9bbfad8", "", "AQAAAAIAAYagAAAAEND8ntqG21bnyRwfQBkypR5dtDCvGU9GUgOQE6wI6FcNFraTOeEKzd2L/lGgPvynkA==", "5b1b8fe0-5711-4869-afb3-e743852d68ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8f20479-f22b-490a-9a97-692213146c70",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "644c1243-4857-4348-b186-cde8870439bc", "", "AQAAAAIAAYagAAAAEE25b0v5PD8agq39xQZ2HuhMuHV8ejcZdoFl39pcOM0DjuTeOBWCfubEYUzprPq+EA==", "68fe273f-4093-4868-915d-4e82c405ebaa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f95d97e3-23ec-41cb-ad21-850d3d5ff794",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "938dfd9f-0b36-48e4-8157-9ceedb27c246", "", "AQAAAAIAAYagAAAAEEbhyZEhqXXv3HyZE5W8OxUEh/VUHy+/DbKeKMPJeCMtPmpF/zmuYmepi5UhNNqehQ==", "960aa331-a56e-4e4c-9d80-f7069bfa9893" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fb2607d1-2cd9-419a-93fe-35b618274d4b",
                columns: new[] { "ConcurrencyStamp", "IDCardPhoto", "PasswordHash", "SecurityStamp" },
                values: new object[] { "40c3153a-07c3-43d8-802a-d900d674fe1e", "", "AQAAAAIAAYagAAAAEFrkSYiDDPFLnVQpsAHuCp85J7DiprkF5ycNXWgcAVo1EBGTveukxXSRNQ/AJ6yY0Q==", "82cf878b-03fa-4bb7-ad2e-4eeab7048e8e" });

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "13f4d8d9-b5ae-4b79-9178-6aa26d6c5dd5",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "236c86d6-0ad1-4e1e-9461-1c19ddac9d1c",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "2a2906f2-c035-416a-88a5-00426bac05af",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "3dbd348c-bf90-47f8-8604-1e35728154d5",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "41fc1316-906d-4566-903f-a11e66b4e372",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "53bc79ab-fb93-4514-9712-6ab1398a9c0d",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "777b3eae-82a6-4c97-9e73-97e3fd40fd89",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "82712fd4-3d4c-4569-bbb7-a29e65de36ec",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "8a1e1c7f-aa3f-4342-b384-e4b483eee994",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "a2fedcc6-d568-44d4-a976-7e491a93a997",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "aa5c56c8-6237-4c86-9ddb-ae133fe2e4e0",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "b04c5c8e-0409-4c55-aaf8-9cde500f0c00",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "be233685-9ea1-4452-a0b6-6ccdbabe89bd",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "dce7e74a-8755-46b7-aae5-07203a97c338",
                column: "SecurityLevel",
                value: "");

            migrationBuilder.UpdateData(
                table: "TourGuides",
                keyColumn: "Id",
                keyValue: "e7b7408e-4749-44c8-b27d-684141616adb",
                column: "SecurityLevel",
                value: "");
        }
    }
}
