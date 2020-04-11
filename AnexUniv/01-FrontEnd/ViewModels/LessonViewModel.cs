using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ViewModels
{
    public class LessonCreateViewModel
    {
        [Required]
        public int CourseId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
