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

        //Create A  New Student
        [Route("api/Admins/Students")]
        public IHttpActionResult Post(OnlineStudent onlineStudent)
        {
            stdRepo.Insert(onlineStudent);
            string url = Url.Link("GetStudentById", new { id = onlineStudent.StudentId });
            return Created(url, onlineStudent);
        }


        //Delete a Student
        [Route("api/Admins/Students/{id}")]
        public IHttpActionResult Delete(int id)
        {
            stdRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }


        //////////////////////// CRUD Operation for Teacher////////////////////////////////

        TeacherRepository techRepo = new TeacherRepository();

        [Route("api/Admins/Teachers")]

        //Get All Teachers Information
        public IHttpActionResult GetAllTeachers()
        {

            return Ok(techRepo.GetAll());
        }

        //Get a Specific Teacher Information
        [Route("api/Admins/Teachers/{id}", Name = "GetTeachersById")]
        public IHttpActionResult GetSpecificTeacher(int id)
        {
            Teacher tch = techRepo.GetById(id);


            if (tch == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(tch);
        }


        //Create A  New Teacher
        [Route("api/Admins/Teachers")]
        public IHttpActionResult Post(Teacher tch)
        {
            techRepo.Insert(tch);
            string url = Url.Link("GetTeachersById", new { id = tch.TeacherId });
            return Created(url, tch);
        }

        //Edit a Teacher Information
        [Route("api/Admins/Teachers/{id}")]
        public IHttpActionResult Put([FromBody] Teacher tch, [FromUri] int id)
        {
            tch.TeacherId = id;
            techRepo.Edit(tch);
            return Ok(tch);
        }

        //Delete a Teacher
        [Route("api/Admins/Teachers/{id}")]
        public IHttpActionResult DeleteTeacher(int id)
        {
            techRepo.Delete(id);
            return StatusCode(HttpStatusCode.NoContent);
        }

        
    }
}
