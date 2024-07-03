using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class RptCheckListIOSpecificBO
    {
       public RptCheckListIOSpecificBO()
       {
           string Action = string.Empty;
           StaffNum = string.Empty;
           AppName = string.Empty;
       }
       public Int32 AuditID { get; set; }
       public string Action { get; set; }
       public string StaffNum { get; set; }
       public string AppName { get; set; }
    }
}
