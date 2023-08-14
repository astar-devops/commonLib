using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TemplateAppModel
{
    public class ExceptionLog
    {
        [Key]
        public int ExceptionLogID { get; set; }
        public int ExceptionTypeID { get; set; }
        public DateTime ExceptionDateTime { get; set; }
        public string ExceptionDescription { get; set; }
        public string? RefID { get; set; }
    }

    public class ExceptionTypeList
    {
        public int ExceptionTypeID { get; set; }
        public string ExceptionTypeName { get; set; }
    }
}
