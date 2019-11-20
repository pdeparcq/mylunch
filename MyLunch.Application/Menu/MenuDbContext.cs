﻿using Microsoft.EntityFrameworkCore;
using MyLunch.Application.Menu.Entities;

namespace MyLunch.Application.Menu
{
    public class MenuDbContext : DbContext
    {
        public MenuDbContext(DbContextOptions<MenuDbContext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Entities.Menu> Menus { get; set; }
        public DbSet<MenuGroup> MenuGroups { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Menus).WithOne(m => m.Restaurant).HasForeignKey(m => m.RestaurantId);

            modelBuilder.Entity<Entities.Menu>()
                .HasMany(m => m.Groups).WithOne(g => g.Menu).HasForeignKey(g => g.MenuId);

            modelBuilder.Entity<MenuGroup>()
                .HasMany(g => g.Items).WithOne(i => i.MenuGroup).HasForeignKey(g => g.MenuGroupId);
        }
    }
}
