using ADPTest.SharedKernel.Dtos;
using ADPTest.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ADPTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost("ExecuteTask")]
        public async Task<TaskResultDto> ExecuteTask()
        {
            var result = await _taskService.ExecuteTask();
            return result;
        }
    }
}