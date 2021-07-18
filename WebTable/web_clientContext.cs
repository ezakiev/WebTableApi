using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebTable
{
    public partial class web_clientContext : DbContext
    {
        public web_clientContext()
        {
        }

        public web_clientContext(DbContextOptions<web_clientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Server=PostgreSQL.postgres.database.azure.com;Database=web_client;Host=localhost;Port=5432;User Id=postgres;Password=ZaEmRa2000");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.HasIndex(e => e.Email, "unique_email")
                    .IsUnique();

                entity.HasIndex(e => e.Nickname, "unique_nickname")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .UseIdentityAlwaysColumn();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.LastActivityDate)
                    .HasColumnType("date")
                    .HasColumnName("last_activity_date");

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .HasColumnName("middle_name");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("name");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("nickname");

                entity.Property(e => e.RegistrationDate)
                    .HasColumnType("date")
                    .HasColumnName("registration_date");

                entity.Property(e => e.Sername)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("sername");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
