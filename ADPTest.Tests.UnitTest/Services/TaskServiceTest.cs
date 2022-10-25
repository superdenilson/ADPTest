using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FluentAssertions;
using Castle.DynamicProxy;
using ADPTest.Infrastructure.Services;
using ADPTest.SharedKernel.Interfaces;
using ADPTest.SharedKernel.Dtos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace ADPTest.Tests.UnitTests.Services
{
    public class TaskServiceTest
    {
        private readonly Mock<IExternalService> _externalServiceMock;
        private readonly ITaskService _taskService;
        private readonly IOperationService _operationService;

        public TaskServiceTest()
        {
            _externalServiceMock = new Mock<IExternalService>();
            _operationService = new OperationService();
            _taskService = new TaskService(_externalServiceMock.Object, _operationService);
        }

        [Fact]
        public async Task ExecuteTaskAddition_ResultSuccess()
        {
            string id = new Guid().ToString();

            //ARRANGE
            var expectedResult = new TaskResultDto { Id = id, Operation = "addition", Result = 4152550225854305 + 8389802698550225 };

            //SETUP
            TaskDto mockedTask = new TaskDto { Id = id, Left = 4152550225854305, Right = 8389802698550225, Operation = "addition" };
            _externalServiceMock.Setup(s => s.GetTask()).Returns(Task.FromResult(mockedTask));

            //ACT
            var result = await _taskService.ExecuteTask();

            //ASSERT
            result.Result.Should().Be(expectedResult.Result);
        }

        [Fact]
        public async Task ExecuteTaskSubtraction_ResultSuccess()
        {
            string id = new Guid().ToString();

            //ARRANGE
            var expectedResult = new TaskResultDto { Id = id, Operation = "subtraction", Result = 8389802698550225 - 4152550225854305 };

            //SETUP
            TaskDto mockedTask = new TaskDto { Id = id, Left = 8389802698550225, Right = 4152550225854305, Operation = "subtraction" };
            _externalServiceMock.Setup(s => s.GetTask()).Returns(Task.FromResult(mockedTask));

            //ACT
            var result = await _taskService.ExecuteTask();

            //ASSERT
            result.Result.Should().Be(expectedResult.Result);
        }

        [Fact]
        public async Task ExecuteTaskMultiplication_ResultSuccess()
        {
            string id = new Guid().ToString();

            //ARRANGE
            var expectedResult = new TaskResultDto { Id = id, Operation = "multiplication", Result = 8389802698550225.0 * 4152550225854305.0 };

            //SETUP
            TaskDto mockedTask = new TaskDto { Id = id, Left = 8389802698550225, Right = 4152550225854305, Operation = "multiplication" };
            _externalServiceMock.Setup(s => s.GetTask()).Returns(Task.FromResult(mockedTask));

            //ACT
            var result = await _taskService.ExecuteTask();

            //ASSERT
            result.Result.Should().Be(expectedResult.Result);
        }

        [Fact]
        public async Task ExecuteTaskDivision_ResultSuccess()
        {
            string id = new Guid().ToString();

            //ARRANGE
            var expectedResult = new TaskResultDto { Id = id, Operation = "division", Result = 8389802698550225.0 / 4152550225854305.0 };

            //SETUP
            TaskDto mockedTask = new TaskDto { Id = id, Left = 8389802698550225, Right = 4152550225854305, Operation = "division" };
            _externalServiceMock.Setup(s => s.GetTask()).Returns(Task.FromResult(mockedTask));

            //ACT
            var result = await _taskService.ExecuteTask();

            //ASSERT
            result.Result.Should().Be(expectedResult.Result);
        }

        [Fact]
        public async Task ExecuteTaskRemainder_ResultSuccess()
        {
            string id = new Guid().ToString();

            //ARRANGE
            var expectedResult = new TaskResultDto { Id = id, Operation = "remainder", Result = 8389802698550225.0 % 4152550225854305.0 };

            //SETUP
            TaskDto mockedTask = new TaskDto { Id = id, Left = 8389802698550225, Right = 4152550225854305, Operation = "remainder" };
            _externalServiceMock.Setup(s => s.GetTask()).Returns(Task.FromResult(mockedTask));

            //ACT
            var result = await _taskService.ExecuteTask();

            //ASSERT
            result.Result.Should().Be(expectedResult.Result);
        }
    }
}
