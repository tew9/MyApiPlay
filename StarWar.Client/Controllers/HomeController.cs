using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using StarWar.Client.Models;

namespace StarWar.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            //  HttpClient client = new HttpClient();
            // // var response = await client.GetStringAsync("https://swapi.co/api/people/2");
            // var response = await client.GetStringAsync("https://127.0.0.1:5001/starwar");
            // //var response = await client.GetStringAsync("https://jsonplaceholder.typicode.com/todos/1");
            
            // ActorModel actorModel = JsonConvert.DeserializeObject<ActorModel>(response);
            return View(new ActorModel());
        }
        

        [HttpPost]
        public async Task<IActionResult> Index(ActorModel actor)
        {   
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("https://swapi.co/api/people/"+actor.Number);
            // var response = client.GetStringAsync("https://127.0.0.1:5001/StarWar");
            
            ActorModel actorModel = JsonConvert.DeserializeObject<ActorModel>(response);
            return View(actorModel);
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
    }
}
