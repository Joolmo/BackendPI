using BackendPI.Models;
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

        public void Post([FromBody]Classroom classroom)
        {
            var repo = new ClassroomsRepository();
            repo.SaveClassroom(classroom);
        }

        public void Post([FromBody] TeacherClassroom teacherClassroom)
        {
            var repo = new ClassroomsRepository();
            repo.AddClassroomToTeacher(teacherClassroom.TeacherId, teacherClassroom.ClassroomId);
        }

        public void Post([FromBody] ChildClassroom childClassroom)
        {
            var repo = new ClassroomsRepository();
            repo.AddClassroomToChild(childClassroom.ChildId, childClassroom.ClassroomId);
        }
    }
}
