using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TemplateAppModel
{
    public class ResponseMessage
    {
        public bool IsSuccess { get; set; }
        public string RequestID { get; set; }
    }
}
