using dotNetGraphQL.IService;
using dotNetGraphQL.Models;

namespace dotNetGraphQL.Service
{
    public class GroupService : IGroupService
    {
        private IList<Group> _groups;

        public GroupService() {
            _groups = new List<Group>() {
                new Group() { GroupId = 1, Name = "Group 1", ShortName = "G1"},
                new Group() { GroupId = 2, Name = "Group 2", ShortName = "G2"},
                new Group() { GroupId = 3, Name = "Group 3", ShortName = "G3"},
            };
        }
        public IQueryable<Group> GetAll()
        {
            return _groups.AsQueryable();
        }
    }
}
