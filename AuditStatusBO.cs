using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    //Added by Nagarathna
   public class AuditStatusBO
    {
        public AuditStatusBO()
        {
            string UpdtdBy = string.Empty;
            string AuditStatus = string.Empty;
            string Status = string.Empty;
            string Section = string.Empty;
            string Action = string.Empty;

        }
       public Int32 AuditId { get; set; }
       public Int16 roleid { get; set; }
       public Int16 deptid { get; set; }
       public Int32 GroupCode { get; set; }      
       public string Status { get; set; }
       public string Section { get; set; }
       public string UpdtdBy { get; set; }
       public string AuditStatus { get; set; }
       public string Action { get; set; }
    }
}
