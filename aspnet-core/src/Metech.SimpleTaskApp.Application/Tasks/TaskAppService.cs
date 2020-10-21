using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Metech.SimpleTaskApp.Authorization;
using Metech.SimpleTaskApp.People;
using Metech.SimpleTaskApp.Tasks.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Metech.SimpleTaskApp.Tasks
{
    /*[AbpAuthorize(PermissionNames.Pages_Tasks)]*/
    public class TaskAppService : ApplicationService, ITaskAppService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IRepository<Person> _personRepository;

        public TaskAppService(ITaskRepository taskRepository, IRepository<Person> personRepository)
        {
            _taskRepository = taskRepository;
            _personRepository = personRepository;
        }

        public long CreateTask(CreateTaskInput input)
        {
            Logger.Info("Creating a task for input: " + input);
            var task = new Task { Description = input.Description };

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPersonId = input.AssignedPersonId.Value;
            }

            var id = _taskRepository.InsertAndGetId(task);
            return id;
        }

        public GetTasksOutput GetTasks(GetTasksInput input)
        {

            var tasks = _taskRepository.GetAllWithPeople(input.AssignedPersonId, input.State);

            List<TaskDto> taskDtos = new List<TaskDto>();

            foreach (var task in tasks)
            {
                TaskDto taskDto = new TaskDto();
                taskDto.Id = task.Id;
                taskDto.AssignedPersonId = task.AssignedPersonId;
                taskDto.AssignedPersonName = task.AssignedPerson.Name;
                taskDto.CreationTime = task.CreationTime;
                taskDto.Description = task.Description;
                taskDto.State = (byte)task.State;
                taskDtos.Add(taskDto);
            }

            return new GetTasksOutput
            {
                Tasks = taskDtos
            };

        }

        public void UpdateTask(UpdateTaskInput input)
        {
            Logger.Info("Update a for input: " + input);

            var task = _taskRepository.Get(input.TaskId);

            if (input.State.HasValue)
            {
                task.State = input.State.Value;
            }

            if (input.AssignedPersonId.HasValue)
            {
                task.AssignedPerson = _personRepository.Load(input.AssignedPersonId.Value);
            }

        }
    }
}
