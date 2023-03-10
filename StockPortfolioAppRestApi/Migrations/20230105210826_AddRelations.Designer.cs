// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockPortfolioApp.Data;

#nullable disable

namespace StockPortfolioApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230105210826_AddRelations")]
    partial class AddRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StockPortfolioApp.Models.Portfolio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Portfolios");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.PortfolioComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("PortfolioComponents");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StockExchangeId")
                        .HasColumnType("int");

                    b.Property<string>("Ticker")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("StockExchangeId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.StockData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("RegisterTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Volume")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("StockDatas");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.StockExchange", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StockExchange");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<int>("PortfolioId")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PortfolioId");

                    b.HasIndex("StockId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Portfolio", b =>
                {
                    b.HasOne("StockPortfolioApp.Models.User", "User")
                        .WithMany("Portfolios")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.PortfolioComponent", b =>
                {
                    b.HasOne("StockPortfolioApp.Models.Portfolio", "Portfolio")
                        .WithMany("PortfolioComponents")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockPortfolioApp.Models.Stock", "Stock")
                        .WithMany("PortfolioComponents")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Stock", b =>
                {
                    b.HasOne("StockPortfolioApp.Models.StockExchange", "StockExchange")
                        .WithMany()
                        .HasForeignKey("StockExchangeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockExchange");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.StockData", b =>
                {
                    b.HasOne("StockPortfolioApp.Models.Stock", "Stock")
                        .WithMany("StockDatas")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Transaction", b =>
                {
                    b.HasOne("StockPortfolioApp.Models.Portfolio", "Portfolio")
                        .WithMany("Transactions")
                        .HasForeignKey("PortfolioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockPortfolioApp.Models.Stock", "Stock")
                        .WithMany("Transactions")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Portfolio", b =>
                {
                    b.Navigation("PortfolioComponents");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.Stock", b =>
                {
                    b.Navigation("PortfolioComponents");

                    b.Navigation("StockDatas");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("StockPortfolioApp.Models.User", b =>
                {
                    b.Navigation("Portfolios");
                });
#pragma warning restore 612, 618
        }
    }
}
