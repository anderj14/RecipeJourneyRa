using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeJourneyRa.Models
{
    public class Instruction : BaseEntity
    {
        public int StepNumber { get; set; }
        public string Description { get; set; }
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}