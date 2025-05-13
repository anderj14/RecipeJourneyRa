using RecipeJourneyRa.Data.Enum;

namespace RecipeJourneyRa.ViewModels
{
    public class CreateRecipeViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Title { get; set; }
        public string Description { get; set; }
        public int PreparationTime { get; set; }
        public int CookingTime { get; set; }
        public string DifficultyLevel { get; set; }
        public string PictureUrl { get; set; }

        public RecipeCategory RecipeCategory { get; set; }
    }
}