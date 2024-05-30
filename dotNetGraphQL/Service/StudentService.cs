using dotNetGraphQL.Exceptions;
using dotNetGraphQL.IService;
using dotNetGraphQL.Models;

namespace dotNetGraphQL.Service
{
    public class StudentService : IStudentService
    {
        private IList<Student> _students;
        public StudentService() { 
            _students = new List<Student>() {
                new Student() { StudentId = 1, Name = "Tom 1", GroupId = 1},
                new Student() { StudentId = 2, Name = "Tom 2", GroupId = 2},
                new Student() { StudentId = 3, Name = "Tom 3", GroupId = 3},
            };
        }

        public Student Create(CreateStudentInput inputStudent)
        {
            var student = new Student()
            {
                StudentId = _students.Max(x => x.StudentId) + 1,
                Name = inputStudent.Name,
                GroupId = inputStudent.GroupId,
            };
            _students.Add(student);
            return student;
        }

        public Student Delete(DeleteStudentInput inputStudent)
        {
            var student = _students.FirstOrDefault(x => x.StudentId == inputStudent.StudentId);
            if (student != null)
            {
                _students.Remove(student);
                return student;
            }
            else { 
                throw new StudentNotFoundException() { StudentId = inputStudent.StudentId };
            }
        }

        public IQueryable<Student> GetAll()
        {
            return _students.AsQueryable();
        }
    }
}
