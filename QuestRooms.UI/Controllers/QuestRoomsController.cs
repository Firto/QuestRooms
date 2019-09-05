using QuestRooms.BLL.Servises.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.Controllers
{
    public struct Data<TEntity> where TEntity : class {
        public bool More { get; set; }
        public IEnumerable<QuestRooms.BLL.DtoModels.QuestRoomDto> data { get; set; }
    }

    public class QuestRoomsController : Controller
    {
        private IQuestRoomService service;

        private readonly byte countItems = 10;

        public QuestRoomsController(IQuestRoomService service)
        {
            this.service = service;
        }
        // GET: City
        public ViewResult Index()
        {
            var dos = new Data<QuestRooms.BLL.DtoModels.QuestRoomDto>
            {
                data = service.GetRoomsFromID(0, countItems)
            };
            dos.More = (dos.data.Count() > 0 && dos.data.Last().ID != service.GetLast().ID);

            return View(dos);
        }

        public PartialViewResult GetQuestRooms(string id) {
            int id_p;
            if (!Int32.TryParse(id, out id_p)) id_p = 0;

            var dos = new Data<QuestRooms.BLL.DtoModels.QuestRoomDto>
            {
                data = service.GetRoomsFromID(id_p, countItems)
            };
            dos.More = (dos.data.Count() > 0 && dos.data.Last().ID != service.GetLast().ID);

            return PartialView(dos);
        }
    }
}