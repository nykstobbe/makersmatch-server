using makersmatch_server.Authentication;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace makersmatch_server.Data
{
    public class MakersMatchContext : IdentityDbContext<ApplicationUser>
    {
        public MakersMatchContext(DbContextOptions<MakersMatchContext> options) : base(options) 
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ChatMessage>()
                .Property(s => s.CreatedDate)
                .HasDefaultValueSql("GETDATE()");

            base.OnModelCreating(builder);
        }

        public DbSet<Problem> Problems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }

    }
}
