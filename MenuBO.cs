using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class MenuBO
    {
      
 string m_type = string.Empty;
        Byte m_Level1 = 0;
        Byte m_Level2 = 0;
        Byte m_Level3 = 0;
        string m_Title = string.Empty;
        string m_URL = string.Empty;
        string m_Freeze = string.Empty;
        string m_Action = string.Empty;

      
        public string type
        {
            get { return m_type; }
            set { m_type = value; }
        }
        public Byte Level1
        {
            get { return m_Level1; }
            set { m_Level1 = value; }
        }
        public Byte Level2
        {
            get { return m_Level2; }
            set { m_Level2 = value; }
        }
        public Byte Level3
        {
            get { return m_Level3; }
            set { m_Level3 = value; }
        }
        public string Title
        {
            get { return m_Title; }
            set { m_Title = value; }
        }
        public string URL
        {
            get { return m_URL; }
            set { m_URL = value; }
        }

        public string Freeze
        {
            get { return m_Freeze; }
            set { m_Freeze = value; }
        }

        public string Action
        {
            get { return m_Action; }
            set { m_Action = value; }
        }
        
    }


    
}
