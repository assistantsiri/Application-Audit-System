using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class RptAuditReportBOL
    {
        public RptAuditReportBOL()
        {
            Action = string.Empty;
        }
        public Int32 AUDITID { get; set; }
        public string Action { get; set; }
        public Int32 StaffNum { get; set; }
    }
}
