﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleAccountBook.Data;

namespace SimpleAccountBook.Data.SqlServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210404093148_Initialization")]
    partial class Initialization
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SimpleAccountBook.Entities.Account", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("AddressId")
                        .HasColumnType("char(36)")
                        .HasComment("주소 식별자");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 388, DateTimeKind.Unspecified).AddTicks(9489), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("상호, 법인명");

                    b.Property<string>("RegistrationNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("사업자등록번호, 법인등록번호");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.ToTable("Account");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Address", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("시, 구");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 401, DateTimeKind.Unspecified).AddTicks(9447), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("전화번호");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("도, 시");

                    b.Property<string>("StreetAddress1")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("세부주소1");

                    b.Property<string>("StreetAddress2")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("세부주소2");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)")
                        .HasComment("우편번호");

                    b.HasKey("Id");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Amount", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 402, DateTimeKind.Unspecified).AddTicks(8470), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("SupplyPrice")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("공급가액");

                    b.Property<decimal>("Tax")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("세액");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Amount");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Business", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("AddressId")
                        .HasColumnType("char(36)")
                        .HasComment("주소");

                    b.Property<string>("BusinessItem")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("업종");

                    b.Property<string>("BusinessItemCode")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("업종코드");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 404, DateTimeKind.Unspecified).AddTicks(5528), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("상호");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasComment("사업자등록번호, 주민등록번호");

                    b.Property<string>("TypeOfIncomeCode")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("소득종류코드");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("사용자 식별자");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.HasIndex("UserId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.GeneralCode", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("Code")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("코드");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 407, DateTimeKind.Unspecified).AddTicks(3014), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("Ordinal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasComment("출력순서");

                    b.Property<string>("ParentId")
                        .HasColumnType("char(36)")
                        .HasComment("상위코드 식별자");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("출력");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("GeneralCode");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Stock", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("BusinessId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("사업장 식별자");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 409, DateTimeKind.Unspecified).AddTicks(745), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<decimal>("MaterialBeginningOfYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("기초재료재고액");

                    b.Property<decimal>("MaterialEndYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("기말재료재고액");

                    b.Property<decimal>("ProductBeginningOfYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("기초상품재고액");

                    b.Property<decimal>("ProductEndYear")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal(15,2)")
                        .HasDefaultValue(0m)
                        .HasComment("기말상품재고액");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Year")
                        .HasColumnType("int")
                        .HasComment("귀속년도");

                    b.HasKey("Id");

                    b.HasIndex("BusinessId");

                    b.ToTable("Stock");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("거래처 식별자");

                    b.Property<string>("AmountId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("금액 식별자");

                    b.Property<string>("BusinessId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("사업장 식별자");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 411, DateTimeKind.Unspecified).AddTicks(1373), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasComment("일자");

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("RemarkId")
                        .HasColumnType("char(36)")
                        .HasComment("비고 식별자");

                    b.Property<string>("RemarkNote")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasComment("비고 기록");

                    b.Property<string>("TransactionDetailsId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("거래내용");

                    b.Property<string>("TransactionDetailsNote")
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasComment("거래내용 기록");

                    b.Property<string>("TransactionTypeId")
                        .IsRequired()
                        .HasColumnType("char(36)")
                        .HasComment("거래구분 (수입, 비용, 고정자산)");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AmountId")
                        .IsUnique();

                    b.HasIndex("BusinessId");

                    b.HasIndex("RemarkId");

                    b.HasIndex("TransactionDetailsId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasComment("식별자");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset")
                        .HasDefaultValue(new DateTimeOffset(new DateTime(2021, 4, 4, 9, 31, 48, 414, DateTimeKind.Unspecified).AddTicks(271), new TimeSpan(0, 0, 0, 0, 0)));

                    b.Property<DateTimeOffset?>("DeletedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("출력이름");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasComment("전자우편주소, 로그인에 사용");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("IsEmailVerified")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasComment("비밀번호, 해시됨");

                    b.Property<DateTimeOffset?>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Account", b =>
                {
                    b.HasOne("SimpleAccountBook.Entities.Address", "Address")
                        .WithOne()
                        .HasForeignKey("SimpleAccountBook.Entities.Account", "AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Business", b =>
                {
                    b.HasOne("SimpleAccountBook.Entities.Address", "Address")
                        .WithOne()
                        .HasForeignKey("SimpleAccountBook.Entities.Business", "AddressId");

                    b.HasOne("SimpleAccountBook.Entities.User", "User")
                        .WithMany("Businesses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.GeneralCode", b =>
                {
                    b.HasOne("SimpleAccountBook.Entities.GeneralCode", "Parent")
                        .WithMany("SubCodes")
                        .HasForeignKey("ParentId");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Stock", b =>
                {
                    b.HasOne("SimpleAccountBook.Entities.Business", "Business")
                        .WithMany("Stocks")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Business");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Transaction", b =>
                {
                    b.HasOne("SimpleAccountBook.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAccountBook.Entities.Amount", "Amount")
                        .WithOne()
                        .HasForeignKey("SimpleAccountBook.Entities.Transaction", "AmountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAccountBook.Entities.Business", "Business")
                        .WithMany("Transactions")
                        .HasForeignKey("BusinessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAccountBook.Entities.GeneralCode", "Remark")
                        .WithMany()
                        .HasForeignKey("RemarkId");

                    b.HasOne("SimpleAccountBook.Entities.GeneralCode", "TransactionDetails")
                        .WithMany()
                        .HasForeignKey("TransactionDetailsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SimpleAccountBook.Entities.GeneralCode", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Amount");

                    b.Navigation("Business");

                    b.Navigation("Remark");

                    b.Navigation("TransactionDetails");

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.Business", b =>
                {
                    b.Navigation("Stocks");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.GeneralCode", b =>
                {
                    b.Navigation("SubCodes");
                });

            modelBuilder.Entity("SimpleAccountBook.Entities.User", b =>
                {
                    b.Navigation("Businesses");
                });
#pragma warning restore 612, 618
        }
    }
}
