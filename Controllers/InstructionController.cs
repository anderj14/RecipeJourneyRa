using Microsoft.AspNetCore.Mvc;
using RecipeJourneyRa.Interfaces;
using RecipeJourneyRa.Models;

namespace RecipeJourneyRa.Controllers
{
    public class InstrictionController : Controller
    {
        private readonly IGenericRepository<Instruction> _recipeInstruction;

        public InstrictionController(IGenericRepository<Instruction> recipeInstruction)
        {
            _recipeInstruction = recipeInstruction;
        }

        public async Task<IActionResult> Index()
        {
            IReadOnlyList<Instruction> instructions = await _recipeInstruction.GetAllAsync();
            return View(instructions);
        }
    }
}