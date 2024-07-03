using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class PlanApplicationAuditBO
    {
        String m_AuditID = String.Empty;
        string m_Remarks = string.Empty;
        Int32 m_CollectID = 0;
        string m_ApplicationName = string.Empty;
        string m_ReviewFrom = string.Empty;
        string m_ReviewTo = string.Empty;
        string m_FromDt = string.Empty;
        string m_ToDt = string.Empty;
        string m_ManDays = string.Empty;
        string m_AuditStage = string.Empty;
        string m_Status = string.Empty;
        string m_Gradation = string.Empty;
        string m_UpdtStat = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Action  = string.Empty;


        string m_StaffNum = string.Empty;
        Int32 m_ChklstPending = 0;
        Int32 m_ChklstRectified = 0;


        public String AuditID
        {
            get { return m_AuditID; }
            set { m_AuditID = value; }
        }

        public Int32 CollectID
        {
            get { return m_CollectID; }
            set { m_CollectID = value; }
        }

        public String ApplicationName
        {
            get { return m_ApplicationName; }
            set { m_ApplicationName = value; }
        }

        public String ReviewFrom
        {
            get { return m_ReviewFrom; }
            set { m_ReviewFrom = value; }
        }

        public String ReviewTo
        {
            get { return m_ReviewTo; }
            set { m_ReviewTo = value; }
        }

        public String FromDt
        {
            get { return m_FromDt; }
            set { m_FromDt = value; }
        }

        public String ToDt
        {
            get { return m_ToDt; }
            set { m_ToDt = value; }
        }

        public String ManDays
        {
            get { return m_ManDays; }
            set { m_ManDays = value; }
        }

        public String AuditStage
        {
            get { return m_AuditStage; }
            set { m_AuditStage = value; }
        }

        public String Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public String Gradation
        {
            get { return m_Gradation; }
            set { m_Gradation = value; }
        }

        public String UpdtStat
        {
            get { return m_UpdtStat; }
            set { m_UpdtStat = value; }
        }

        public String UpdtBy
        {
            get { return m_UpdtBy; }
            set { m_UpdtBy = value; }
        }

        public String UpdtDt
        {
            get { return m_UpdtDt; }
            set { m_UpdtDt = value; }
        }

        public String Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }

        public String StaffNum
        {
            get { return m_StaffNum; }
            set { m_StaffNum = value; }
        }

        public Int32 ChklstPending
        {
            get { return m_ChklstPending; }
            set { m_ChklstPending = value; }
        }

        public Int32 ChklstRectified
        {
            get { return m_ChklstRectified; }
            set { m_ChklstRectified = value; }
        }
        public String Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }

    }
}
