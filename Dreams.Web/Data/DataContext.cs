using Dreams.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dreams.Web.Data
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<RecipeEntity> Recipes { get; set; }

        public DbSet<IngredientEntity> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductEntity>()
                .HasIndex(t => t.Code)
                .IsUnique();

        }


    }
}
