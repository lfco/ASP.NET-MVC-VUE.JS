﻿using Model.Auth;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Helper
{
    public class AuditEntity
    {
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        [ForeignKey("CreatedBy")]
        public ApplicationUser CreatedUser { get; set; }

        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        [ForeignKey("UpdatedBy")]
        public ApplicationUser UpdatedUser { get; set; }

        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        [ForeignKey("DeletedBy")]
        public ApplicationUser DeletedUser { get; set; }
    }
}
