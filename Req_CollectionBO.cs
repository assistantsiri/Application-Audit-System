using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
  public  class Req_CollectionBO
    {
        string _Remarks = string.Empty;
        Int32 _collectId = 0;
        Int32 _Maincode = 0;
        Int32 _subcode = 0;
        string _UpdtdBy = string.Empty;
        string _UpdtdDt = string.Empty;
        Int32 _UserSec = 0;
        Int32 _DevelpSec = 0;
        string _ApplicationName = string.Empty;
        string _ReqDate = string.Empty;
        string _AuditStatus = string.Empty;
        string _UpdtStatus = string.Empty;
        Int32 _AuditId= 0;
        string _Action = string.Empty;
        string _Status = string.Empty;
        Int32 _SLno = 0;
        Int32 _uploadSLno = 0;
        string _Docname = string.Empty;
        string _DocDesc = string.Empty;
        string _filepath = string.Empty;
        string _QrydDt = string.Empty;
      

        public string QrydDt
        {
            get { return _QrydDt; }
            set { _QrydDt = value; }
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

        public string ReqDate
        {
            get { return _ReqDate; }
            set { _ReqDate = value; }
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
        public string UpdtStatus
        {
            get { return _UpdtStatus; }
            set { _UpdtStatus = value; }
        }
        public string AuditStatus
        {
            get { return _AuditStatus; }
            set { _AuditStatus = value; }
        }
       

        public string ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        public Int32 UserSec
        {
            get { return _UserSec; }
            set { _UserSec = value; }
        }
        public Int32 DevelpSec
        {
            get { return _DevelpSec; }
            set { _DevelpSec = value; }
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
        public string Remarks
        {
            get { return _Remarks; }
            set { _Remarks = value; }
        }
        public Int32 collectId
        {
            get { return _collectId; }
            set { _collectId = value; }
        }

        public Int32 Maincode
        {
            get { return _Maincode; }
            set { _Maincode = value; }
        }
        public Int32 subcode
        {
            get { return _subcode; }
            set { _subcode = value; }
        }
    }
}
