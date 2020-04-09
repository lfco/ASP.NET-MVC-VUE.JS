using Common.CustomFilters;
using Model.Auth;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class CourseLessonLernedsPerStudent: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public LessonPerCourse Lesson { get; set; }
        [Required]
        public int LessonId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        public string UserId { get; set; }
        public bool Deleted { get; set; }
    }
}
