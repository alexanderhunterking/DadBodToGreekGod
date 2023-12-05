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

    // DbSet properties for the existing and new entities
    public DbSet<MacroEntity> Macros { get; set; } = null!;
    public DbSet<MealEntity> Meals { get; set; } = null!;
    public DbSet<IngredientEntity> Ingredients { get; set; } = null!;
    public DbSet<MealIngredientEntity> MealIngredients { get; set; } = null!;
    public DbSet<CalendarEntity> Calendars { get; set; } = null!;
    public DbSet<ShoppingListEntity> ShoppingLists { get; set; } = null!;
    public DbSet<UserMealAssignmentEntity> UserMealAssignments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Update table names and relationships in the model
        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<MacroEntity>().HasIndex(e => e.UserId).IsUnique();

        // Add configurations for the new entities
        modelBuilder.Entity<MealEntity>().ToTable("Meals");
        modelBuilder.Entity<MealEntity>().HasIndex(e => e.UserId);
        modelBuilder.Entity<IngredientEntity>().ToTable("Ingredients");
        modelBuilder.Entity<MealIngredientEntity>().ToTable("MealIngredients");
        modelBuilder.Entity<CalendarEntity>().ToTable("Calendars");
        modelBuilder.Entity<ShoppingListEntity>().ToTable("ShoppingLists");
        modelBuilder.Entity<UserMealAssignmentEntity>().ToTable("UserMealAssignments");

        // Configure the relationships
        modelBuilder.Entity<UserMealAssignmentEntity>()
            .HasKey(uma => new { uma.UserMealAssignmentId, uma.UserId, uma.MealId });

        modelBuilder.Entity<UserMealAssignmentEntity>()
            .HasOne(uma => uma.User)
            .WithMany(user => user.UserMealAssignments)
            .HasForeignKey(uma => uma.UserId);

        modelBuilder.Entity<UserMealAssignmentEntity>()
            .HasOne(uma => uma.Meal)
            .WithMany(meal => meal.UserMealAssignments)
            .HasForeignKey(uma => uma.MealId);

        // Additional configurations and relationships can be added here
    }
}
}