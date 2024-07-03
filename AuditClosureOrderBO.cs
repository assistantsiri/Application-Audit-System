using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class AuditClosureOrderBO
    {
        public AuditClosureOrderBO()
        {

            from_adrs1 = string.Empty;
            from_adrs2 = string.Empty;
            from_adrs3 = string.Empty;
            to_adrs1 = string.Empty;
            to_adrs2 = string.Empty;
            to_adrs3 = string.Empty;
            ref_fromnumber = string.Empty;
            ref_tonumber = string.Empty;
            note_date = string.Empty;
            note_subject = string.Empty;
            orderdetails = string.Empty;
            orderby = string.Empty;


            status = string.Empty;
            updt_stat = string.Empty;
            updt_by = string.Empty;
            updt_date = string.Empty;
            Action = string.Empty;
        }


        public Int32 audit_id { get; set; }

        public string from_adrs1 { get; set; }
        public string from_adrs2 { get; set; }
        public string from_adrs3 { get; set; }
        public string to_adrs1 { get; set; }
        public string to_adrs2 { get; set; }
        public string to_adrs3 { get; set; }
        public string ref_fromnumber { get; set; }
        public string ref_tonumber { get; set; }
        public string note_date { get; set; }
        public string note_subject { get; set; }
        public string orderdetails { get; set; }
        public string orderby { get; set; }


        public string status { get; set; }
        public string updt_stat { get; set; }
        public string updt_by { get; set; }
        public string updt_date { get; set; }
        public string Action { get; set; }


    }
}