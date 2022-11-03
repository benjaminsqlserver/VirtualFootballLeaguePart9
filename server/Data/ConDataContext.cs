using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using VirtualLeague.Models.ConData;

namespace VirtualLeague.Data
{
  public partial class ConDataContext : Microsoft.EntityFrameworkCore.DbContext
  {
    public ConDataContext(DbContextOptions<ConDataContext> options):base(options)
    {
    }

    public ConDataContext()
    {
    }

    partial void OnModelBuilding(ModelBuilder builder);

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<VirtualLeague.Models.ConData.FixtureGenerator>().HasNoKey();
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>().HasNoKey();
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserLogin>().HasKey(table => new {
          table.LoginProvider, table.ProviderKey
        });
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserRole>().HasKey(table => new {
          table.UserId, table.RoleId
        });
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserToken>().HasKey(table => new {
          table.UserId, table.LoginProvider, table.Name
        });
        builder.Entity<VirtualLeague.Models.ConData.AspNetRoleClaim>()
              .HasOne(i => i.AspNetRole)
              .WithMany(i => i.AspNetRoleClaims)
              .HasForeignKey(i => i.RoleId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserClaim>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserClaims)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserLogin>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserLogins)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserRole>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserRoles)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserRole>()
              .HasOne(i => i.AspNetRole)
              .WithMany(i => i.AspNetUserRoles)
              .HasForeignKey(i => i.RoleId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.AspNetUserToken>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.AspNetUserTokens)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .HasOne(i => i.LeagueSeason)
              .WithMany(i => i.SeasonFixtures)
              .HasForeignKey(i => i.SeasonID)
              .HasPrincipalKey(i => i.SeasonID);
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .HasOne(i => i.MatchDay)
              .WithMany(i => i.SeasonFixtures)
              .HasForeignKey(i => i.MatchDayID)
              .HasPrincipalKey(i => i.MatchDayID);
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .HasOne(i => i.Team)
              .WithMany(i => i.SeasonFixtures)
              .HasForeignKey(i => i.HomeTeamID)
              .HasPrincipalKey(i => i.TeamID);
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .HasOne(i => i.Team1)
              .WithMany(i => i.SeasonFixtures1)
              .HasForeignKey(i => i.AwayTeamID)
              .HasPrincipalKey(i => i.TeamID);
        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .HasOne(i => i.AspNetUser)
              .WithMany(i => i.SeasonFixtures)
              .HasForeignKey(i => i.UserId)
              .HasPrincipalKey(i => i.Id);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.LeagueSeason)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.SeasonID)
              .HasPrincipalKey(i => i.SeasonID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.MatchDay)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.MatchDayID)
              .HasPrincipalKey(i => i.MatchDayID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.Team)
              .WithMany(i => i.VirtualLeagueResults)
              .HasForeignKey(i => i.HomeTeamID)
              .HasPrincipalKey(i => i.TeamID);
        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .HasOne(i => i.Team1)
              .WithMany(i => i.VirtualLeagueResults1)
              .HasForeignKey(i => i.AwayTeamID)
              .HasPrincipalKey(i => i.TeamID);


        builder.Entity<VirtualLeague.Models.ConData.DeviceCode>()
              .Property(p => p.CreationTime)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.DeviceCode>()
              .Property(p => p.Expiration)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.Key>()
              .Property(p => p.Created)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.PersistedGrant>()
              .Property(p => p.CreationTime)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.PersistedGrant>()
              .Property(p => p.Expiration)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.PersistedGrant>()
              .Property(p => p.ConsumedTime)
              .HasColumnType("datetime2");

        builder.Entity<VirtualLeague.Models.ConData.AspNetRoleClaim>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.AspNetUser>()
              .Property(p => p.AccessFailedCount)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.AspNetUserClaim>()
              .Property(p => p.Id)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.FixtureGenerator>()
              .Property(p => p.TemplateID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.FixtureTemplate>()
              .Property(p => p.TemplateID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.Key>()
              .Property(p => p.Version)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.LeagueSeason>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.MatchDay>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .Property(p => p.FixtureID)
              .HasPrecision(19, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .Property(p => p.HomeTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixture>()
              .Property(p => p.AwayTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.FixtureID)
              .HasPrecision(19, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.HomeTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.AwayTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.SeasonFixturesList>()
              .Property(p => p.Played)
              .HasPrecision(1, 0);

        builder.Entity<VirtualLeague.Models.ConData.Team>()
              .Property(p => p.TeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.RecordID)
              .HasPrecision(19, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.SeasonID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.MatchDayID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.HomeTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.HomeScore)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.AwayTeamID)
              .HasPrecision(10, 0);

        builder.Entity<VirtualLeague.Models.ConData.VirtualLeagueResult>()
              .Property(p => p.AwayScore)
              .HasPrecision(10, 0);
        this.OnModelBuilding(builder);
    }


    public DbSet<VirtualLeague.Models.ConData.AspNetRole> AspNetRoles
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetRoleClaim> AspNetRoleClaims
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetUser> AspNetUsers
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetUserClaim> AspNetUserClaims
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetUserLogin> AspNetUserLogins
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetUserRole> AspNetUserRoles
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.AspNetUserToken> AspNetUserTokens
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.DeviceCode> DeviceCodes
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.FixtureGenerator> FixtureGenerators
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.FixtureTemplate> FixtureTemplates
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.Key> Keys
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.LeagueSeason> LeagueSeasons
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.MatchDay> MatchDays
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.PersistedGrant> PersistedGrants
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.SeasonFixture> SeasonFixtures
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.SeasonFixturesList> SeasonFixturesLists
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.Team> Teams
    {
      get;
      set;
    }

    public DbSet<VirtualLeague.Models.ConData.VirtualLeagueResult> VirtualLeagueResults
    {
      get;
      set;
    }
  }
}
