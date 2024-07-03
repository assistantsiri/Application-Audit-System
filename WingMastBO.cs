using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
    public class WingMastBO
    {
        string m_MainCode= string.Empty;
        string m_WingCode = string.Empty;
        string m_WingName = string.Empty;
        string m_Action = string.Empty;

        public string MainCode
        {
            get { return m_MainCode; }
            set { m_MainCode = value; }
        }

        public string WingCode
        {
            get { return m_WingCode; }
            set { m_WingCode = value; }
        }

        public string WingName
        {
            get { return m_WingName; }
            set { m_WingName = value; }
        }


        public String Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
    }
}
