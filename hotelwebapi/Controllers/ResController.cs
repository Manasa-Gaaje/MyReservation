using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using webapi1.Models;
using webapi1.rep;

namespace webapi1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ResController : ApiController
    {
        public readonly resInterface res;

        //private ResController() { }
        public ResController(resInterface res)
        {
            this.res = res;
        }
        [Route("api/Res/GetResDetails")]
        [HttpGet]
        public IHttpActionResult GetResDetails()
        {
            var abc = res.GetResDetails();
            if (abc == null)
            {
                return NotFound();
            }
            return Ok(abc);
        }        
        [Route("api/Res/insert")]
         [HttpPost]
        public IHttpActionResult insert(resModel id)
         {
            var abc = res.Insert(id);
            if (abc == "inserted")
            {
                return Ok(abc);
            }
            else if(abc == "updated")
            {
                return Ok(abc);
            }
            return NotFound();
        }

        [Route("api/Res/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var abc = res.Delete(id);
            if (abc != null)
            {
                return Ok(abc);
            }
            return NotFound();
        }
        //[Route("api/Res/updateresinfo")]
        //[HttpPost]
        //public IHttpActionResult updateresinfo(resModel id)
        //{

        //    var abc = res.updateresinfo(id);
        //    if (abc == null)
        //    {
        //        return NotFound();

        //    }
        //    return Ok("updated") ;

        //}

        [Route("api/Res/Test")]
        [HttpGet]
        public HttpResponseMessage Test()
        {

            var b = res.sp_getall();
            return Request.CreateResponse(HttpStatusCode.OK, b);  
           
        }



    }
}