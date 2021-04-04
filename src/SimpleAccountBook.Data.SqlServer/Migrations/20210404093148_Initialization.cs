using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleAccountBook.Data.SqlServer.Migrations
{
    public partial class Initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Zipcode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "우편번호"),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "도, 시"),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "시, 구"),
                    StreetAddress1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "세부주소1"),
                    StreetAddress2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "세부주소2"),
                    PhoneNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "전화번호"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 401, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amount",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    SupplyPrice = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "공급가액"),
                    Tax = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "세액"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 402, DateTimeKind.Unspecified).AddTicks(8470), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amount", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralCode",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    ParentId = table.Column<string>(type: "char(36)", nullable: true, comment: "상위코드 식별자"),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "코드"),
                    Text = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "출력"),
                    Ordinal = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "출력순서"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 407, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralCode_GeneralCode_ParentId",
                        column: x => x.ParentId,
                        principalTable: "GeneralCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Email = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "전자우편주소, 로그인에 사용"),
                    Password = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "비밀번호, 해시됨"),
                    DisplayName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "출력이름"),
                    IsEmailVerified = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 414, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "상호, 법인명"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true, comment: "사업자등록번호, 법인등록번호"),
                    AddressId = table.Column<string>(type: "char(36)", nullable: true, comment: "주소 식별자"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 388, DateTimeKind.Unspecified).AddTicks(9489), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Account_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false, comment: "상호"),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "사업자등록번호, 주민등록번호"),
                    AddressId = table.Column<string>(type: "char(36)", nullable: true, comment: "주소"),
                    BusinessItem = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "업종"),
                    BusinessItemCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "업종코드"),
                    TypeOfIncomeCode = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true, comment: "소득종류코드"),
                    UserId = table.Column<string>(type: "char(36)", nullable: false, comment: "사용자 식별자"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 404, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "귀속년도"),
                    ProductBeginningOfYear = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "기초상품재고액"),
                    ProductEndYear = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "기말상품재고액"),
                    MaterialBeginningOfYear = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "기초재료재고액"),
                    MaterialEndYear = table.Column<decimal>(type: "decimal(15,2)", nullable: false, defaultValue: 0m, comment: "기말재료재고액"),
                    BusinessId = table.Column<string>(type: "char(36)", nullable: false, comment: "사업장 식별자"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 409, DateTimeKind.Unspecified).AddTicks(745), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    Id = table.Column<string>(type: "char(36)", nullable: false, comment: "식별자"),
                    Date = table.Column<DateTime>(type: "date", nullable: false, comment: "일자"),
                    TransactionTypeId = table.Column<string>(type: "char(36)", nullable: false, comment: "거래구분 (수입, 비용, 고정자산)"),
                    TransactionDetailsId = table.Column<string>(type: "char(36)", nullable: false, comment: "거래내용"),
                    TransactionDetailsNote = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "거래내용 기록"),
                    AccountId = table.Column<string>(type: "char(36)", nullable: false, comment: "거래처 식별자"),
                    AmountId = table.Column<string>(type: "char(36)", nullable: false, comment: "금액 식별자"),
                    RemarkId = table.Column<string>(type: "char(36)", nullable: true, comment: "비고 식별자"),
                    RemarkNote = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true, comment: "비고 기록"),
                    BusinessId = table.Column<string>(type: "char(36)", nullable: false, comment: "사업장 식별자"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValue: new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 411, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 0, 0, 0, 0))),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DeletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transaction_Account_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Amount_AmountId",
                        column: x => x.AmountId,
                        principalTable: "Amount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_GeneralCode_RemarkId",
                        column: x => x.RemarkId,
                        principalTable: "GeneralCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_GeneralCode_TransactionDetailsId",
                        column: x => x.TransactionDetailsId,
                        principalTable: "GeneralCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transaction_GeneralCode_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "GeneralCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_AddressId",
                table: "Account",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Business_AddressId",
                table: "Business",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Business_UserId",
                table: "Business",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralCode_ParentId",
                table: "GeneralCode",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_BusinessId",
                table: "Stock",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AccountId",
                table: "Transaction",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_AmountId",
                table: "Transaction",
                column: "AmountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_BusinessId",
                table: "Transaction",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_RemarkId",
                table: "Transaction",
                column: "RemarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionDetailsId",
                table: "Transaction",
                column: "TransactionDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_TransactionTypeId",
                table: "Transaction",
                column: "TransactionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Amount");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "GeneralCode");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
