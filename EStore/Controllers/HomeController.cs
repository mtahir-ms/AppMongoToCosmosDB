using System.Diagnostics;
using System.Text;
using EStore.Models;
using EStore.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace EStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Home _repository;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _repository = Home.ConnectionStringSetUp(_configuration);

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> Test()
        {
            var data = await _repository.GetAllDataAsync();
            return Json(data);

        }

        public async Task<IActionResult> Products()
        {
            var data = await _repository.GetAllDataAsync();
            var res = data.ConvertAll(BsonTypeMapper.MapToDotNetValue);

            return Json(res);

        }


    }
}