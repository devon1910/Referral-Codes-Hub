﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Referral_Codes_Hub.Infrastructure;

#nullable disable

namespace Referral_Codes_Hub.Infrastructure.Migrations
{
    [DbContext(typeof(ReferralCodeDBContext))]
    partial class ReferralCodeDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Referral_Codes_Hub.Domain.Entities.ReferralCode", b =>
                {
                    b.Property<int>("RefId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RefId"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateLastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumberOfUsersReferred")
                        .HasColumnType("int");

                    b.Property<string>("ReferralLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReferredBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RefId");

                    b.ToTable("ReferralCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
