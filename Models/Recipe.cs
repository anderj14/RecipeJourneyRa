using RecipeJourneyRa.Data.Enum;

namespace RecipeJourneyRa.Models
{
    public class Recipe: BaseEntity
    {
        public DateTime CreatedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string PictureUrl { get; set; }

        public RecipeCategory RecipeCategory { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
    }
}