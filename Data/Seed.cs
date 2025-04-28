using RecipeJourneyRa.Data.Enum;
using RecipeJourneyRa.Models;

namespace RecipeJourneyRa.Data
{
    public class Seed
    {
        public static void SeedData(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                context.Database.EnsureCreated();

                if (!context.Recipes.Any())
                {
                    var recipes = new List<Recipe>()
                    {
                        new()
                        {
                            CreatedDate = DateTime.Now,
                            Title = "Chocolate Cake",
                            Description = "Delicious chocolate cake with a rich flavor.",
                            PreparationTime = 30,
                            CookingTime = 60,
                            DifficultyLevel = "Medium",
                            PictureUrl = "https://images.pexels.com/photos/2955818/pexels-photo-2955818.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            RecipeCategory = RecipeCategory.Desserts,
                            Ingredients = new List<Ingredient>
                            {
                                new() { IngredientName = "Flour", Quantity = "2 cups" },
                                new() { IngredientName = "Sugar", Quantity = "1 cup" },
                                new() { IngredientName = "Eggs", Quantity = "3" }
                            },
                            Instructions = new List<Instruction>
                            {
                                new() { StepNumber = 1, Description = "Preheat the oven to 350°F (175°C)" },
                                new() { StepNumber = 2, Description = "Mix flour and sugar together" },
                                new() { StepNumber = 3, Description = "Add eggs and beat until smooth" }
                            }
                        },
                        new()
                        {
                            CreatedDate = DateTime.Now,
                            Title = "Grilled Chicken",
                            Description = "Juicy grilled chicken with herbs",
                            PreparationTime = 15,
                            CookingTime = 45,
                            DifficultyLevel = "Easy",
                            PictureUrl = "https://images.pexels.com/photos/105588/pexels-photo-105588.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1",
                            RecipeCategory = RecipeCategory.MainCourse,
                            Ingredients = new List<Ingredient>
                            {
                                new() { IngredientName = "Chicken breast", Quantity = "4 pieces" },
                                new() { IngredientName = "Olive oil", Quantity = "2 tbsp" }
                            },
                            Instructions = new List<Instruction>
                            {
                                new() { StepNumber = 1, Description = "Season chicken with herbs" },
                                new() { StepNumber = 2, Description = "Grill chicken for 15 minutes" }
                            }
                        }
                    };

                    context.Recipes.AddRange(recipes);
                    context.SaveChanges();
                }
            }
        }
    }
}