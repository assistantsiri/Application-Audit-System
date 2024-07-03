using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
  public class Post_QueryWise_BO
    {
        public Post_QueryWise_BO()
        {
            Action = string.Empty;
        }
        public Int32 audit_id { get; set; }
        public Int32 Dept { get; set; }
        public string Action { get; set; }
    }
}
