using Infrastructure.Ef.DbEntities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Ef;

public class GamerHistoryDatabaseContext : DbContext
{
    public GamerHistoryDatabaseContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<DbUser> Users { get; set; }
    public DbSet<DbGame> Games { get; set; }
    public DbSet<DbSession> Sessions { get; set; }
    public DbSet<DbSupport> Supports { get; set; }
    public DbSet<DbGameSession> GameSessions { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbUser>(entity =>
        {
            entity.ToTable("users");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnName("id");
            entity.Property(u => u.Pseudo).HasColumnName("pseudo");
            entity.Property(u => u.Email).HasColumnName("email");
            entity.Property(u => u.Password).HasColumnName("password");
            entity.Property(u => u.Role).HasColumnName("role");
        });

        modelBuilder.Entity<DbGame>(entity =>
        {
            entity.ToTable("games");
            entity.HasKey(g => g.Id).HasName("id");
            entity.Property(g => g.Name).HasColumnName("name");
            entity.Property(g => g.MinutesForCompletion).HasColumnName("minutes_for_completion");
            entity.Property(g => g.SupportId).HasColumnName("supportId");
            entity.HasOne(g => g.Support)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.SupportId);
        });

        modelBuilder.Entity<DbSession>(entity =>
        {
            entity.ToTable("sessions");
            entity.HasKey(s => s.Id).HasName("id");
            entity.Property(s => s.UserId).HasColumnName("user_id");
            entity.Property(s => s.StartTime).HasColumnName("start_date");
        });
        
        modelBuilder.Entity<DbSupport>(entity =>
        {
            entity.ToTable("supports");
            entity.HasKey(s => s.Id).HasName("id");
            entity.Property(s => s.Name).HasColumnName("name");
        });
        
        modelBuilder.Entity<DbGameSession>(entity =>
        {
            entity.ToTable("game_sessions");
            entity.HasKey(s => s.Id).HasName("id");
            entity.Property(s => s.GameTimeMin).HasColumnName("gametime_min");
            entity.Property(s => s.UserId).HasColumnName("user_id");
            entity.Property(s => s.GameId).HasColumnName("game_id");
            entity.Property(s => s.SessionDateTime).HasColumnName("session_datetime");
            entity.HasOne(gs => gs.Game)
                .WithMany()
                .HasForeignKey(gs => gs.GameId);
        });
    }
}