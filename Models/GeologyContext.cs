using Microsoft.EntityFrameworkCore;
using System.Linq;
using Geology.Models; 

namespace Geology.Models
{
    public class GeologyContext : DbContext
    {
        
        public GeologyContext(DbContextOptions<GeologyContext> options) : base(options) { }
        public DbSet<User> users { get; set; }
        public DbSet<Rock> rocks { get; set; }
        public DbSet<Mineral> minerals { get; set; }
        public DbSet<RockHasMineral> rock_has_minerals { get; set; }
        public DbSet<Formula> chemical_formulas { get; set; }
        public DbSet<UserLikesMineral> users_like_minerals { get; set; }
    }
}