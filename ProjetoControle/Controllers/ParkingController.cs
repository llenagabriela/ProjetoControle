using Microsoft.AspNetCore.Mvc;
using ProjetoControle.Models;

namespace ProjetoControle.Controllers
{
    public class ParkingController : Controller
    {
        public IActionResult Index()
        {
            List<ParkingControl> list = new List<ParkingControl>();
            list.Add(new ParkingControl { Placa = "MK3KI5", DataEnt = "01/01/2023", DataSai = "01/01/2023", TimeEnt = "13:20:00", Duracao = "1:00:00", TimeSai = "15:20:00", 
             TimeCobr = "1",Preco = "R$ 2,00", ValorPag = "R$ 2,00"});
 
            return View(list);
        }
    }
}
