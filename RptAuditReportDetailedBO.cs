﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
 public    class RptAuditReportDetailedBO
    {
     public RptAuditReportDetailedBO()
     {
         Action = string.Empty;
         StaffNum = string.Empty;
     }
     public string StaffNum { get; set; }
     public string Action { get; set; }
     public Int32 AUDITID { get; set; }
    }
}
