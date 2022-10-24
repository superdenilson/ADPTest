using ADPTest.SharedKernel.Dtos;
using ADPTest.SharedKernel.Interfaces;
using ADPTest.SharedKernel.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.Infrastructure.Services
{
    public class ExternalService : HttpClientService, IExternalService
    {

        public ExternalService(IOptions<AppConfig> appConfigOptions)
        {
            var appConfig = appConfigOptions.Value;
            _baseUrl = appConfig.ServiceConfig.Url;
        }
        public async Task<TaskDto> GetTask()
        {
            var task = await SendRequest<TaskDto>(HttpMethod.Get, "get-task");
            return task;
        }

        public async Task<string> SubmitTaskResult(SubmitTaskDto submitTaskDto)
        {
            var requestData = new
            {
                id = submitTaskDto.id,
                result = submitTaskDto.result,
            };

            var requestString = JsonConvert.SerializeObject(requestData);
            var res = await SendRequest(requestString, HttpMethod.Post, "submit-task", "application/json");

            return res;
        }
    }
}
