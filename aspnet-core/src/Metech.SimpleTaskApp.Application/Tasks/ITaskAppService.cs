using Abp.Application.Services;
using Metech.SimpleTaskApp.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metech.SimpleTaskApp.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        GetTasksOutput GetTasks(GetTasksInput input);
        void UpdateTask(UpdateTaskInput input);
        long CreateTask(CreateTaskInput input);
    }
}
