using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class UserScore : BaseEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int CurrentScore { get; set; }
        public int TotalScore { get; set; }
        public int Rank { get; set; }
        //public string IssuedTime { get; set; }
    }

    public class ScoresContext : DbContext
    {
        public ScoresContext(DbContextOptions<ScoresContext> options) : base(options)
        {

        }

        public DbSet<UserScore> Scores { get; set; }
    }
}
