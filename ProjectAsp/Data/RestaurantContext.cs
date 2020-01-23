using Microsoft.EntityFrameworkCore;
using ProjectAsp.Models;

namespace ProjectAsp.Db
{
    public class RestaurantContext : DbContext
    {
        public string connexionString;

        public RestaurantContext()
        {
            this.connexionString = @"Server=localhost\\SQLEXPRESS;Database=ProjetAsp;Trusted_Connection=True;";
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Adresse> Adresses { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
