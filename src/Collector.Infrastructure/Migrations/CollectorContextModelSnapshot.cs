// <auto-generated />
using System;
using Collector.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Collector.Infrastructure.Migrations
{
    [DbContext(typeof(CollectorContext))]
    partial class CollectorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Collector.Domain.Entities.CovidHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Active")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CityCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Confirmed")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Deaths")
                        .HasColumnType("int");

                    b.Property<string>("Lat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Province")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Recovered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CovidHistories");
                });

            modelBuilder.Entity("Collector.Domain.Entities.CovidSummary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("NewConfirmed")
                        .HasColumnType("int");

                    b.Property<int>("NewDeaths")
                        .HasColumnType("int");

                    b.Property<int>("NewRecovered")
                        .HasColumnType("int");

                    b.Property<int>("TotalConfirmed")
                        .HasColumnType("int");

                    b.Property<int>("TotalDeaths")
                        .HasColumnType("int");

                    b.Property<int>("TotalRecovered")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CovidSummaries");
                });

            modelBuilder.Entity("Collector.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "P@ssw0rd",
                            UserName = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
