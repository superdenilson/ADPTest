using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.SharedKernel.Dtos
{
    public class TaskDto
    {
        public string Id { get; set; }
        public string Operation { get; set; }
        public double Left { get; set; }
        public double Right { get; set; }
    }
}
