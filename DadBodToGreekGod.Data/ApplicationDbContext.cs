using DadBodToGreekGod.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Data
{
   public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) {}

    public DbSet<MacroEntity> Macros { get; set; } = null!;
    public DbSet<MealEntity> Meals { get; set; } = null!;
    public DbSet<IngredientEntity> Ingredients { get; set; } = null!;
    public DbSet<MealIngredientEntity> MealIngredients { get; set; } = null!;
    public DbSet<CalendarEntity> Calendars { get; set; } = null!;
    public DbSet<ShoppingListEntity> ShoppingLists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Update table names and relationships in the model
        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<MacroEntity>().HasIndex(e => e.UserId).IsUnique();

        modelBuilder.Entity<MealEntity>().ToTable("Meals");
        modelBuilder.Entity<IngredientEntity>().ToTable("Ingredients");
        modelBuilder.Entity<MealIngredientEntity>().ToTable("MealIngredients");
        modelBuilder.Entity<CalendarEntity>().ToTable("Calendars");
        modelBuilder.Entity<ShoppingListEntity>().ToTable("ShoppingLists");

    }
}
}