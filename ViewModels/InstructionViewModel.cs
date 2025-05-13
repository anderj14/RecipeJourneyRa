using System.ComponentModel.DataAnnotations;

namespace RecipeJourneyRa.ViewModels
{
    public class InstructionViewModel
    {
        public int Id { get; set; }
        [Required]
        public int RecipeId { get; set; }
        [Required]
        public int StepNumber { get; set; }
        [Required]
        public string Description { get; set; }
    }
}