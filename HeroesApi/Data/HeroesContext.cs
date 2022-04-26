using HeroesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Data
{
    public class HeroesContext : DbContext
    {
        public HeroesContext(DbContextOptions<HeroesContext> opt) : base (opt)
        {

        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
