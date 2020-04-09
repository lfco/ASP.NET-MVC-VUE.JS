using Common;
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
    public class Course: AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Slug { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public  Enums.Status Status { get; set; }
        public decimal Vote { get; set; }

        public Category Category { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public ICollection<LessonPerCourse> Lessons { get; set; }

        [ForeignKey("UserAuthorId")]
        public ApplicationUser AuthorId { get; set; }
        public string UserAuthorId { get; set; }
        public bool Deleted { get; set; }
    }
}
