﻿using ADPTest.SharedKernel.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.SharedKernel.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResultDto> ExecuteTask();
    }
}
