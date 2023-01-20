using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using webapi1.Models;
using webapi1.rep;

namespace webapi1.Controllers
{
    
    public class Entity1Controller : ApiController
    {
        public readonly Empinterface Empm;
        private Entity1Controller() { }
        public Entity1Controller(Empinterface Empm)
        {
            this.Empm = Empm;
        }
        [Route("api/Entity1/GetEmpDetails")]
        [HttpGet]
        public IHttpActionResult GetEmpDetails()
        {
            var abc = Empm.GetEmpDetails();
            if (abc == null)
            {
                return NotFound();
            }
            return Ok(abc);
        }


        [Route("api/Entity1/Delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var abc = Empm.Delete(id );
            if (abc != null)
            {
                return Ok(abc);
            }
            return NotFound();


        }


        [Route("api/Entity1/insert")]
        [HttpPost]
        public HttpResponseMessage insert(EmpModel id)
        {
            var abc = Empm.Insert(id);
            return Request.CreateResponse(HttpStatusCode.OK, abc);
        }

        [Route("api/Entity1/updateempinfo")]
        [HttpPost]
        public IHttpActionResult updateempinfo(EmpModel id)
        {

            var abc = Empm.updateempinfo(id);
            if (abc != null)
            {
                return Ok("Updated");
                
            }
            return NotFound();

        }

        [Route("api/Entity1/bulkinsert")]
        [HttpPost]
        public HttpResponseMessage bulkinsert(List<EmpModel>em)
        {
            var abc = Empm.Bulkinsert(em);
            return Request.CreateResponse(HttpStatusCode.OK, abc);
        }


        //[Route("api/Entity1/bulkdelete")]
        //[HttpPost]
        //public HttpResponseMessage bulkdelete(List<EmpModel>em)
        //{
        //    var abc = Empm.Bulkdelete(em);
        //    return Request.CreateResponse(HttpStatusCode.NoContent);
        //}

        [Route("api/Entity1/GetByIdDetails/{id}")]
        [HttpGet]
        public IHttpActionResult GetByIdDetails(int id)
        {
            var abc = Empm.GetByIdDetails(id);
            if (abc == null)
            {
                return NotFound();
            }

            return Ok(abc);

            //if(abc == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            //return Request.CreateResponse(HttpStatusCode.OK, abc);
        }




    } 
}









             







    


