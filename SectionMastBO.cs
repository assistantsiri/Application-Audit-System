using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class SectionMastBO
    {

        string m_MainCode = string.Empty;
        string m_SecCode = string.Empty;
        string m_SecName = string.Empty;
        string m_Status = string.Empty;
        string m_UpdtStat = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_Action = string.Empty;

        public string MainCode
        {
            get { return m_MainCode; }
            set { m_MainCode = value; }
        }

        public string SecCode
        {
            get { return m_SecCode; }
            set { m_SecCode = value; }
        }

        public string SecName
        {
            get { return m_SecName; }
            set { m_SecName = value; }
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
