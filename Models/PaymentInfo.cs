using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ItdevFinalProject.Models
{
    public partial class PaymentInfo
    {
        [Key]
        public int PaymentId { get; set; }
        public int EmployeeNumber { get; set; }
        public int MonthlyIncome { get; set; }
        public int MonthlyRate { get; set; }
        public int PerformanceRating { get; set; }
        public int PercentSalaryHike { get; set; }
    }
}
