using DadBodToGreekGod.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DadBodToGreekGod.Data
{
public class ApplicationDbContext : IdentityDbContext<UserEntity, IdentityRole<int>, int>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // DbSet properties for the existing and new entities
    public DbSet<MacroEntity> Macros { get; set; } = null!;
    public DbSet<MealEntity> Meals { get; set; } = null!;
    public DbSet<IngredientEntity> Ingredients { get; set; } = null!;
    public DbSet<MealIngredientEntity> MealIngredients { get; set; } = null!;
    public DbSet<CalendarWeekEntity> CalendarWeeks { get; set; } = null!;
    public DbSet<CalendarDayEntity> CalendarDays { get; set; } = null!;
    public DbSet<ShoppingListEntity> ShoppingLists { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Update table names and relationships in the model
        modelBuilder.Entity<UserEntity>().ToTable("Users");
        modelBuilder.Entity<UserEntity>().Property(u => u.FirstName).HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().Property(u => u.LastName).HasMaxLength(100);
        modelBuilder.Entity<UserEntity>().Property(u => u.DateCreated).IsRequired();

        modelBuilder.Entity<MacroEntity>().HasIndex(e => e.UserId).IsUnique();

        // Add configurations for the new entities
        modelBuilder.Entity<MealEntity>().ToTable("Meals");
        modelBuilder.Entity<MealEntity>().HasIndex(e => e.UserId);
        
        modelBuilder.Entity<MealEntity>()
            .HasMany(meal => meal.MealIngredients)
            .WithOne(mealIngredient => mealIngredient.Meal)
            .HasForeignKey(mealIngredient => mealIngredient.MealId)
            .OnDelete(DeleteBehavior.Cascade); // Enable cascading delete

        modelBuilder.Entity<IngredientEntity>().ToTable("Ingredients");
        modelBuilder.Entity<MealIngredientEntity>().ToTable("MealIngredients");
        modelBuilder.Entity<MealIngredientEntity>().HasIndex(e => e.UserId);
        
        modelBuilder.Entity<CalendarWeekEntity>().ToTable("CalendarWeeks");
        modelBuilder.Entity<CalendarDayEntity>().ToTable("CalendarDays");

        modelBuilder.Entity<ShoppingListEntity>().ToTable("ShoppingLists");
        modelBuilder.Entity<ShoppingListEntity>().HasIndex(e => e.UserId);
        

        // Seed ingredients
        SeedIngredients(modelBuilder);

        // Additional configurations and relationships can be added here
    }

        private static void SeedIngredients(ModelBuilder modelBuilder)
        {
            var ingredients = new List<IngredientEntity>
        {
            new IngredientEntity
            {
                IngredientId = 100,
                Name = "Chicken Breast",
                CaloriesPer100g = 165,
                ProteinPer100g = 31,
                CarbsPer100g = 0,
                FatPer100g = 3.6
            },
            new IngredientEntity
            {
                IngredientId = 2,
                Name = "Ground Beef",
                CaloriesPer100g = 250,
                ProteinPer100g = 26,
                CarbsPer100g = 0,
                FatPer100g = 17
            },
             new IngredientEntity
    {
        IngredientId = 3,
        Name = "Salmon",
        CaloriesPer100g = 206,
        ProteinPer100g = 25,
        CarbsPer100g = 0,
        FatPer100g = 13
    },
    new IngredientEntity
    {
        IngredientId = 4,
        Name = "Broccoli",
        CaloriesPer100g = 55,
        ProteinPer100g = 3.7,
        CarbsPer100g = 11,
        FatPer100g = 0.6
    },
    new IngredientEntity
    {
        IngredientId = 5,
        Name = "Spinach",
        CaloriesPer100g = 23,
        ProteinPer100g = 2.9,
        CarbsPer100g = 3.6,
        FatPer100g = 0.4
    },
    new IngredientEntity
    {
        IngredientId = 6,
        Name = "Sweet Potato",
        CaloriesPer100g = 86,
        ProteinPer100g = 1.6,
        CarbsPer100g = 20.1,
        FatPer100g = 0.1
    },
       new IngredientEntity
{
    IngredientId = 7,
    Name = "White Rice",
    CaloriesPer100g = 130,
    ProteinPer100g = 2.7,
    CarbsPer100g = 28,
    FatPer100g = 0.2
},
new IngredientEntity
{
    IngredientId = 104,
    Name = "Turkey Breast",
    CaloriesPer100g = 135,
    ProteinPer100g = 29,
    CarbsPer100g = 0,
    FatPer100g = 1
},
new IngredientEntity
{
    IngredientId = 105,
    Name = "Steak",
    CaloriesPer100g = 250,
    ProteinPer100g = 26,
    CarbsPer100g = 0,
    FatPer100g = 17
},
new IngredientEntity
{
    IngredientId = 106,
    Name = "Pork Chops",
    CaloriesPer100g = 143,
    ProteinPer100g = 21,
    CarbsPer100g = 0,
    FatPer100g = 7
},
new IngredientEntity
{
    IngredientId = 107,
    Name = "Cod",
    CaloriesPer100g = 82,
    ProteinPer100g = 18,
    CarbsPer100g = 0,
    FatPer100g = 1
},
new IngredientEntity
{
    IngredientId = 108,
    Name = "Tuna",
    CaloriesPer100g = 116,
    ProteinPer100g = 25,
    CarbsPer100g = 0,
    FatPer100g = 1
},
new IngredientEntity
{
    IngredientId = 109,
    Name = "Tilapia",
    CaloriesPer100g = 96,
    ProteinPer100g = 21,
    CarbsPer100g = 0,
    FatPer100g = 1.7
},
new IngredientEntity
{
    IngredientId = 110,
    Name = "Cottage Cheese",
    CaloriesPer100g = 98,
    ProteinPer100g = 11,
    CarbsPer100g = 3.4,
    FatPer100g = 4.3
},
new IngredientEntity
{
    IngredientId = 111,
    Name = "Tofu",
    CaloriesPer100g = 144,
    ProteinPer100g = 15,
    CarbsPer100g = 3.9,
    FatPer100g = 8
},
new IngredientEntity
{
    IngredientId = 200,
    Name = "Greek Yogurt",
    CaloriesPer100g = 59,
    ProteinPer100g = 10,
    CarbsPer100g = 3.6,
    FatPer100g = 0.4
},
new IngredientEntity
{
    IngredientId = 112,
    Name = "Canned Tuna",
    CaloriesPer100g = 109,
    ProteinPer100g = 24,
    CarbsPer100g = 0,
    FatPer100g = 1
},
new IngredientEntity
{
    IngredientId = 201,
    Name = "Black Beans",
    CaloriesPer100g = 132,
    ProteinPer100g = 8.9,
    CarbsPer100g = 23.7,
    FatPer100g = 0.5
},
new IngredientEntity
{
    IngredientId = 113,
    Name = "Black Beans",
    CaloriesPer100g = 132,
    ProteinPer100g = 8.9,
    CarbsPer100g = 23.7,
    FatPer100g = 0.5
},
new IngredientEntity
{
    IngredientId = 115,
    Name = "Shrimp",
    CaloriesPer100g = 85,
    ProteinPer100g = 20,
    CarbsPer100g = 0,
    FatPer100g = 1.2
},
new IngredientEntity
{
    IngredientId = 116,
    Name = "Whole Milk",
    CaloriesPer100g = 61,
    ProteinPer100g = 3.2,
    CarbsPer100g = 4.8,
    FatPer100g = 3.7
},
new IngredientEntity
{
    IngredientId = 101,
    Name = "Quinoa",
    CaloriesPer100g = 120,
    ProteinPer100g = 4,
    CarbsPer100g = 21,
    FatPer100g = 1.9
},
new IngredientEntity
{
    IngredientId = 102,
    Name = "Quinoa",
    CaloriesPer100g = 120,
    ProteinPer100g = 4,
    CarbsPer100g = 21,
    FatPer100g = 1.9
},
new IngredientEntity
{
    IngredientId = 118,
    Name = "Mozzarella Cheese",
    CaloriesPer100g = 318,
    ProteinPer100g = 22,
    CarbsPer100g = 1.6,
    FatPer100g = 25
},
new IngredientEntity
{
    IngredientId = 119,
    Name = "Cheddar Cheese",
    CaloriesPer100g = 403,
    ProteinPer100g = 25,
    CarbsPer100g = 1.3,
    FatPer100g = 33
},
new IngredientEntity
{
    IngredientId = 120,
    Name = "Colby Jack Cheese",
    CaloriesPer100g = 389,
    ProteinPer100g = 23,
    CarbsPer100g = 2.6,
    FatPer100g = 32
},
new IngredientEntity
{
    IngredientId = 121,
    Name = "Almonds",
    CaloriesPer100g = 576,
    ProteinPer100g = 21,
    CarbsPer100g = 22,
    FatPer100g = 49
},
new IngredientEntity
{
    IngredientId = 122,
    Name = "Eggs",
    CaloriesPer100g = 143,
    ProteinPer100g = 13,
    CarbsPer100g = 1.1,
    FatPer100g = 9.5
},
new IngredientEntity
{
    IngredientId = 123,
    Name = "Brown Rice",
    CaloriesPer100g = 111,
    ProteinPer100g = 2.6,
    CarbsPer100g = 23.5,
    FatPer100g = 0.9
},
new IngredientEntity
{
    IngredientId = 124,
    Name = "Potatoes",
    CaloriesPer100g = 77,
    ProteinPer100g = 2,
    CarbsPer100g = 17,
    FatPer100g = 0.1
},
new IngredientEntity
{
    IngredientId = 125,
    Name = "Oatmeal",
    CaloriesPer100g = 68,
    ProteinPer100g = 2.4,
    CarbsPer100g = 12,
    FatPer100g = 1.4
},
new IngredientEntity
{
    IngredientId = 126,
    Name = "Brussels Sprouts",
    CaloriesPer100g = 43,
    ProteinPer100g = 3.4,
    CarbsPer100g = 8.3,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 127,
    Name = "Kale",
    CaloriesPer100g = 49,
    ProteinPer100g = 4.3,
    CarbsPer100g = 8.8,
    FatPer100g = 0.9
},
new IngredientEntity
{
    IngredientId = 128,
    Name = "Cauliflower",
    CaloriesPer100g = 25,
    ProteinPer100g = 1.9,
    CarbsPer100g = 5,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 129,
    Name = "Blackberries",
    CaloriesPer100g = 43,
    ProteinPer100g = 2,
    CarbsPer100g = 10,
    FatPer100g = 0.5
},
new IngredientEntity
{
    IngredientId = 130,
    Name = "Green Beans",
    CaloriesPer100g = 31,
    ProteinPer100g = 1.8,
    CarbsPer100g = 7,
    FatPer100g = 0.2
},
new IngredientEntity
{
    IngredientId = 131,
    Name = "Bananas",
    CaloriesPer100g = 89,
    ProteinPer100g = 1.1,
    CarbsPer100g = 23,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 132,
    Name = "Strawberries",
    CaloriesPer100g = 32,
    ProteinPer100g = 0.7,
    CarbsPer100g = 8,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 133,
    Name = "Raspberries",
    CaloriesPer100g = 52,
    ProteinPer100g = 1.2,
    CarbsPer100g = 11,
    FatPer100g = 0.7
},
new IngredientEntity
{
    IngredientId = 134,
    Name = "Pineapple",
    CaloriesPer100g = 50,
    ProteinPer100g = 0.5,
    CarbsPer100g = 13,
    FatPer100g = 0.1
},
new IngredientEntity
{
    IngredientId = 135,
    Name = "Blueberries",
    CaloriesPer100g = 57,
    ProteinPer100g = 0.7,
    CarbsPer100g = 14,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 136,
    Name = "Carrots",
    CaloriesPer100g = 41,
    ProteinPer100g = 0.9,
    CarbsPer100g = 10,
    FatPer100g = 0.2
},
new IngredientEntity
{
    IngredientId = 137,
    Name = "Tomatoes",
    CaloriesPer100g = 18,
    ProteinPer100g = 0.9,
    CarbsPer100g = 3.9,
    FatPer100g = 0.2
},
new IngredientEntity
{
    IngredientId = 138,
    Name = "Bell Peppers",
    CaloriesPer100g = 31,
    ProteinPer100g = 1,
    CarbsPer100g = 6,
    FatPer100g = 0.3
},
new IngredientEntity
{
    IngredientId = 139,
    Name = "Avocado",
    CaloriesPer100g = 160,
    ProteinPer100g = 2,
    CarbsPer100g = 8.5,
    FatPer100g = 14.7
},

        };

            modelBuilder.Entity<IngredientEntity>().HasData(ingredients);
        }
    }
}
