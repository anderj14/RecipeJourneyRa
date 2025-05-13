using Microsoft.AspNetCore.Mvc;
using RecipeJourneyRa.Interfaces;
using RecipeJourneyRa.Models;
using RecipeJourneyRa.ViewModels;

namespace RecipeJourneyRa.Controllers
{
    public class RecipeController(
        IGenericRepository<Recipe> recipeRepo,
        IGenericRepository<Ingredient> ingredientRepo,
        IGenericRepository<Instruction> instructionRepo
            ) : Controller
    {
        private readonly IGenericRepository<Recipe> _recipeRepo = recipeRepo;
        private readonly IGenericRepository<Ingredient> _ingredientRepo = ingredientRepo;
        private readonly IGenericRepository<Instruction> _instructionRepo = instructionRepo;

        public async Task<IActionResult> Index()
        {
            IReadOnlyList<Recipe> recipes = await _recipeRepo.GetAllAsync();
            return View(recipes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Recipe recipe = await _recipeRepo.GetByIdWithIncludesAsync(
                id,
                r => r.Ingredients,
                r => r.Instructions
            );
            return View(recipe);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateRecipeViewModel recipeVM)
        {
            if (ModelState.IsValid)
            {
                var recipe = new Recipe
                {
                    CreatedDate = recipeVM.CreatedDate,
                    Title = recipeVM.Title,
                    Description = recipeVM.Description,
                    PreparationTime = recipeVM.PreparationTime,
                    CookingTime = recipeVM.CookingTime,
                    DifficultyLevel = recipeVM.DifficultyLevel,
                    PictureUrl = recipeVM.PictureUrl,
                    RecipeCategory = recipeVM.RecipeCategory
                };

                await _recipeRepo.Create(recipe);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Invalid model state");
            }
            return View(recipeVM);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Recipe recipe = await _recipeRepo.GetByIdWithIncludesAsync(id, r => r.Ingredients, r => r.Instructions);

            if (recipe == null)
            {
                return View("Error");
            }
            var recipeVM = new EditRecipeViewModel
            {
                Id = recipe.Id,
                CreatedDate = recipe.CreatedDate,
                Title = recipe.Title,
                Description = recipe.Description,
                PreparationTime = recipe.PreparationTime,
                CookingTime = recipe.CookingTime,
                DifficultyLevel = recipe.DifficultyLevel,
                PictureUrl = recipe.PictureUrl,
                RecipeCategory = recipe.RecipeCategory,
                Ingredients = recipe.Ingredients.Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    RecipeId = i.RecipeId,
                    IngredientName = i.IngredientName,
                    Quantity = i.Quantity
                }).ToList(),
                Instructions = recipe.Instructions.Select(i => new InstructionViewModel
                {
                    Id = i.Id,
                    RecipeId = i.RecipeId,
                    StepNumber = i.StepNumber,
                    Description = i.Description
                }).ToList()
            };
            return View(recipeVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditRecipeViewModel recipeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit club");
                return View("Edit", recipeVM);
            }
            Recipe recipe = await _recipeRepo.GetByIdWithIncludesAsync(id, r => r.Ingredients);
            if (recipe == null)
            {
                return View("Error");
            }

            recipe.Title = recipeVM.Title;
            recipe.Description = recipeVM.Description;
            recipe.PreparationTime = recipeVM.PreparationTime;
            recipe.CookingTime = recipeVM.CookingTime;
            recipe.DifficultyLevel = recipeVM.DifficultyLevel;
            recipe.PictureUrl = recipeVM.PictureUrl;
            recipe.CreatedDate = recipeVM.CreatedDate;

            await _recipeRepo.Update(recipe);
            return RedirectToAction("Edit");
        }

        [HttpPost]
        public async Task<ActionResult> UpsertIngredient(IngredientViewModel ingredientVM)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { id = ingredientVM.RecipeId });

            if (ingredientVM.Id == 0)
            {
                var ingredient = new Ingredient
                {
                    IngredientName = ingredientVM.IngredientName,
                    Quantity = ingredientVM.Quantity,
                    RecipeId = ingredientVM.RecipeId
                };

                await _ingredientRepo.Create(ingredient);
            }
            else
            {
                var ingredient = await _ingredientRepo.GetByIdAsync(ingredientVM.Id);
                if (ingredient == null) return NotFound();

                ingredient.IngredientName = ingredientVM.IngredientName;
                ingredient.Quantity = ingredientVM.Quantity;

                await _ingredientRepo.Update(ingredient);
            }
            return RedirectToAction("Edit", new { id = ingredientVM.RecipeId });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteIngredient(int id, int recipeId)
        {
            var ingredient = await _ingredientRepo.GetByIdAsync(id);
            if (ingredient != null)
                await _ingredientRepo.Delete(ingredient);
            return RedirectToAction("Edit", new { id = recipeId });
        }

        [HttpPost]
        public async Task<IActionResult> UpsertInstruction(InstructionViewModel instructionVM)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { id = instructionVM.RecipeId });

            if (instructionVM.Id == 0)
            {
                var instruction = new Instruction
                {
                    StepNumber = instructionVM.StepNumber,
                    Description = instructionVM.Description,
                    RecipeId = instructionVM.RecipeId
                };

                await _instructionRepo.Create(instruction);
            }
            else
            {
                var instruction = await _instructionRepo.GetByIdAsync(instructionVM.Id);
                if (instruction == null) return NotFound();

                instruction.StepNumber = instructionVM.StepNumber;
                instruction.Description = instructionVM.Description;

                await _instructionRepo.Update(instruction);
            }
            return RedirectToAction("Edit", new { id = instructionVM.RecipeId });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteInstruction(int id, int recipeId)
        {
            var instruction = await _instructionRepo.GetByIdAsync(id);
            if (instruction != null) await _instructionRepo.Delete(instruction);
            return RedirectToAction("Edit", new { id = recipeId });
        }
    }
}