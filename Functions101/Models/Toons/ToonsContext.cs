using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Functions101.Models.Toons
{
    public partial class ToonsContext : DbContext
    {
        public ToonsContext()
        {
        }

        public ToonsContext(DbContextOptions<ToonsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<Athlete> Athletes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<Continent> Continents { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<FoodCategory> FoodCategories { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Organism> Organisms { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Province> Provinces { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<Sickness> Sicknesses { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<VehicleManufacturer> VehicleManufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>(entity =>
            {
                entity.HasIndex(e => e.MovieId, "IX_Actors_MovieId");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.HasOne(d => d.Movie)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(d => d.MovieId);
            });

            modelBuilder.Entity<Athlete>(entity =>
            {
                entity.HasIndex(e => e.CompetitionId, "IX_Athletes_CompetitionId");

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.Athletes)
                    .HasForeignKey(d => d.CompetitionId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityName);

                entity.HasIndex(e => e.ProvinceId, "IX_Cities_ProvinceId");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.ProvinceId);
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.Property(e => e.EventName).IsRequired();
            });

            modelBuilder.Entity<Continent>(entity =>
            {
                entity.HasKey(e => e.ContinentName);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.CountryName);

                entity.HasIndex(e => e.ContinentName, "IX_Countries_ContinentName");

                entity.Property(e => e.CapitalCity).IsRequired();

                entity.Property(e => e.ContinentName).IsRequired();

                entity.HasOne(d => d.ContinentNameNavigation)
                    .WithMany(p => p.Countries)
                    .HasForeignKey(d => d.ContinentName);
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasIndex(e => e.InstructorId, "IX_Courses_InstructorId");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Instructor)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.InstructorId);
            });

            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasIndex(e => e.FoodCategoryId, "IX_Foods_FoodCategoryId");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Unit).IsRequired();

                entity.HasOne(d => d.FoodCategory)
                    .WithMany(p => p.Foods)
                    .HasForeignKey(d => d.FoodCategoryId);
            });

            modelBuilder.Entity<FoodCategory>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PostalCode).IsRequired();

                entity.Property(e => e.Province).IsRequired();

                entity.Property(e => e.Street).IsRequired();
            });

            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.HasIndex(e => e.SicknessId, "IX_Medicines_SicknessId");

                entity.Property(e => e.DosageUnit).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Sickness)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.SicknessId);
            });

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.HasIndex(e => e.RestaurantId, "IX_MenuItems_RestaurantId");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Size).IsRequired();

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.RestaurantId);
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.DirectorFirstName).IsRequired();

                entity.Property(e => e.DirectorLastName).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Rating).IsRequired();
            });

            modelBuilder.Entity<Organism>(entity =>
            {
                entity.HasIndex(e => e.SpecieName, "IX_Organisms_SpecieName");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SpecieName).IsRequired();

                entity.HasOne(d => d.SpecieNameNavigation)
                    .WithMany(p => p.Organisms)
                    .HasForeignKey(d => d.SpecieName);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasIndex(e => e.HospitalId, "IX_Patients_HospitalId");

                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.PostalCode).IsRequired();

                entity.Property(e => e.Province).IsRequired();

                entity.Property(e => e.RoomNumber).IsRequired();

                entity.Property(e => e.Street).IsRequired();

                entity.HasOne(d => d.Hospital)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.HospitalId);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Occupation)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.PictureUrl)
                    .HasMaxLength(500)
                    .HasColumnName("PictureURL");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.TeamName, "IX_Players_TeamName");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();

                entity.Property(e => e.Position).IsRequired();

                entity.Property(e => e.TeamName).HasMaxLength(30);

                entity.HasOne(d => d.TeamNameNavigation)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.TeamName);
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.HasIndex(e => e.CountryName, "IX_Provinces_CountryName");

                entity.Property(e => e.CapitalCity).IsRequired();

                entity.Property(e => e.CountryName).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.CountryNameNavigation)
                    .WithMany(p => p.Provinces)
                    .HasForeignKey(d => d.CountryName);
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.Property(e => e.City).IsRequired();

                entity.Property(e => e.Country).IsRequired();

                entity.Property(e => e.FoodType).IsRequired();

                entity.Property(e => e.PostalCode).IsRequired();

                entity.Property(e => e.Province).IsRequired();

                entity.Property(e => e.RestaurantName).IsRequired();

                entity.Property(e => e.Street).IsRequired();
            });

            modelBuilder.Entity<Sickness>(entity =>
            {
                entity.HasIndex(e => e.PatientId, "IX_Sicknesses_PatientId");

                entity.Property(e => e.SicknessName).IsRequired();

                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Sicknesses)
                    .HasForeignKey(d => d.PatientId);
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.HasKey(e => e.SpecieName);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasMaxLength(20);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.School)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(e => e.TeamName);

                entity.Property(e => e.TeamName).HasMaxLength(30);
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Model);

                entity.HasIndex(e => e.VehicleManufacturerName, "IX_Vehicles_VehicleManufacturerName");

                entity.Property(e => e.Fuel).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.Property(e => e.VehicleManufacturerName).IsRequired();

                entity.HasOne(d => d.VehicleManufacturerNameNavigation)
                    .WithMany(p => p.Vehicles)
                    .HasForeignKey(d => d.VehicleManufacturerName);
            });

            modelBuilder.Entity<VehicleManufacturer>(entity =>
            {
                entity.HasKey(e => e.VehicleManufacturerName);

                entity.Property(e => e.Country).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
