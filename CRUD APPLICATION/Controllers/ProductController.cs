using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net.Http;
using DAL.Models;
using Business_Layer.Interface;

namespace CRUD_APPLICATION.Controllers
{
    public class ProductController : Controller
    {
        private IProducts Product;

        public ProductController(IProducts pro)
        {
            Product= pro;
        }

        DataContexts db = new DataContexts();
        // GET: Product

        HttpClient client = new HttpClient();

        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            client.BaseAddress = new Uri("https://localhost:44311/api/HomeAPI");
            var responce = client.GetAsync("HomeAPI");
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                var display = test.Content.ReadAsAsync<List<Product>>();
                display.Wait();
                products = display.Result;

            }
            return View(products);


        }

        //public async Task<ActionResult> Index()
        //{
        //    var data = await db.GetAllProductAsync();
        //    return View(data);
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product pro)
        {

            client.BaseAddress = new Uri("https://localhost:44311/api/HomeAPI");
            var responce = client.PostAsJsonAsync("HomeAPI", pro);
            responce.Wait();
            var test = responce.Result;
            if (test.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Create");

            //if(ModelState.IsValid)
            //{
            //    bool data =await db.CreateProduct(pro);
            //    if(data == true)
            //    {
            //        TempData["Message"] = "<script>alert('Product Created Successfully')</script>";
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        TempData["Message"] = "<script>alert('Product Not Created')</script>";

            //    }
            //}
            //return View();
        }

        public async Task<ActionResult> Edit(int id)
        {
            var data =await Product.GetProductById(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Product pro)
        {
            var data =await Product.EditProduct(pro);
            return View(data);

            //client.BaseAddress = new Uri("https://localhost:44311/api/HomeAPI");
            //var responce = client.PutAsJsonAsync("HomeAPI", pro);
            //responce.Wait();
            //var test = responce.Result;
            //if (test.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index","Product");

            //}
            //return View("Create");

           
        }

        public async Task<ActionResult> Details(int id)
        {
            var data =await Product.GetProductById(id);
            return View(data);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var data =await Product.GetProductById(id);
            return View(data);
        }


        [HttpPost]
        public ActionResult delete(int id)
        {
            var data = Product.DeleteProduct(id);
            return View(data);
            //client.BaseAddress = new Uri("https://localhost:44311/api/HomeAPI");
            //var responce = client.DeleteAsync("HomeAPI/" + id.ToString());
            //responce.Wait();
            //var test = responce.Result;
            //if (test.IsSuccessStatusCode)
            //{
            //    return RedirectToAction("Index");
            //}
            //return View("Delete");
            
        }


    }
}