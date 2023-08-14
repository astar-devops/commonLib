using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;

namespace TemplateAppModel
{
	//[PrimaryKey(nameof(Code), nameof(Key1))] (only available if using .NET 7.0 and imports Microsoft.EntityFrameworkCore (7.0.7))
	public class SystemCode
	{
		public int Code { get; set; }
		public string Key1 { get; set; }
		public string CodeValue { get; set; }
		public string CodeDescription { get; set; }
	}
}
