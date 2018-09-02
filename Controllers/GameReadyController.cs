using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// https://docs.microsoft.com/ko-kr/aspnet/core/signalr/dotnet-client?view=aspnetcore-2.1
// https://docs.microsoft.com/ko-kr/aspnet/core/signalr/streaming?view=aspnetcore-2.1
namespace Rainism.Controllers
{
    public class GameReadyController : Controller
    {
        String groupCode;
        Queue<long> ReadyPeople;
        // GET: /<controller>/
        HubConnection connection;
        public GameReadyController(){
            connection = new HubConnectionBuilder()
                                .WithUrl("https://localhost:1685/GameHub")
                                .Build();
        }


        [HttpGet]
        [Route("ReadyToStartAsync")]
        public async void ReadyToStartAsync(){
            try{
                await connection.StartAsync();
            }catch( Exception ex){
                Console.WriteLine(ex);
            }
        }
        [HttpGet]
        [Route("Index")]
        public IActionResult Index(){
            return View();
        }

    }
}
