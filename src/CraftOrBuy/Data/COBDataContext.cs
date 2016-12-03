using CraftOrBuy.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CraftOrBuy.Data
{
    public class COBDataContext : DbContext
    {
        public COBDataContext(DbContextOptions<COBDataContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
