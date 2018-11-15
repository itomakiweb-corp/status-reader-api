using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class UserData : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
        public string AuthType { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }

    public static class UserAuthType
    {
        public static string Facebook { get; } = nameof(Facebook);
        public static string Google { get; } = nameof(Google);
        public static string Twitter { get; } = nameof(Twitter);
        public static string Itomaki { get; } = nameof(Itomaki);
    }

    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
        {

        }

        public DbSet<UserData> UserDatas { get; set; }

    }
}
