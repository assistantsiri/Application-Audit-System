using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class OtherDocBO
    {
        Int32 _AuditId = 0;
        string _Action = string.Empty;
        string _Status = string.Empty;
        Int32 _SLno = 0;
        Int32 _uploadSLno = 0;
        string _Docname = string.Empty;
        string _DocDesc = string.Empty;
        string _filepath = string.Empty;
        string _UpdtStatus = string.Empty;
        string _UpdtdBy = string.Empty;
        string _UpdtdDt = string.Empty;


        public string UpdtStatus
        {
            get { return _UpdtStatus; }
            set { _UpdtStatus = value; }
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


        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public string Action
        {
            get { return _Action; }
            set { _Action = value; }
        }

        public Int32 AuditId
        {
            get { return _AuditId; }
            set { _AuditId = value; }
        }
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        public Int32 uploadSLno
        {
            get { return _uploadSLno; }
            set { _uploadSLno = value; }
        }
        public string DocDesc
        {
            get { return _DocDesc; }
            set { _DocDesc = value; }
        }

        public string Docname
        {
            get { return _Docname; }
            set { _Docname = value; }
        }

        public Int32 SLno
        {
            get { return _SLno; }
            set { _SLno = value; }
        }

    }
}
