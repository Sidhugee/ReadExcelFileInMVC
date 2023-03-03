using MessagePack;
using Microsoft.EntityFrameworkCore;


namespace MvcwithExcelReportTesting.Models
{
    public class MyModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }
        public string? Name { get; set; }

        public int Age { get; set; }

        public string? Email { get; set; }


    }
}
