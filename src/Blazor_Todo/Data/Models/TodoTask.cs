using static Blazor_Todo.Components.Pages.Todo;
using System.ComponentModel.DataAnnotations;

namespace Blazor_Todo.Data.Models
{
    public class TodoTask
    {
        [Required(ErrorMessage = "Task name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Priority is required.")]
        public Priority? Priority { get; set; }

        [Required(ErrorMessage = "Due date is required.")]
        public DateTime? DueDate { get; set; }
    }
}
