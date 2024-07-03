using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class RelieveAuditBO
    {
        Int32 _ReqId = 0;
        string _UpdtdBy = string.Empty;
        string _UpdtdDt = string.Empty;
        string _ReqDate = string.Empty;
        string _Action = string.Empty;
        string _StaffNo = string.Empty;
        Int32 _AuditID = 0;

        public Int32 ReqId
        {
            get { return _ReqId; }
            set { _ReqId = value; }
        }
        public string ReqDate
        {
            get { return _ReqDate; }
            set { _ReqDate = value; }
        }
        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }
        public string UpdtdBy
        {
            get { return _UpdtdBy; }
            set { _UpdtdBy = value; }
        }

        public string UpdtdDt
        {
            get { return _UpdtdDt; }
            set { _UpdtdDt = value; }
        }
        public string StaffNo
        {
            get { return _StaffNo; }
            set { _StaffNo = value; }
        }
        public Int32 AuditID
        {
            get { return _AuditID; }
            set { _AuditID = value; }
        }
    }
}
