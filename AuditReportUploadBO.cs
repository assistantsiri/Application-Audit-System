using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
  public  class AuditReportUploadBO
    {
      public AuditReportUploadBO()
      {

          filename = string.Empty;
          location = string.Empty;
          
          status = string.Empty;
          updt_stat = string.Empty;
          updt_by = string.Empty;
          updt_date = string.Empty;
          Action = string.Empty;
      }


      public Int32 audit_id { get; set; }
      public Int32 slno { get; set; }

      public string filename { get; set; }
      public string location { get; set; }
      

      public string status { get; set; }
      public string updt_stat { get; set; }
      public string updt_by { get; set; }
      public string updt_date { get; set; }
      public string Action { get; set; }
      
   
    }
}
