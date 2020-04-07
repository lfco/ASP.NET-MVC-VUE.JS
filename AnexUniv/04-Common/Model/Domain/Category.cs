﻿using Common.CustomFilters;
using Model.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Domain
{
    public class Category : AuditEntity, ISoftDeleted
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Slug { get; set; }
        [Required]
        public string Icon { get; set; }
        public bool Deleted { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
