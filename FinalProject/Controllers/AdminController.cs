using FinalProject.Models;
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
        //Get a Specific Student Information
        [Route("api/Admins/Students/{id}", Name = "GetStudentById")]
        public IHttpActionResult Get(int id)
        {
            OnlineStudent onlineStudent = stdRepo.GetById(id);


            if (onlineStudent == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(onlineStudent);
        }

    }
}
