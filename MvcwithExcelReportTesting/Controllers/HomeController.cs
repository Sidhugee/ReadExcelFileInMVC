using DocumentFormat.OpenXml.Wordprocessing;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using MvcwithExcelReportTesting.Models;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;
using System.Web;

namespace MvcwithExcelReportTesting.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public class ExcelController : Controller
        {

            public IActionResult Index()
            {
                return View();
            }


        }
    }
}


