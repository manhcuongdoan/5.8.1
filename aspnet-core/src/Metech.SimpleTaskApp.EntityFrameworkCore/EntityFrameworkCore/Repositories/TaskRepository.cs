using Abp.EntityFrameworkCore;
using Metech.SimpleTaskApp.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Metech.SimpleTaskApp.EntityFrameworkCore.Repositories
{
    public class TaskRepository : SimpleTaskAppRepositoryBase<Task, long>, ITaskRepository
    {
        public TaskRepository(IDbContextProvider<SimpleTaskAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = GetAll();

            if(assignedPersonId.HasValue)
            {
                query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
            }

            if(state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }

            return query
               .OrderByDescending(task => task.CreationTime)
               .Include(task => task.AssignedPerson) //Include assigned person in a single query
               .ToList();

        }
    }
}
