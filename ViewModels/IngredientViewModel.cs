using System.ComponentModel.DataAnnotations;

namespace RecipeJourneyRa.ViewModels
{
    public class IngredientViewModel
    {
        public int Id { get; set; }
        [Required]
        public int RecipeId { get; set; }

        [Required]
        public string IngredientName { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}

