using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class UserData
    {
        public long Id { get; set; }
        public string UserName { get; set; }
    }

    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {

        }

        public DbSet<UserData> UserDatas { get; set; }
    }
}
