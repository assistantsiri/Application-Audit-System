using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class RptRiskPerceptionBO
    {
       public RptRiskPerceptionBO()
       {
           StaffNum = string.Empty;
           Action = string.Empty;
       }
       public Int32 AUDITID { get; set; }
       public string Action { get; set; }
       public string StaffNum { get; set; }
    }
}
