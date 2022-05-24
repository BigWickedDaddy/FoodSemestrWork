using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodSemWork.Models
{
    public class Main
    {
        public string RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);



        //public string text { get; set; }
        //public byte[] picture { get; set; }
        //public DateTime timeposted { get;set; }
    }
}
