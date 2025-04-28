using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeJourneyRa.Models
{
    public class Ingredient : BaseEntity
    {
        public string IngredientName { get; set; }
        public string Quantity { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}