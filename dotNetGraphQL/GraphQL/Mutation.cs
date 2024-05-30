using dotNetGraphQL.IService;
using dotNetGraphQL.Models;

namespace dotNetGraphQL.GraphQL
{
    public class Mutation
    {
        private readonly IStudentService _studentService;

        public Mutation(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public Student CreateStudent(CreateStudentInput studentInput) { 
            return _studentService.Create(studentInput);
        }

        public Student DeleteStudent(DeleteStudentInput studentInput)
        {
            return _studentService.Delete(studentInput);
        }
    }
}
