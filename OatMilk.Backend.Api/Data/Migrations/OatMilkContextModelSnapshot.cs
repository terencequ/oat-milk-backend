﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OatMilk.Backend.Api.Data;

namespace OatMilk.Backend.Api.Data.Migrations
{
    [DbContext(typeof(OatMilkContext))]
    partial class OatMilkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CooldownEffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CostEffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CooldownEffectId");

                    b.HasIndex("CostEffectId");

                    b.HasIndex("UserId");

                    b.ToTable("Ability");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Attribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BaseValue")
                        .HasColumnType("float");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<double>("CurrentValue")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Attribute");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Acrobatics")
                        .HasColumnType("bit");

                    b.Property<string>("AlliesAndOrganisations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AnimalHandling")
                        .HasColumnType("bit");

                    b.Property<string>("Appearance")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Arcana")
                        .HasColumnType("bit");

                    b.Property<bool>("Athletics")
                        .HasColumnType("bit");

                    b.Property<string>("Backstory")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Bonds")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deception")
                        .HasColumnType("bit");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("Flaws")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("History")
                        .HasColumnType("bit");

                    b.Property<string>("Ideals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Insight")
                        .HasColumnType("bit");

                    b.Property<bool>("Intimidation")
                        .HasColumnType("bit");

                    b.Property<bool>("Investigation")
                        .HasColumnType("bit");

                    b.Property<bool>("Medicine")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Nature")
                        .HasColumnType("bit");

                    b.Property<bool>("Perception")
                        .HasColumnType("bit");

                    b.Property<bool>("Performance")
                        .HasColumnType("bit");

                    b.Property<string>("PersonalityTraits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Religion")
                        .HasColumnType("bit");

                    b.Property<bool>("SleightOfHand")
                        .HasColumnType("bit");

                    b.Property<bool>("Stealth")
                        .HasColumnType("bit");

                    b.Property<bool>("Survival")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Character");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Effect", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbilityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("ChanceToApplyToTarget")
                        .HasColumnType("real");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Period")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AbilityId");

                    b.HasIndex("UserId");

                    b.ToTable("Effect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Level", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExperienceRequirement")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("ProficiencyBonus")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDateTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Modifier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EffectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Magnitude")
                        .HasColumnType("float");

                    b.Property<int>("Operation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EffectId");

                    b.ToTable("Modifier");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.User", b =>
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

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Ability", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.Effect", "CooldownEffect")
                        .WithMany()
                        .HasForeignKey("CooldownEffectId");

                    b.HasOne("OatMilk.Backend.Api.Data.Entities.Effect", "CostEffect")
                        .WithMany()
                        .HasForeignKey("CostEffectId");

                    b.HasOne("OatMilk.Backend.Api.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CooldownEffect");

                    b.Navigation("CostEffect");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Attribute", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.Character", null)
                        .WithMany("Attributes")
                        .HasForeignKey("CharacterId");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Character", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Effect", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.Ability", null)
                        .WithMany("Effects")
                        .HasForeignKey("AbilityId");

                    b.HasOne("OatMilk.Backend.Api.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Level", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Modifier", b =>
                {
                    b.HasOne("OatMilk.Backend.Api.Data.Entities.Effect", "Effect")
                        .WithMany("Modifiers")
                        .HasForeignKey("EffectId");

                    b.Navigation("Effect");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Ability", b =>
                {
                    b.Navigation("Effects");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Character", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("OatMilk.Backend.Api.Data.Entities.Effect", b =>
                {
                    b.Navigation("Modifiers");
                });
#pragma warning restore 612, 618
        }
    }
}
