using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class GetAllParams
    {
        public int Limit { get; set; } = 20;

        public int Offset { get; set; } = 0;
        public string Search { get; set; } = string.Empty;
    }
}
