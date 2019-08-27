using QuestRooms.BLL.Servises.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public class QuestRoomsController : Controller
    {
        private IQuestRoomService service;
        public QuestRoomsController(IQuestRoomService service)
        {
            this.service = service;
        }
        // GET: City
        public ViewResult Index()
        {
            var cities = service.GetAllRooms();
            return View(cities);
        }
    }
}