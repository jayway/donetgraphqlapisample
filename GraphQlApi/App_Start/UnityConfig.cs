using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using GraphQlApi.Repository;
using Unity;
using Unity.Injection;
using NLipsum.Core;
using GraphQlApi.Models;

namespace GraphQlApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            container.RegisterSingleton<RoomRepo>(new InjectionConstructor(ValueGenerator.GenerateRooms));
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }

    public static class ValueGenerator
    {
        public static IList<Room> GenerateRooms
        {
            get
            {
                var _rooms = new List<Room>();
                for (var i = 0; i < 10; i++)
                {
                    _rooms.Add(new Room
                    {
                        Id = i,
                        RoomName = string.Join(" ", LipsumGenerator.Generate(1).Split(' ').Take(2))
                    });
                }
                return _rooms;
            }
        }
    }
}