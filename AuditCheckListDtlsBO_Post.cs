using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
  public  class AuditCheckListDtlsBO_Post
    {
        Int32 m_AuditID = 0;
        Int32 m_Slno = 0;
        Int32 m_GroupCode = 0;
        Int32 m_ItemCode = 0;
        Int32 m_Dept = 0;
        string m_Applicable = string.Empty;
        string m_YNAns = string.Empty;
        string m_GradeOption = string.Empty; 
        string m_Post_GradeOption = string.Empty;
        string m_ChecklistStatus = string.Empty;
        string m_Observation = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Reply = string.Empty;
        string m_ReplyStatus = string.Empty;
        string m_ReplyUpdtBy = string.Empty; 
        string m_ReplyUpdtBy_Post = string.Empty;
        string m_ReplyUpdtDt = string.Empty;
        string m_Action = string.Empty;
        string m_AcceptDeny = string.Empty; 
        string m_Post_AcceptDeny = string.Empty; 
        string m_Post_Wing_AcceptDeny = string.Empty;
        string m_Remarks = string.Empty;
        string m_POST_Remarks = string.Empty;   
        string m_POST_Wing_Remarks = string.Empty;
        string m_UserID = string.Empty;
        int m_ObsStatus = 0;
        string m_POSTOBSERVATION = string.Empty;
        string m_POSTOBSREPLY = string.Empty;
        string m_Post_ReplyStatus = string.Empty; 
        string m_ObsUpdtDt_Post = string.Empty;
        Int32 m_SectionID = 0;

        string m_ACD_Post_Applicable = string.Empty;
        string m_ReplyUpdtDt_Post = string.Empty;
        string m_Post_Reply_Status_Updt_Dt = string.Empty;
        string m_Post_Reply_Update_Dt = string.Empty;
        string m_Post_AD_Update_Dt = string.Empty;
        string m_Updt_By_Post = string.Empty;
        string m_Post_Obs_Updt_By = string.Empty;
        string m_Post_AD_Updt_By = string.Empty;
        string m_Post_Wing_Updt_By = string.Empty;
        string m_Post_Wing_Updt_DT = string.Empty;
        string m_Post_Reply_Status_Updt_By = string.Empty;
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
        public string Post_GradeOption
        {
            get { return m_Post_GradeOption; }
            set { m_Post_GradeOption = value; }
        } 
        public string ReplyUpdtDt_Post
        {
            get { return m_ReplyUpdtDt_Post; }
            set { m_ReplyUpdtDt_Post = value; }
        }    
        public string Post_Reply_Status_Updt_Dt
        {
            get { return m_Post_Reply_Status_Updt_Dt; }
            set { m_Post_Reply_Status_Updt_Dt = value; }
        }  
        public string ObsUpdtDt_Post
        {
            get { return m_ObsUpdtDt_Post; }
            set { m_ObsUpdtDt_Post = value; }
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
        public string POSTOBSERVATION
        {
            get { return m_POSTOBSERVATION; }
            set { m_POSTOBSERVATION = value; }
        } 
        public string POSTOBSREPLY
        {
            get { return m_POSTOBSREPLY; }
            set { m_POSTOBSREPLY = value; }
        }
         public string Post_ReplyStatus
        {
            get { return m_Post_ReplyStatus; }
            set { m_Post_ReplyStatus = value; }
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
        public string ReplyUpdtBy_Post
        {
            get { return m_ReplyUpdtBy_Post; }
            set { m_ReplyUpdtBy_Post = value; }
        }
        public string ReplyUpdtDt
        {
            get { return m_ReplyUpdtDt; }
            set { m_ReplyUpdtDt = value; }
        }  
        public string Post_Reply_Update_Dt
        {
            get { return m_Post_Reply_Update_Dt; }
            set { m_Post_Reply_Update_Dt = value; }
        }
        public string Post_AD_Update_Dt
        {
            get { return m_Post_AD_Update_Dt; }
            set { m_Post_AD_Update_Dt = value; }
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
        public string Post_Wing_AcceptDeny
        {
            get { return m_Post_Wing_AcceptDeny; }
            set { m_Post_Wing_AcceptDeny = value; }
        } 
        public string Post_AcceptDeny
        {
            get { return m_Post_AcceptDeny; }
            set { m_Post_AcceptDeny = value; }
        }
        public string Remarks
        {
            get { return m_Remarks; }
            set { m_Remarks = value; }
        }  
        public string POST_Remarks
        {
            get { return m_POST_Remarks; }
            set { m_POST_Remarks = value; }
        } 
        public string POST_Wing_Remarks
        {
            get { return m_POST_Wing_Remarks; }
            set { m_POST_Wing_Remarks = value; }
        } 
        public string Updt_By_Post
        {
            get { return m_Updt_By_Post; }
            set { m_Updt_By_Post = value; }
        }   
        public string Post_Obs_Updt_By
        {
            get { return m_Post_Obs_Updt_By; }
            set { m_Post_Obs_Updt_By = value; }
        }
        public string Post_AD_Updt_By
        {
            get { return m_Post_AD_Updt_By; }
            set { m_Post_AD_Updt_By = value; }
        }
        public string Post_Wing_Updt_By
        {
            get { return m_Post_Wing_Updt_By; }
            set { m_Post_Wing_Updt_By = value; }
        }
        public string Post_Wing_Updt_DT        {
            get { return m_Post_Wing_Updt_DT; }
            set { m_Post_Wing_Updt_DT = value; }
        }
        public string Post_Reply_Status_Updt_By
        {
            get { return m_Post_Reply_Status_Updt_By; }
            set { m_Post_Reply_Status_Updt_By = value; }
        }
        //public string ACD_COMPILED
        //{
        //    get { return m_ACD_COMPILED; }
        //    set { m_ACD_COMPILED = value; }
        //}
        public string ACD_Post_Applicable
        {
            get { return m_ACD_Post_Applicable; }
            set { m_ACD_Post_Applicable = value; }
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
