using dotNetGraphQL.Models;

namespace dotNetGraphQL.IService
{
    public interface IStudentService
    {
        IQueryable<Student> GetAll();
        Student Create(CreateStudentInput inputStudent);
        Student Delete(DeleteStudentInput inputStudent);
    }
}
