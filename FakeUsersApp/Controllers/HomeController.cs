using FakeUsersApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FakeUsersApp.Enums;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;

namespace FakeUsersApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<PersonModel> _people;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new FakeDataViewModel());
        }

        [HttpPost]
        public IActionResult Index(FakeDataViewModel viewModel)
        {
            var fakeUserInfos = viewModel.FakeData.GenerateData((Country)viewModel.SelectedCountry, 20, viewModel.Seed, viewModel.ErrorPerRecord/100);
           
            viewModel.FakePeople = fakeUserInfos;
            
            return View(viewModel);
        }
        [HttpPost]
        public PartialViewResult LoadMoreData(FakeDataViewModel viewModel, int page)
        {
           
            int pageSize = 20; 

            var fakeUserInfos = viewModel.FakeData.GenerateData((Country)viewModel.SelectedCountry, 10, viewModel.Seed, viewModel.ErrorPerRecord/100);
            viewModel.FakePeople.AddRange(fakeUserInfos);

            int startIndex = (page - 1) * pageSize;
            int endIndex = startIndex + pageSize;

            var partialData = viewModel.FakePeople.Skip(startIndex).Take(pageSize).ToList();
            ViewBag.CurrentPage = page;
            return PartialView("_FakeTabledata", partialData);
        }

        [HttpPost]
        public IActionResult ExportToCSV(FakeDataViewModel viewModel)
        {
            var records = viewModel.FakePeople;
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(records);
                streamWriter.Flush();
                return File(memoryStream.ToArray(), "text/csv", $"FakeUsers_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv");
            }
        }

    }
}
