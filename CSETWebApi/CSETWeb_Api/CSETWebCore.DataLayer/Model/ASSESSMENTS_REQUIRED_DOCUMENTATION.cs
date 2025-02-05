﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSETWebCore.DataLayer.Model
{
    public partial class ASSESSMENTS_REQUIRED_DOCUMENTATION
    {
        [Key]
        public int Assessment_Id { get; set; }
        [Key]
        public int Documentation_Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Answer { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string Comment { get; set; }

        [ForeignKey("Assessment_Id")]
        [InverseProperty("ASSESSMENTS_REQUIRED_DOCUMENTATION")]
        public virtual ASSESSMENTS Assessment { get; set; }
        [ForeignKey("Documentation_Id")]
        [InverseProperty("ASSESSMENTS_REQUIRED_DOCUMENTATION")]
        public virtual REQUIRED_DOCUMENTATION Documentation { get; set; }
    }
}