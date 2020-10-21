using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metech.SimpleTaskApp.Tasks
{
    public interface ITaskRepository : IRepository<Task, long>
    {
        List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state);
    }
}
