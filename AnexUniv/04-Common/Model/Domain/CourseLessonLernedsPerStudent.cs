using Common.CustomFilters;
using Model.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class CourseLessonLernedsPerStudent: AudityEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public LessonPerCourse Lesson { get; set; }
        public int LessonId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        public bool Deleted { get; set; }
    }
}
