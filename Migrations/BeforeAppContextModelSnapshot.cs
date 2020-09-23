﻿// <auto-generated />
using System;
using BeforeApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeforeApp.Migrations
{
    [DbContext(typeof(BeforeAppContext))]
    partial class BeforeAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.EventMusicGenres", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("MusicGenreId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "MusicGenreId");

                    b.HasIndex("MusicGenreId");

                    b.ToTable("EventMusicGenres");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            MusicGenreId = 1
                        },
                        new
                        {
                            EventId = 1,
                            MusicGenreId = 2
                        },
                        new
                        {
                            EventId = 2,
                            MusicGenreId = 2
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.PersonEvents", b =>
                {
                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("EventId", "PersonId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonEvents");

                    b.HasData(
                        new
                        {
                            EventId = 1,
                            PersonId = 1
                        },
                        new
                        {
                            EventId = 2,
                            PersonId = 1
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.PersonMusicGenres", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("MusicGenreId")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "MusicGenreId");

                    b.HasIndex("MusicGenreId");

                    b.ToTable("PersonMusicGenres");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            MusicGenreId = 1
                        },
                        new
                        {
                            PersonId = 1,
                            MusicGenreId = 2
                        },
                        new
                        {
                            PersonId = 2,
                            MusicGenreId = 2
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Moniker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PublisherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventDate = new DateTime(2020, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 1,
                            Moniker = "tekk2020waw",
                            Name = "Tekk"
                        },
                        new
                        {
                            Id = 2,
                            EventDate = new DateTime(2021, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LocationId = 2,
                            Moniker = "Orga202ldz",
                            Name = "Organic"
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Moniker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adress = "Unknown",
                            City = "Unknown",
                            Name = "Unknown Location"
                        },
                        new
                        {
                            Id = 2,
                            Adress = "Off",
                            City = "Lodz",
                            Name = "Dom"
                        },
                        new
                        {
                            Id = 3,
                            Adress = "Ul. Jeden",
                            City = "Warszawa",
                            Name = "Plener"
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.MusicGenre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MusicGenres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Techno"
                        },
                        new
                        {
                            Id = 2,
                            Name = "House"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Folk"
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Orientation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("BeforeApp.Data.Person");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Birthdate = new DateTime(1994, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "<3",
                            Email = "admin@elo.pl",
                            Nickname = "Admin",
                            Orientation = "Bi",
                            Sex = "Other"
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Artist", b =>
                {
                    b.HasBaseType("BeforeApp.Data.Person");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.HasDiscriminator().HasValue("Artist");
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.User", b =>
                {
                    b.HasBaseType("BeforeApp.Data.Person");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasIndex("PersonId");

                    b.HasDiscriminator().HasValue("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = new DateTime(1985, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Siema elo 520",
                            Email = "technochlopak@elo.pl",
                            Nickname = "Ziomek",
                            Orientation = "Straight",
                            Sex = "Male"
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = new DateTime(1994, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "<3",
                            Email = "technolaska@elo.pl",
                            Nickname = "Ziomalka",
                            Orientation = "Bi",
                            Sex = "Female"
                        });
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.EventMusicGenres", b =>
                {
                    b.HasOne("BeforeApp.Data.Entities.Event", "Event")
                        .WithMany("EventMusicGenres")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeforeApp.Data.Entities.MusicGenre", "MusicGenre")
                        .WithMany("EventMusicGenres")
                        .HasForeignKey("MusicGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.PersonEvents", b =>
                {
                    b.HasOne("BeforeApp.Data.Entities.Event", "Event")
                        .WithMany("PersonEvents")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeforeApp.Data.Person", "Person")
                        .WithMany("PersonEvents")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Connectors.PersonMusicGenres", b =>
                {
                    b.HasOne("BeforeApp.Data.Entities.MusicGenre", "MusicGenre")
                        .WithMany("PersonMusicGenres")
                        .HasForeignKey("MusicGenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeforeApp.Data.Person", "Person")
                        .WithMany("PersonMusicGenres")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Event", b =>
                {
                    b.HasOne("BeforeApp.Data.Entities.Location", "Location")
                        .WithMany("Events")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BeforeApp.Data.Person", "Publisher")
                        .WithMany()
                        .HasForeignKey("PublisherId");
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.Artist", b =>
                {
                    b.HasOne("BeforeApp.Data.Entities.Event", null)
                        .WithMany("Artists")
                        .HasForeignKey("EventId");

                    b.HasOne("BeforeApp.Data.Entities.User", null)
                        .WithMany("Artists")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("BeforeApp.Data.Entities.User", b =>
                {
                    b.HasOne("BeforeApp.Data.Person", null)
                        .WithMany("ConnectedUsers")
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
