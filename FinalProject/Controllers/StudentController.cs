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
    public class StudentController : ApiController
    {
        SubjectRepository subRepo = new SubjectRepository();
        CoursesOfStudentRepository cosRepo = new CoursesOfStudentRepository();
        RegistrationRepository regRepo = new RegistrationRepository();
       // VideoRepository vidRepo = new VideoRepository();
        UserRepository uRepo = new UserRepository();
        OnlineStudentsRepository osRepo = new OnlineStudentsRepository();
        private object vidRepo;

        [Route("api/students/mycourses")]
        [StudentAuthorization]
        public IHttpActionResult Get(/*[FromUri] string name*/)
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(cosRepo.GetCourseByStudent(Name));
        }

        [Route("api/students/enroll")]
        [StudentAuthorization]

        public IHttpActionResult PostEnroll([FromBody] CoursesOfStudent cos)
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;

            int subid = cos.CourseId;
            Subject ss = subRepo.GetSubDetaileById(subid);
            ss.StudentCount += 1;
            subRepo.Edit(ss);

            cos.TeacherId = ss.TeacherId;
            cosRepo.Insert(cos);

            Registration reg = new Registration();
            reg.SubjectId = cos.CourseId;
            reg.StudentName = Name;
            reg.Fee = ss.Price;
            regRepo.Insert(reg);

            return Ok(cos);
        }

        [Route("api/students/registration")]
        [StudentAuthorization]

        public IHttpActionResult GetRegistration()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;


            return Ok(regRepo.GetRegInfoByName(Name));
        }

        [Route("api/students/subjects/{id}/videos")]
        [StudentAuthorization]

       // public IHttpActionResult GetVideo([FromUri] int id)
       // {

          //  return Ok(vidRepo.GetVideoBySubject(id));
       // }

        private IHttpActionResult Ok(object p)
        {
            throw new NotImplementedException();
        }

        [Route("api/students/getUserInfo")]
        [StudentAuthorization]

        public IHttpActionResult GetUserInfo()
        {
            string Name = Thread.CurrentPrincipal.Identity.Name;
            return Ok(uRepo.getUserInfoByName(Name));
        }
    }
}
