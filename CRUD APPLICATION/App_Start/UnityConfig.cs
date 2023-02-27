//using CRUD_APPLICATION.BussinessLayer.Class;
//using CRUD_APPLICATION.BussinessLayer.Interface;
using Business_Layer.Interface;
using DAL.Models;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Business_Layer;
using Business_Layer.Classes;

namespace CRUD_APPLICATION
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ICategory, CategoryClass>();
            container.RegisterType<IProducts, ProductClasss>();
            container.RegisterType<ICategoryAdv, CategoryAdv>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}