using Collector.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collector.Domain.Entities
{
    public  class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
