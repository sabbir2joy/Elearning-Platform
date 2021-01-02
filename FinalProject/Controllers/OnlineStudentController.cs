using FinalProject.Attributes;
using FinalProject.Models;
using FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace FinalProject.Controllers
{
    public class OnlineStudentController : ApiController
    {
        OnlineStudentsRepository stdRepo = new OnlineStudentsRepository();


        /*   [Route("")]

           //Get All Students Information
           public IHttpActionResult Get()
           {

               return Ok(stdRepo.GetAll());
           }*/

        //Get a Specific Student Information

        [Route("api/OnlineStudents/getinfo")]
        [StudentAuthorization]
        public IHttpActionResult Get()
        {
            string Na = Thread.CurrentPrincipal.Identity.Name;


            return Ok(stdRepo.GetOnlineStudentsHey(Na));
        }


      

    }
}
