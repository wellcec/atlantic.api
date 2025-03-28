using Microsoft.EntityFrameworkCore;
using Atlantic.Api.Data.NotificationTemplatesContext.Entities;

namespace Atlantic.Api.Data.NotificationTemplatesContext
{
    public class NotificationTemplatesContext : DbContext
    {
        public NotificationTemplatesContext(DbContextOptions<NotificationTemplatesContext> options) : base(options) { }

        public DbSet<NotificationTemplateEntity> ststblwtpwpptemplates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<NotificationTemplateEntity>()
                .Property(e => e.wtpidttypentfcapi)
                .HasConversion<string>();

            modelBuilder.Entity<NotificationTemplateEntity>()
                .Property(n => n.hdrdthins)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );

            modelBuilder.Entity<NotificationTemplateEntity>()
                .Property(n => n.hdrdthhor)
                .HasConversion(
                    v => v,
                    v => DateTime.SpecifyKind(v, DateTimeKind.Utc)
                );
        }
    }
}
