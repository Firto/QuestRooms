using Autofac;
using Autofac.Integration.Mvc;
using AutoMapper;
using QuestRooms.BLL.Mapping;
using QuestRooms.BLL.Servises.Abstraction;
using QuestRooms.BLL.Servises.Implementation;
using QuestRooms.DAL;
using QuestRooms.DAL.Entities;
using QuestRooms.DAL.Repositoriy;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestRooms.UI.App_Start
{
    public class AutoFacConfig
    {
        public static void ConfigureAutoFac() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            RegisterTypes(builder);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }

        private static void RegisterTypes(ContainerBuilder builder) {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.AddProfile<MapperProflile>();
            });
            IMapper mapper = new Mapper(mapperConfig);

            DbContext context = new RoomsContext();
            IGenericRepository<City> cityGenericRepository = new EFGenericRepository<City>(context);
            IGenericRepository<QuestRoom> questRoomGenericRepository = new EFGenericRepository<QuestRoom>(context);
            ICityService cityService = new CityServise(cityGenericRepository, mapper);
            IQuestRoomService questRoomService = new QuestRoomServise(questRoomGenericRepository, mapper);

            builder.RegisterInstance(mapper).As<IMapper>();
            builder.RegisterInstance(context).As<DbContext>();
            builder.RegisterInstance(cityGenericRepository).As<IGenericRepository<City>>();
            builder.RegisterInstance(questRoomGenericRepository).As<IGenericRepository<QuestRoom>>();
            builder.RegisterInstance(cityService).As<ICityService>();
            builder.RegisterInstance(questRoomService).As<IQuestRoomService>();
        }
    }
}