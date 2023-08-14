using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TemplateAppModel
{
    public class InterfaceLog
    {
        [Key]
        public int InterfaceLogID { get; set; }
        public string RequestID { get; set; }
        public int InterfaceTypeID { get; set; }
        public int InterfaceServiceID { get; set; }
        public string? RequestPayload { get; set; }
        public string? ResponsePayload { get; set; }
        public DateTime? RequestDateTime { get; set; }
        public DateTime? ResponseDateTime { get; set; }
        public string? ProcessFlag { get; set; }
        public int? RetryCount { get; set; }
        public string? StatusCode { get; set; }
        public DateTime? ErrorDateTime { get; set; }
        public string? ErrorDescription { get; set; }
        public string? RefID { get; set; }
    }

    public class InterfaceTypeList
    {
        public int InterfaceTypeID { get; set; }
        public string InterfaceTypeName { get; set;}
    }

    public class InterfaceServiceList
    {
        public int InterfaceServiceID { get; set; }
        public string InterfaceServiceName { get; set;}
        public string? InterfaceServiceDescription { get; set;}
        public string InterfaceServiceURL { get; set; }
    }

    public class InterfaceTypeService
    {
        public int InterfaceTypeID { get; set; }
        public int InterfaceServiceID { get; set; }
    }
}
