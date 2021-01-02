using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class AdminController : ApiController
    {
        OnlineStudentsRepository stdRepo = new OnlineStudentsRepository();


        [Route("api/Admins/Students")]

        //Get All Students Information
        public IHttpActionResult Get()
        {

            return Ok(stdRepo.GetAll());
        }
    }
}
