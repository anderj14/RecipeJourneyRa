using System.ComponentModel.DataAnnotations;

namespace RecipeJourneyRa.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}