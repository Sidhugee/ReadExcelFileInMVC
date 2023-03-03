using Microsoft.AspNetCore.Mvc;
using MvcwithExcelReportTesting.Models;
using OfficeOpenXml;

namespace MvcwithExcelReportTesting.Controllers
{
    public class ExcelDatabaseController : Controller
    {

        
       
        // Read data from Excel file
        public IActionResult Index()
        {
            var data = new List<MyModel>();
            var file = new FileInfo("C:\\Users\\salla\\Downloads\\Report.xlsx");

            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets["Report"];
                // Loop through each row in the worksheet (skipping the header row)
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    var id = int.Parse(worksheet.Cells[row, 1].Value.ToString());
                    var name = worksheet.Cells[row, 2].Value?.ToString() ?? "";
                    var age = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                    var email = worksheet.Cells[row, 4].Value?.ToString() ?? "";

                    data.Add(new MyModel { Id = id, Name = name, Age = age ,Email = email});
                }
            }
            ViewBag.data=data;
            return View(data);
        }

        // Create a new row in Excel file
        public IActionResult Create(MyModel newData)
        {
            var file = new FileInfo("C:\\Users\\salla\\Downloads\\Report.xlsx");

            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets["Report"];

                // Find the next available row
                var newRow = worksheet.Dimension.End.Row + 1;

                // Write the new data to the worksheet
                worksheet.Cells[newRow, 1].Value = newData.Id;
                worksheet.Cells[newRow, 2].Value = newData.Name;
                worksheet.Cells[newRow, 3].Value = newData.Age;
                worksheet.Cells[newRow, 4].Value = newData.Email;


                // Save the changes to the worksheet and the workbook
                package.Save();
            }

            return RedirectToAction("Index");
        }

        // Update an existing row in Excel file
        public IActionResult UpdateExcelRow(MyModel updatedData)
        {
            var file = new FileInfo("C:\\Users\\salla\\Downloads\\Report.xlsx");

            using (var package = new ExcelPackage(file))
            {
                var worksheet = package.Workbook.Worksheets["Report"];

                // Find the row with the matching ID
                var row = worksheet.Cells["A:A"].FirstOrDefault(c => c.Value.ToString() == updatedData.Id.ToString()).Start.Row;

                // Update the data in the row
                worksheet.Cells[row, 2].Value = updatedData.Name;
                worksheet.Cells[row, 3].Value = updatedData.Age;
                worksheet.Cells[row, 4].Value = updatedData.Email;

                package.Save();
            }

            return RedirectToAction("Index");
        }


       

    
    
     
      




    }

}
