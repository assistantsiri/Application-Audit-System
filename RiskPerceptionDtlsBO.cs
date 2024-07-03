using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class RiskPerceptionDtlsBO
    {
        Int16 m_Dept = 0;
        Int16 m_Role = 0;
        Int32 m_AuditID = 0;
        Int32 m_ReqCollectID = 0;
        Int16 m_ParamCode = 0;
        Int16 m_SlNo = 0;
        Decimal m_AuditeeMarks = 0;
        Decimal m_AuditorMarks = 0;
        string m_Status = string.Empty;
        string m_UpdtStatAuditee = string.Empty;
        string m_UpdtStatAuditor = string.Empty;
        string m_UpdtByAuditee = string.Empty;
        string m_UpdtDtAuditee = string.Empty;
        string m_UpdtByAuditor = string.Empty;
        string m_UpdtDtAuditor = string.Empty;
        string m_Action = string.Empty;
        string m_UserId = string.Empty;

        public Int16 Dept
        {
            get { return m_Dept; }
            set { m_Dept = value; }
        }
        public Int16 Role
        {
            get { return m_Role; }
            set { m_Role = value; }
        }
        public Int32 AuditID
        {
            get { return m_AuditID; }
            set { m_AuditID = value; }
        }
        public Int32 ReqCollectID
        {
            get { return m_ReqCollectID; }
            set { m_ReqCollectID = value; }
        }
        public Int16 ParamCode
        {
            get { return m_ParamCode; }
            set { m_ParamCode = value; }
        }
        public Int16 SlNo
        {
            get { return m_SlNo; }
            set { m_SlNo = value; }
        }
        public Decimal AuditeeMarks
        {
            get { return m_AuditeeMarks; }
            set { m_AuditeeMarks = value; }
        }
        public Decimal AuditorMarks
        {
            get { return m_AuditorMarks; }
            set { m_AuditorMarks = value; }
        }
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }
        public string UpdtStatAuditee
        {
            get { return m_UpdtStatAuditee; }
            set { m_UpdtStatAuditee = value; }
        }
        public string UpdtStatAuditor
        {
            get { return m_UpdtStatAuditor; }
            set { m_UpdtStatAuditor = value; }
        }
        public string UpdtByAuditee
        {
            get { return m_UpdtByAuditee; }
            set { m_UpdtByAuditee = value; }
        }
        public string UpdtDtAuditee
        {
            get { return m_UpdtDtAuditee; }
            set { m_UpdtDtAuditee = value; }
        }
        public string UpdtByAuditor
        {
            get { return m_UpdtByAuditor; }
            set { m_UpdtByAuditor = value; }
        }
        public string UpdtDtAuditor
        {
            get { return m_UpdtDtAuditor; }
            set { m_UpdtDtAuditor = value; }
        }
        public string Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        public string UserId
        {
            get { return m_UserId; }
            set { m_UserId = value; }
        }
    }
}
