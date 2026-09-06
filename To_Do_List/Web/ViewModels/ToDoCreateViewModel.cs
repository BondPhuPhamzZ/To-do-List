using System.ComponentModel.DataAnnotations;

namespace To_Do_List.Web.ViewModels
{
    public class ToDoCreateViewModel
    {
        [Required(ErrorMessage = "Title cannot be empty!")]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
