using System.ComponentModel;

namespace RecipeJourneyRa.Data.Enum
{
    public enum RecipeCategory
    {
        Desserts,
        [Description("Main Course")]
        MainCourse,
        Salads,
    }    
}