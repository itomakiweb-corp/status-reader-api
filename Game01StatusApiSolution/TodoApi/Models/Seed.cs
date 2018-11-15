using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Seed : BaseEntity
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public long Id { get; set; }
        public string SeedType { get; set; }
        public string SeedTitle { get; set; }
        public string SeedUrl { get; set; }
        public string KeySteries { get; set; }
        public int InputStartTime { get; set; } = 5;
        public int InputEndTime { get; set; }
        //public string CreateTime { get; set; }
        //public string UpdateTime { get; set; }
        //[ForeignKey("UserData")]
        public string UploadUserId { get; set; }
        public string UploadUserName { get; set; }
        public int ReadUserCount { get; set; }


    }

    public static class SeedType
    {
        public static string Youtube { get; } = nameof(Youtube);
    }

    public class SeedContext : DbContext
    {
        public SeedContext(DbContextOptions<SeedContext> options) : base(options)
        {

        }

        public DbSet<Seed> Seeds { get; set; }

    }
}
