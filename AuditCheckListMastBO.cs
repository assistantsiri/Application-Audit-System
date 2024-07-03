using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class AuditCheckListMastBO
    {
        Int32 m_GrpCode = 0;
        Int32 m_ItemCode = 0;
        string m_ItemDescr = string.Empty;
        Int16 m_GrpIndex = 0;
        Int16 m_Prompt = 0;
        Int16 m_Marks = 0;
        string m_Status = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Action = string.Empty;
    
        public Int32 GrpCode  
        {
            get{ return m_GrpCode;}
            set{ m_GrpCode = value;}
        }
        public Int32 ItemCode
        {
            get { return m_ItemCode; }    
            set { m_ItemCode = value; }
        }
        public string ItemDescr
        {
            get { return m_ItemDescr; }
            set { m_ItemDescr = value; }
        }
        public Int16 GrpIndex
        {
            get { return m_GrpIndex; }
            set { m_GrpIndex = value; }
        }
        public Int16 Prompt
        {
            get { return m_Prompt; }
            set { m_Prompt = value; }
        }
        public Int16 Marks
        {
            get { return m_Marks; }
            set { m_Marks = value; }
        }
        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
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
        public string Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
    }
}
