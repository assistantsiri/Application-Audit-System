using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class RiskPerceptionMastBO
    {
        Int16 m_ParamCode = 0;
        Int16 m_SlNo = 0;
        string m_ParamDescr = string.Empty;
        Int16 m_Marks = 0;
        string m_Status = string.Empty;
        string m_UpdtStat = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Action = string.Empty;

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
        public string ParamDescr
        {
            get { return m_ParamDescr; }
            set { m_ParamDescr = value; }
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
        public string UpdtStat
        {
            get { return m_UpdtStat; }
            set { m_UpdtStat = value; }
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
