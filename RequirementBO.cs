using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class RequirementBO
    {
       Int32 aas_Slno = 0;
       Int32 aas_maincode = 0;
       string aas_desc = string.Empty;
       Int32 aas_subcode = 0;
       string aas_status = string.Empty;
       string aas_updtstatus = string.Empty;
       string aas_updtby = string.Empty;
       string aas_updtdate = string.Empty;

       string _Action = string.Empty;

       public Int32 Slno
       {
           get { return aas_Slno; }
           set { aas_Slno = value; }
       }

       public string updtby
       {
           get { return aas_updtby; }
           set { aas_updtby = value; }
       }

       public string updtdate
       {
           get { return aas_updtdate; }
           set { aas_updtdate = value; }
       }

       public string status
       {
           get { return aas_status; }
           set { aas_status = value; }
       }

       public string updtstatus
       {
           get { return aas_updtstatus; }
           set { aas_updtstatus = value; }
       }

       public string desc
       {
           get { return aas_desc; }
           set { aas_desc = value; }
       }

       public Int32 subcode
       {
           get { return aas_subcode; }
           set { aas_subcode = value; }
       }

       public Int32 maincode
       {
           get { return aas_maincode; }
           set { aas_maincode = value; }
       }
       public string Action
       {
           get { return _Action; }
           set { _Action = value; }
       }

    }
}
