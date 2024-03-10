using Microsoft.AspNetCore.Mvc.Rendering;

namespace GoalTracker.Models.ViewModels
{
    public class GoalVM
    {
        public Goal Goal { get; set; }
        public IEnumerable<SelectListItem> StudentList { get; set; }
    }
}
