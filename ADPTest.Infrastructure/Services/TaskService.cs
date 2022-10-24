using ADPTest.SharedKernel;
using ADPTest.SharedKernel.Dtos;
using ADPTest.SharedKernel.Interfaces;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly IExternalService _externalService;
        private readonly IOperationService _operationService;
        public TaskService(IExternalService externalService, IOperationService operationService)
        {
            _externalService = externalService;
            _operationService = operationService;
        }


        public async Task<TaskDto> GetTask()
        {
            var result = await _externalService.GetTask();
            return result;
        }

        public async Task<TaskResultDto> ExecuteTask()
        {
            var task = await _externalService.GetTask();
            var resultDto = new TaskResultDto();
            double result = 0;

            if (task == null)
                throw new Exception("Task not found");
            else
            {
                resultDto.Id = task.Id;
                resultDto.Operation = task.Operation;
                OperationType operationType = _operationService.DefineOperationType(task.Operation);

                switch(operationType)
                {
                    case OperationType.addition: result = _operationService.DoAddition(task.Left, task.Right); break;
                    case OperationType.subtraction: result = _operationService.DoSubtraction(task.Left, task.Right); break;
                    case OperationType.multiplication: result = _operationService.DoMultiplication(task.Left, task.Right); break;
                    case OperationType.division: result = _operationService.DoDivision(task.Left, task.Right); break;
                    case OperationType.remainder: result = _operationService.DoRemainder(task.Left, task.Right); break;
                    default: result = 0; break;
                }

                var submitTask = await _externalService.SubmitTaskResult(new SubmitTaskDto
                {
                    id = task.Id,
                    result = result
                });

                resultDto.Result = result;
            }

            return resultDto;
        }
    }
}
