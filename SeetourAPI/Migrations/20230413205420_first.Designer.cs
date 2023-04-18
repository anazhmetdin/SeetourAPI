﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SeetourAPI.Data.Context;

#nullable disable

namespace SeetourAPI.Migrations
{
    [DbContext(typeof(SeetourContext))]
    [Migration("20230413205420_first")]
    partial class first
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.BookedTour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("LastEditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int>("Seats")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TourBookingPaymentId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourBookingPaymentId")
                        .IsUnique();

                    b.HasIndex("TourId");

                    b.ToTable("BookedTours");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.CustomerLikes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourId");

                    b.ToTable("CustomerLikes");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.CustomerWishlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourId");

                    b.ToTable("CustomerWishlists");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.EditRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdminComments")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourId");

                    b.ToTable("EditRequest");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ReviewId")
                        .HasColumnType("int");

                    b.Property<int?>("TourId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId");

                    b.HasIndex("TourId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BoodedTourId")
                        .HasColumnType("int");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("LastEditedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BoodedTourId")
                        .IsUnique();

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasTransportation")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastDateToCancel")
                        .HasColumnType("datetime2");

                    b.Property<string>("LocationFrom")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LocationFromUrl")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("LocationTo")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("LocationToUrl")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime>("PostedAt")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TourGuideId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TourPostingStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Category");

                    b.HasIndex("DateFrom");

                    b.HasIndex("DateTo");

                    b.HasIndex("HasTransportation");

                    b.HasIndex("LocationFrom");

                    b.HasIndex("LocationTo");

                    b.HasIndex("TourGuideId");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourQuestionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("TourAnswer");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourBookingPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BookedTourId")
                        .HasColumnType("int");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("varchar(19)");

                    b.Property<string>("CardholderName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Cvc")
                        .IsRequired()
                        .HasColumnType("varchar(3)");

                    b.Property<string>("ExpirationDate")
                        .IsRequired()
                        .HasColumnType("varchar(5)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("TourBookingPayment");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourQuestion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TourAnswerId")
                        .HasColumnType("int");

                    b.Property<int>("TourId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TourAnswerId")
                        .IsUnique()
                        .HasFilter("[TourAnswerId] IS NOT NULL");

                    b.HasIndex("TourId");

                    b.ToTable("TourQuestions");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.SeetourUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePic")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("SSN")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.TourGuide", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("IDCardPhoto")
                        .IsRequired()
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("RecipientAccountNumberOrIBAN")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RecipientBankNameAndAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RecipientBankSwiftCode")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("RecipientNameAndAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaxRegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("TourGuides");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.BookedTour", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.Customer", "Customer")
                        .WithMany("BookedTours")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.TourBookingPayment", "TourBookingPayment")
                        .WithOne("BookedTour")
                        .HasForeignKey("SeetourAPI.Data.Models.BookedTour", "TourBookingPaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.Tour", "Tour")
                        .WithMany("Bookings")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");

                    b.Navigation("TourBookingPayment");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.CustomerLikes", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.Customer", "Customer")
                        .WithMany("Likes")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.Tour", "Tour")
                        .WithMany("Likes")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.CustomerWishlist", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.Customer", "Customer")
                        .WithMany("Wishlist")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.Tour", "Tour")
                        .WithMany("Wishlist")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.EditRequest", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Tour", "Tour")
                        .WithMany("EditRequests")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Photo", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Review", null)
                        .WithMany("Photos")
                        .HasForeignKey("ReviewId");

                    b.HasOne("SeetourAPI.Data.Models.Tour", null)
                        .WithMany("Photos")
                        .HasForeignKey("TourId");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Review", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.BookedTour", "BookedTour")
                        .WithOne("Review")
                        .HasForeignKey("SeetourAPI.Data.Models.Review", "BoodedTourId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookedTour");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Tour", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.TourGuide", "TourGuide")
                        .WithMany("Tours")
                        .HasForeignKey("TourGuideId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourQuestion", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeetourAPI.Data.Models.TourAnswer", "TourAnswer")
                        .WithOne("TourQuestion")
                        .HasForeignKey("SeetourAPI.Data.Models.TourQuestion", "TourAnswerId");

                    b.HasOne("SeetourAPI.Data.Models.Tour", "Tour")
                        .WithMany("Questions")
                        .HasForeignKey("TourId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Tour");

                    b.Navigation("TourAnswer");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.Customer", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", "User")
                        .WithOne("Customer")
                        .HasForeignKey("SeetourAPI.Data.Models.Users.Customer", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.TourGuide", b =>
                {
                    b.HasOne("SeetourAPI.Data.Models.Users.SeetourUser", "User")
                        .WithOne("TourGuide")
                        .HasForeignKey("SeetourAPI.Data.Models.Users.TourGuide", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.BookedTour", b =>
                {
                    b.Navigation("Review");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Review", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Tour", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("EditRequests");

                    b.Navigation("Likes");

                    b.Navigation("Photos");

                    b.Navigation("Questions");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourAnswer", b =>
                {
                    b.Navigation("TourQuestion");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.TourBookingPayment", b =>
                {
                    b.Navigation("BookedTour");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.Customer", b =>
                {
                    b.Navigation("BookedTours");

                    b.Navigation("Likes");

                    b.Navigation("Wishlist");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.SeetourUser", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("TourGuide");
                });

            modelBuilder.Entity("SeetourAPI.Data.Models.Users.TourGuide", b =>
                {
                    b.Navigation("Tours");
                });
#pragma warning restore 612, 618
        }
    }
}
