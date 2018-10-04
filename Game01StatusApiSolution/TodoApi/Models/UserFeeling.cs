using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class UserFeeling
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string IssuedTime { get; set; }
    }

    public class UserFeelingContext : DbContext
    {
        public UserFeelingContext(DbContextOptions<UserFeelingContext> options) : base(options)
        {

        }

        public DbSet<UserFeeling> UserFeelings { get; set; }
    }
}
