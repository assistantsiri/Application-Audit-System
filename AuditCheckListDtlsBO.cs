using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class AuditCheckListDtlsBO
    {
        Int32 m_AuditID = 0;
        Int32 m_Slno = 0;
        Int32 m_GroupCode = 0;
        Int32 m_ItemCode = 0;
        Int32 m_Dept = 0;
        string m_Applicable = string.Empty;
        string m_YNAns = string.Empty;
        string m_GradeOption = string.Empty;
        string m_ChecklistStatus = string.Empty;
        string m_Observation = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;   
        string m_Reply = string.Empty;
        string m_ReplyStatus = string.Empty;
        string m_ReplyUpdtBy = string.Empty;
        string m_ReplyUpdtDt = string.Empty;
        string m_Action = string.Empty;
        string m_AcceptDeny = string.Empty;
        string m_Remarks = string.Empty;
        string m_UserID = string.Empty;
        int m_ObsStatus = 0;

        Int32 m_SectionID = 0;

        public Int32 Dept
        {
            get { return m_Dept; }
            set { m_Dept = value; }
        }
        public Int32 AuditID             
        {
            get { return m_AuditID; }
            set { m_AuditID = value; }
        }
        public Int32 Slno
        {
            get { return m_Slno; }
            set { m_Slno = value; }
        }
        public Int32 GroupCode
        {
            get { return m_GroupCode; }
            set { m_GroupCode = value; }
        }
        public Int32 ItemCode
        {
            get { return m_ItemCode; }
            set { m_ItemCode = value; }
        }
        public string Applicable
        {
            get { return m_Applicable; }
            set { m_Applicable = value; }
        }
        public string YNAns
        {
            get { return m_YNAns; }
            set { m_YNAns = value; }
        }
        public string GradeOption
        {
            get { return m_GradeOption; }
            set { m_GradeOption = value; }
        }
        public string ChecklistStatus
        {
            get { return m_ChecklistStatus; }
            set { m_ChecklistStatus = value; }
        }
        public string Observation
        {
            get { return m_Observation; }
            set { m_Observation = value; }
        }
        public string UpdtBy
        {
            get { return m_UpdtBy; }
            set { m_UpdtBy = value; }
        }
        public string UpdtDt
        {
            get { return m_UpdtDt; }
            set { m_UpdtDt = value; }
        }
        public string Reply
        {
            get { return m_Reply; }
            set { m_Reply = value; }
        }
        public string ReplyStatus
        {
            get { return m_ReplyStatus; }
            set { m_ReplyStatus = value; }
        }
        public string ReplyUpdtBy
        {
            get { return m_ReplyUpdtBy; }
            set { m_ReplyUpdtBy = value; }
        }
        public string ReplyUpdtDt
        {
            get { return m_ReplyUpdtDt; }
            set { m_ReplyUpdtDt = value; }
        }
        public string Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        public string AcceptDeny
        {
            get { return m_AcceptDeny; }
            set { m_AcceptDeny = value; }
        }
        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }
        public string UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }
        public int ObsStatus
        {
            get { return m_ObsStatus; }
            set { m_ObsStatus = value; }
        }

        public Int32 SectionID
        {
            get { return m_SectionID; }
            set { m_SectionID = value; }
        }

    }
}
