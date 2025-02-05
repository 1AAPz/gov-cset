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
    /// A collection of IMPORTANCE records
    /// </summary>
    public partial class IMPORTANCE
    {
        public IMPORTANCE()
        {
            FINDING = new HashSet<FINDING>();
        }

        [Key]
        public int Importance_Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string Value { get; set; }

        [InverseProperty("Importance")]
        public virtual ICollection<FINDING> FINDING { get; set; }
    }
}