using Microsoft.EntityFrameworkCore;

namespace MyWebApi.Models{
    public class MyWebApiContext : DbContext{
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) {}
        // up is constructor

        public DbSet<User> Users {get; set;} 
    }
}
