using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BO
{
  public  class FormAATeamBO
    {
       
        Int32 m_AuditID = 0;
        Int32 m_ReqCollectID=0;
        String m_StaffNum;
        Int32 m_StaffNumEdit = 0;
        Int32 m_IrregTot=0;
        Int32 m_IrregRectiTot=0;
        string m_TeamLeadYN = string.Empty;
        string m_EngageStatus = string.Empty;
        string m_AllocDate = string.Empty;
        string m_RelieveDt = string.Empty;
        string m_Status = string.Empty;
        string m_UpdtStat = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Action  = string.Empty;


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

        public String StaffNum
        {
            get { return m_StaffNum; }
            set { m_StaffNum = value; }
        }
        public Int32 StaffNumEdit
        {
            get { return m_StaffNumEdit; }
            set { m_StaffNumEdit = value; }
        }

       public Int32 IrregTot
        {
            get { return m_IrregTot; }
            set { m_IrregTot = value; }
        }

       public Int32 IrregRectiTot
        {
            get { return m_IrregRectiTot; }
            set { m_IrregRectiTot = value; }
        }

        public String TeamLeadYN
        {
            get { return m_TeamLeadYN; }
            set { m_TeamLeadYN = value; }
        }

        public String EngageStatus
        {
            get { return m_EngageStatus; }
            set { m_EngageStatus = value; }
        }

        public String AllocDate
        {
            get { return m_AllocDate; }
            set { m_AllocDate = value; }
        }

        public String RelieveDt
        {
            get { return m_RelieveDt; }
            set { m_RelieveDt = value; }
        }

         public String Status
        {
            get { return m_Status; }
            set { m_Status = value; }
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
    }
}

