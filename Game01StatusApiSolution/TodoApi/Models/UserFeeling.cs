using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    public class UserFeeling
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public int elapsedMilliSec { get; set; }
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
