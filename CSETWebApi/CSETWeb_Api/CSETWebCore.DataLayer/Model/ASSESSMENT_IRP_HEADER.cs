﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CSETWebCore.DataLayer.Model
{
    /// <summary>
    /// A collection of ASSESSMENT_IRP_HEADER records
    /// </summary>
    public partial class ASSESSMENT_IRP_HEADER
    {
        public int? HEADER_RISK_LEVEL_ID { get; set; }
        [Key]
        public int ASSESSMENT_ID { get; set; }
        [Key]
        public int IRP_HEADER_ID { get; set; }
        public int? RISK_LEVEL { get; set; }
        [StringLength(500)]
        [Unicode(false)]
        public string COMMENT { get; set; }

        [ForeignKey("ASSESSMENT_ID")]
        [InverseProperty("ASSESSMENT_IRP_HEADER")]
        public virtual ASSESSMENTS ASSESSMENT { get; set; }
        [ForeignKey("IRP_HEADER_ID")]
        [InverseProperty("ASSESSMENT_IRP_HEADER")]
        public virtual IRP_HEADER IRP_HEADER { get; set; }
    }
}