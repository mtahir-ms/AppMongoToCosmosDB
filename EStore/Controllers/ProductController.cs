using EStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace EStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly Home _repository;
        public ProductController(Home home)
        {
            _repository = home;
        }

        

    }
}
