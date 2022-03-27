using FinancialChat.Domain.Entities;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace FinancialChat.Infrastructure.Context
{
    public partial class FinancialChatDBContext : DbContext
    {
        public FinancialChatDBContext(DbContextOptions<FinancialChatDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MessageChat> Messages { get; set; }
        public virtual DbSet<UserIdentity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageChat>(entity =>
            {
                entity.ToTable("MessageChat");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserIdentity>(entity =>
            {
                entity.ToTable("UserIdentity");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Name).HasMaxLength(20);

                entity.Property(e => e.Password).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
