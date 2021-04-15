using System;
using System.Threading;
using System.Threading.Tasks;
using Eindopdracht.Config;
using EindopdrachtBackendDevelopment.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Eindopdracht.DataContext
{
    public interface ITeamContext {
        DbSet<Career> Career { get; set; }
        DbSet<Driver> Driver { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<Sponsor> Sponsor { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class TeamContext : DbContext, ITeamContext {
        public DbSet<Career> Career { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Sponsor> Sponsor { get; set; }
        public DbSet<TeamSponsors> TeamSponsors { get; set; }
        private ConnectionStrings _connectionStrings;

        public TeamContext(DbContextOptions<TeamContext> options, IOptions<ConnectionStrings> connectionStrings) : base(options) {
            _connectionStrings = connectionStrings.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) {
            options.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
            options.UseSqlServer(_connectionStrings.SQL);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            // Veel op veel relatie
            modelBuilder.Entity<TeamSponsors>().HasKey(cs => new {cs.TeamId, cs.SponsorId});

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 1,
                TeamName = "Scuderia Ferrari",
                Location = "Italy"
            });

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 2,
                TeamName = "McLaren",
                Location = "United Kingdom"
            });

            modelBuilder.Entity<Team>().HasData(new Team()
            {
                TeamId = 3,
                TeamName = "Aston Martin",
                Location = "United Kingdom"
            });

            modelBuilder.Entity<Driver>().HasData(new Driver()
            {
                DriverId = 1,
                FirstName = "Charles",
                LastName = "Leclerc",
                RaceNumber = 16,
                Nationality = "Monégasque",
                CareerId = 1,
                TeamId = 1
            });

            modelBuilder.Entity<Driver>().HasData(new Driver()
            {
                DriverId = 2,
                FirstName = "Lando",
                LastName = "Norris",
                RaceNumber = 4,
                Nationality = "British",
                CareerId = 2,
                TeamId = 2
            });

            modelBuilder.Entity<Driver>().HasData(new Driver()
            {
                DriverId = 3,
                FirstName = "Sebastian",
                LastName = "Vettel",
                RaceNumber = 5,
                Nationality = "German",
                CareerId = 3,
                TeamId = 3
            });

            modelBuilder.Entity<Driver>().HasData(new Driver(){
                DriverId= 4,
                FirstName = "Carlos",
                LastName = "Sainz",
                RaceNumber = 55,
                Nationality = "Spanish",
                CareerId = 4,
                TeamId = 1
            });

            modelBuilder.Entity<Career>().HasData(new Career(){
                CareerId = 1,
                Wins = 2,
                Poles = 7,
                FastestLaps = 4,
                DriverChampionships = 0
            });

            modelBuilder.Entity<Career>().HasData(new Career(){
                CareerId = 2,
                Wins = 0,
                Poles = 0,
                FastestLaps = 2,
                DriverChampionships = 0
            });

            modelBuilder.Entity<Career>().HasData(new Career(){
                CareerId = 3,
                Wins = 53,
                Poles = 57,
                FastestLaps = 38,
                DriverChampionships = 4
            });

            modelBuilder.Entity<Career>().HasData(new Career(){
                CareerId = 4,
                Wins = 0,
                Poles = 0,
                FastestLaps = 1,
                DriverChampionships = 0
            });

        }

    }
}
