using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItdevFinalProject.Models
{
    public partial class EmployeeInfo
    {
        [Key]
        public int EmployeeNumber { get; set; }
        public int Age { get; set; }
        public string Over18 { get; set; }
        public string RelationshipSatisfaction { get; set; }
    }
}
