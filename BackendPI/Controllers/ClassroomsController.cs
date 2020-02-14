using BackendPI.Models;
using System;
using System.Web.Http;


namespace BackendPI.Controllers
{
    public class ClassroomsController : ApiController
    {
        public ServerResponse<ClassroomDTO> GetByTeacher(int idTeacher)
        {
            var repo = new ClassroomsRepository();
            var result = repo.RetrieveByTeacher(idTeacher);

            return new ServerResponse<ClassroomDTO>()
            {
                Data = result,
                Result = result != null
            };
        }

        public ServerResponse<ClassroomDTO> GetAll()
        {
            var repo = new ClassroomsRepository();
            var result = repo.RetrieveClassrooms();

            return new ServerResponse<ClassroomDTO>()
            {
                Data = result,
                Result = result != null
            };
        }

        public IHttpActionResult Post([FromBody]Classroom classroom)
        {
            if (classroom.Id != null) return BadRequest();
            if (classroom.Name == null) return BadRequest();

            var repo = new ClassroomsRepository();

            try {
                repo.SaveClassroom(classroom);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return InternalServerError();
            }

            return Ok();
        }

        [Route("api/classrooms/teachers")] [HttpPost]
        public IHttpActionResult addTeacherClassroom([FromBody] TeacherClassroom teacherClassroom)
        {
            var repo = new ClassroomsRepository();

            if (repo.AddClassroomToTeacher(teacherClassroom.TeacherId, teacherClassroom.ClassroomId)) return Ok();
            else return BadRequest();
        }

        [Route("api/classrooms/children")] [HttpPost]
        public void Post([FromBody] ChildClassroom childClassroom)
        {
            var repo = new ClassroomsRepository();
            repo.AddClassroomToChild(childClassroom.ChildId, childClassroom.ClassroomId);
        }
    }
}
