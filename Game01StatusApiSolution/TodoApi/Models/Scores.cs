using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class Scores
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string IssuedTime { get; set; }
    }

    public class ScoresContext : DbContext
    {
        public ScoresContext(DbContextOptions<ScoresContext> options) : base(options)
        {

        }

        public DbSet<Scores> Scores { get; set; }
    }
}
