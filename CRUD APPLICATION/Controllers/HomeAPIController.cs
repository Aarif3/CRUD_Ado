//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using CRUD_APPLICATION.Models;

//namespace CRUD_APPLICATION.Controllers
//{

//    public class HomeAPIController : ApiController
//    {

//        Context db = new Context();

//        [HttpGet]
//        public async Task<IHttpActionResult> Getproduct()
//        {
//            var data = await db.GetAllProductAsync();
//            return Ok(data);
//        }

//        [HttpPost]
//        public async Task<IHttpActionResult> CreateProduct(Product pro)
//        {
//            var data = await db.CreateProduct(pro);
//            return Ok(data);
//        }


//        [HttpPut]
//        public async Task<IHttpActionResult> Edit(Product pro)
//        {
//            var data = await db.EditProducts(pro);
//            return Ok(data);
//        }

//        public IHttpActionResult Delete(int id)
//        {
//            var data = db.Deleteproduct(id);
//            return Ok(data);
//        }

//    }
//}
