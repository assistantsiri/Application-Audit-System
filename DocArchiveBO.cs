using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class DocArchiveBO
    {
        Int32 _collectId = 0;

        string _UpdtdBy = string.Empty;
        string _UpdtdDt = string.Empty;

        string _Docname = string.Empty;
        string _newDocDesc = string.Empty;




        public string newDocDesc
        {
            get { return _newDocDesc; }
            set { _newDocDesc = value; }
        }

        public string Docname
        {
            get { return _Docname; }
            set { _Docname = value; }
        }



        public string UpdtdBy
        {
            get { return _UpdtdBy; }
            set { _UpdtdBy = value; }
        }

        public string UpdtdDt
        {
            get { return _UpdtdDt; }
            set { _UpdtdDt = value; }
        }

        public Int32 collectId
        {
            get { return _collectId; }
            set { _collectId = value; }
        }

    }
}
