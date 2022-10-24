using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADPTest.SharedKernel.Models
{
    public class AppConfig
    {
        public string Environment { get; set; }
        public string Version { get; set; }
        public ServiceConfig ServiceConfig { get; set; }
        public AppConfig()
        {
            Environment = "";
            Version = "";
        }
    }

    public struct ServiceConfig
    {
        public string Url { get; set; }
    }
}
