using dotNetGraphQL.Models;

namespace dotNetGraphQL.IService
{
    public interface IGroupService
    {
        IQueryable<Group> GetAll();
    }
}
