using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class CombinedRiskBO
    {
       public CombinedRiskBO()
        {
            Action = string.Empty;
        }
        public Int32 AUDITID { get; set; }
        public string Action { get; set; }
        public Int32 StaffNum { get; set; }
    }
}
