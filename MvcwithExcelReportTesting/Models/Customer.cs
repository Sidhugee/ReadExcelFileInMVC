using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MvcwithExcelReportTesting.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string? PatientName { get; set; }

        public int RollNo { get; set; }

        public int Salary { get; set; }

    }
}
