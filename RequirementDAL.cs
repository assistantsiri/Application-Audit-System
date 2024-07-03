using BO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
namespace DA
{
   public class RequirementDAL
    {
         string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

         public RequirementDAL()
        {

        }
         public Byte SaveUpdateRequirement(RequirementBO objbo)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("AAS_REQUIREMENT_INSERT_UPDATE", conn);
             dCmd.CommandType = CommandType.StoredProcedure;
             dCmd.Parameters.Add("V_SLno", OracleType.Int32).Value = objbo.Slno;
             dCmd.Parameters.Add("V_ARM_MAIN_CODE", OracleType.Int32).Value = objbo.maincode;
             dCmd.Parameters.Add("V_ARM_SUB_CODE", OracleType.Int32).Value = objbo.subcode;
             dCmd.Parameters.Add("V_ARM_ITEM_DESC", OracleType.VarChar).Value = objbo.desc;
             dCmd.Parameters.Add("V_ARM_STATUS", OracleType.VarChar).Value = objbo.status;
             dCmd.Parameters.Add("V_ARM_UPDT_STAT", OracleType.VarChar).Value = objbo.updtstatus;
             dCmd.Parameters.Add("V_ARM_UPDT_BY", OracleType.VarChar).Value = objbo.updtby;
             dCmd.Parameters.Add("V_ARM_UPDT_DT", OracleType.VarChar).Value = objbo.updtdate;
             dCmd.Parameters.Add("v_Action", OracleType.Char).Value = objbo.Action;
             dCmd.Parameters.Add("v_Result", OracleType.Byte).Direction = ParameterDirection.Output;

             try
             {
                 dCmd.ExecuteNonQuery();
                 return Convert.ToByte(dCmd.Parameters["v_Result"].Value);
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }

         public DataTable FetchRequirement(RequirementBO requirement)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("select  a.*  from aas_reqirement_mast a where a.ARM_STATUS<>'I' " +
                              "  order by  a.ARM_SLNO ", conn);
             dCmd.CommandType = CommandType.Text;
             OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
             DataSet dSet = new DataSet();

             try
             {
                 dAd.Fill(dSet, "aas_reqirement_mast");
                 return dSet.Tables["aas_reqirement_mast"];
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dSet.Dispose();
                 dAd.Dispose();
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }
         public DataTable Requirement_Edit(RequirementBO requirement)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("select *  from aas_reqirement_mast a where a.arm_main_code=" + requirement.maincode + " and a.arm_sub_code=" + requirement.subcode, conn);
             dCmd.CommandType = CommandType.Text;
             OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
             DataSet dSet = new DataSet();

             try
             {
                 dAd.Fill(dSet, "aas_reqirement_mast");
                 return dSet.Tables["aas_reqirement_mast"];
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dSet.Dispose();
                 dAd.Dispose();
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }


         public DataTable FetchMaincode(RequirementBO requirement)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("select max(ARM_MAIN_CODE) as maxmain, max(ARM_MAIN_CODE)+1 as ARM_MAIN_CODE, max(ARM_SLNO)+1 as ARM_SLNO from aas_reqirement_mast where ARM_STATUS<>'I'", conn);
             dCmd.CommandType = CommandType.Text;
             OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
             DataSet dSet = new DataSet();

             try
             {
                 dAd.Fill(dSet, "aas_reqirement_mast");
                 return dSet.Tables["aas_reqirement_mast"];
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dSet.Dispose();
                 dAd.Dispose();
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }
         public DataTable FetchcSubcode(RequirementBO requirement)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("select max(ARM_SUB_CODE)+1 as ARM_SUB_CODE ,max(ARM_SLNO)+1 as ARM_SLNO  from aas_reqirement_mast where ARM_MAIN_CODE=" + requirement.maincode + " and ARM_STATUS<>'I'", conn);
             dCmd.CommandType = CommandType.Text;
             OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
             DataSet dSet = new DataSet();

             try
             {
                 dAd.Fill(dSet, "aas_reqirement_mast");
                 return dSet.Tables["aas_reqirement_mast"];
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dSet.Dispose();
                 dAd.Dispose();
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }

         public Byte UpdateSLno(int maincode,int subcode,int slno)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("update aas_reqirement_mast set ARM_SLNO=ARM_SLNO +1 where ARM_MAIN_CODE >" + maincode, conn);
             dCmd.CommandType = CommandType.Text;


             try
             {
                 dCmd.ExecuteNonQuery();
                 return 1;
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }

         public Byte UpdateSLnoDelete(int maincode)
         {
             OracleConnection conn = new OracleConnection(connStr);
             conn.Open();
             OracleCommand dCmd = new OracleCommand("update aas_reqirement_mast set ARM_SLNO=ARM_SLNO - 1 where ARM_MAIN_CODE >" + maincode, conn);
             dCmd.CommandType = CommandType.Text;


             try
             {
                 dCmd.ExecuteNonQuery();
                 return 1;
             }
             catch
             {
                 throw;
             }
             finally
             {
                 dCmd.Dispose();
                 conn.Close();
                 conn.Dispose();
             }
         }





    }
}
