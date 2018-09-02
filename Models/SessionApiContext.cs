using Microsoft.EntityFrameworkCore;

namespace SessionApi.Models{
    public class SessionContext : DbContext{
        public SessionContext(DbContextOptions<SessionContext> options) : base(options) {}
        // up is constructor

        public DbSet<SessionContext> Sessions {get; set;} 
    }
}
