using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItdevFinalProject.Models
{
    public partial class JobInfo
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeNumber { get; set; }
        public int JobInvolvement { get; set; }
        public int JobLevel { get; set; }
        public string JobRole { get; set; }
        public int JobSatisfaction { get; set; }
        public string BusinessTravel { get; set; }
    }
}
