//using CRUD_APPLICATION.BussinessLayer.Interface;
//using CRUD_APPLICATION.Models;
using Business_Layer.Interface;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUD_APPLICATION.Controllers
{
    [HandleError]
    [Authorize]
    public class CategoryController : Controller
    {

        private readonly ICategory category = null;
        public CategoryController(ICategory cata)
        {
            category = cata;
        }

        private readonly ICategoryAdv cate;
        public CategoryController(ICategoryAdv cat)
        {
            cate= cat;
        }
        //DataContexts db = new DataContexts();
        // GET: Category
        public async Task<ActionResult> Index(Category cat)
        {
            var data =await category.GetAllCategory(cat);
            return View(data);
        }

        [Authorize]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Category cat)
        {

            var data =await category.CreateCategory(cat);


            //if (ModelState.IsValid)
            //{
            //    bool a = await db.Createcategory(cat);
            //    if (a == true)
            //    {
            //        TempData["Message"] = "<script>alert('Category Created Successfully')</script>";
            //        return RedirectToAction("Index");
            //    }
            //    else
            //    {
            //        TempData["Message"] = "<script>alert('Category Not Created')</script>";
            //    }
            //}
            return View(data);
        }

        public ActionResult Edit(int id)
        {
            var data = category.GetCategoryByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Category cat)
        {
            bool data =await category.EditCategory(cat);
            if (data)
            {
                TempData["Message"] = "<script>alert('Category Created Successfully')</script>";
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Details(int id)
        {
            var data = await category.GetCategoryByID(id);
            return View(data);
        }


        public async Task<ActionResult> Delete(int id)
        {
            var data = await category.GetCategoryByID(id);
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(Category cat)
        {
            bool a =await category.DeleteCategory(cat.Id);
            if (a == true)
            {
                TempData["Message"] = "<script>alert('Category Deleted Successfully')</script>";
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult DeActivecat(int id)
        {
            bool data = cate.DeActive(id);
            if (data == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult ActiveCategory(int id)
        {
            bool a = cate.Active(id);
            if (a == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }


        public ActionResult ShowAddProduct(int id)
        {
            Session["Categoryid"] = id;
            var data = cate.ShowAddProducts();
            return View(data);
        }

        public ActionResult AddProToCat(int Pid, int Cid)
        {
            bool a = cate.AddProduts(Pid, Cid);
            if (a == true)
            {
                TempData["Message"] = "<script>alert('Product Added to Category')</script>";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ShowProToCat(int id)

        {
            var data = cate.ShowProductInCategory(id);
            return View(data);
        }


    }
}