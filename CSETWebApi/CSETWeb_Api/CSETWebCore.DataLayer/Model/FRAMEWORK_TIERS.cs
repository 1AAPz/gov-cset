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
    /// A collection of FRAMEWORK_TIERS records
    /// </summary>
    public partial class FRAMEWORK_TIERS
    {
        public FRAMEWORK_TIERS()
        {
            FRAMEWORK_TIER_DEFINITIONS = new HashSet<FRAMEWORK_TIER_DEFINITIONS>();
            FRAMEWORK_TIER_TYPE_ANSWER = new HashSet<FRAMEWORK_TIER_TYPE_ANSWER>();
        }

        [Key]
        [StringLength(50)]
        [Unicode(false)]
        public string Tier { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string FullName { get; set; }
        public int TierOrder { get; set; }

        [InverseProperty("TierNavigation")]
        public virtual ICollection<FRAMEWORK_TIER_DEFINITIONS> FRAMEWORK_TIER_DEFINITIONS { get; set; }
        [InverseProperty("TierNavigation")]
        public virtual ICollection<FRAMEWORK_TIER_TYPE_ANSWER> FRAMEWORK_TIER_TYPE_ANSWER { get; set; }
    }
}