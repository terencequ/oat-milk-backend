﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OatMilk.Backend.Api.Data;

namespace OatMilk.Backend.Api.Data.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CooldownEffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CostEffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CooldownEffectId");

                    b.HasIndex("CostEffectId");

                    b.HasIndex("UserId");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.AbilityEffect", b =>
                {
                    b.Property<Guid>("AbilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EffectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AbilityId", "EffectId");

                    b.HasIndex("EffectId");

                    b.ToTable("AbilityEffect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Effect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ChanceToApplyToTarget")
                        .HasColumnType("real");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Effect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Modifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Magnitude")
                        .HasColumnType("real");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectId");

                    b.ToTable("Modifier");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedUtc")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Ability", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.Effect", "CooldownEffect")
                        .WithMany()
                        .HasForeignKey("CooldownEffectId");

                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.Effect", "CostEffect")
                        .WithMany()
                        .HasForeignKey("CostEffectId");

                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("CooldownEffect");

                    b.Navigation("CostEffect");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.AbilityEffect", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.Ability", "Ability")
                        .WithMany("AbilityEffects")
                        .HasForeignKey("AbilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.Effect", "Effect")
                        .WithMany("AbilityEffects")
                        .HasForeignKey("EffectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ability");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Effect", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Modifier", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Models.Entities.Effect", "Effect")
                        .WithMany("Modifiers")
                        .HasForeignKey("EffectId");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Ability", b =>
                {
                    b.Navigation("AbilityEffects");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Models.Entities.Effect", b =>
                {
                    b.Navigation("AbilityEffects");

                    b.Navigation("Modifiers");
                });
#pragma warning restore 612, 618
        }
    }
}
