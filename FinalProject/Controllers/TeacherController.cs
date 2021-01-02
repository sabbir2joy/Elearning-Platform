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
    public class TeacherController : ApiController
    {
        TeacherRepository techRepo = new TeacherRepository();


        SubjectRepository subRepo = new SubjectRepository();
        MyMaterialRepository matRepo = new MyMaterialRepository();
        VideoRepository vidRepo = new VideoRepository();


        [Route("")]

        //Get All Teachers Information
        public IHttpActionResult Get()
        {

            return Ok(techRepo.GetAll());
        }

        //Get a Specific Teacher Information
        [Route("OwnProfile", Name = "GetTeacherById")]
        [StudentAuthorization]
        public IHttpActionResult GetProfile()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;

            int id = techRepo.GetTeacherId(Name);

            List<Teacher> teacher = techRepo.GetTeacherById(id);

            //return Ok(techRepo.GetTeacherByThread(Name));
            return Ok(teacher);
        }



        //Create A  New Teacher
        [Route("")]

        public IHttpActionResult Post(Teacher tch)
        {
            techRepo.Insert(tch);
            string url = Url.Link("GetPostById", new { id = tch.TeacherId });
            return Created(url, tch);

        }

    }
}
