using Common;
using Common.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class LessonPerCourse: AudityEntity, ISoftDeleted
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public string Video { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public bool Deleted { get; set; }
    }
}
