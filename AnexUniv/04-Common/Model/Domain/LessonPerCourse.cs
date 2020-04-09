using Common;
using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class LessonPerCourse: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Content { get; set; }
        public string Video { get; set; }

        [Required]
        public Course Course { get; set; }
        [Required]
        public int CourseId { get; set; }
        public bool Deleted { get; set; }
    }
}
