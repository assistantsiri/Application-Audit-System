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
  public  class Req_CollectionDAL
    {

        string connStr = ConfigurationManager.ConnectionStrings["AASConnectionString"].ToString();

        public Req_CollectionDAL()
        {

        }
        public Byte SaveUpdateReqCollection(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_REQ_COLLECT_INSERT_UPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_ARC_REQ_COLLECTID", OracleType.Int32).Value = objbo.collectId;
            dCmd.Parameters.Add("V_ARC_USER_SECTION", OracleType.Int32).Value = objbo.UserSec;
            dCmd.Parameters.Add("V_ARC_DEVELOPER_SECTON", OracleType.Int32).Value = objbo.DevelpSec;
            dCmd.Parameters.Add("V_ARC_APPLICATION_NAME", OracleType.VarChar).Value = objbo.ApplicationName;
            dCmd.Parameters.Add("V_ARC_REQUESTDATE", OracleType.VarChar).Value = objbo.Docname;
            dCmd.Parameters.Add("V_ARC_AUDIT_STATUS", OracleType.VarChar).Value = objbo.AuditStatus;
            dCmd.Parameters.Add("V_ARC_STATUS", OracleType.VarChar).Value = objbo.Status;
            dCmd.Parameters.Add("V_ARC_UPDT_STAT", OracleType.VarChar).Value = objbo.UpdtStatus;
            dCmd.Parameters.Add("V_ARC_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
            dCmd.Parameters.Add("V_ARC_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
            dCmd.Parameters.Add("V_ARC_AASAUDIT_ID", OracleType.Int32).Value = objbo.AuditId;
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
        public Byte SaveUpdateReqDetails(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_REQ_DTL_INSERT_UPDATE", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_ARD_REQ_SLNO", OracleType.Int32).Value = objbo.SLno; 
            dCmd.Parameters.Add("V_ARC_REQ_COLLECTID", OracleType.Int32).Value = objbo.collectId;    
            dCmd.Parameters.Add("V_ARD_MAIN_CODE", OracleType.Int32).Value = objbo.Maincode;
            dCmd.Parameters.Add("V_ARD_SUB_CODE", OracleType.Int32).Value = objbo.subcode;
            dCmd.Parameters.Add("V_ARD_REMARKS", OracleType.VarChar).Value = objbo.Remarks;
            dCmd.Parameters.Add("V_ARC_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
            dCmd.Parameters.Add("V_ARC_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
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
        public DataTable FetchRequirement(Int16 deptid, string audtstatus, Int16 auditid, Int16 roleid, Int32 Sectionid)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleDataAdapter dAd = new OracleDataAdapter("AuditStatus", conn);  //AuditStatus_Post_Audit
            dAd.SelectCommand.CommandType = CommandType.StoredProcedure;
            dAd.SelectCommand.Parameters.Add("v_deptId", OracleType.Int16).Value = deptid;
            dAd.SelectCommand.Parameters.Add("v_auditstatus", OracleType.VarChar).Value = audtstatus;
            dAd.SelectCommand.Parameters.Add("v_auditid", OracleType.Int16).Value = auditid;
            dAd.SelectCommand.Parameters.Add("v_roleid", OracleType.Int16).Value = roleid;
            dAd.SelectCommand.Parameters.Add("v_SectionID", OracleType.Int32).Value = Sectionid;
 
            dAd.SelectCommand.Parameters.Add("v_Cur", OracleType.Cursor).Direction = ParameterDirection.Output;
            DataSet dSet = new DataSet();
            try
            {
                dAd.Fill(dSet, "AuditStatus");
                return dSet.Tables["AuditStatus"];
            }
            catch
            {
                throw;
            }
            finally
            {
                dSet.Dispose();
                dAd.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }
       

        public DataTable FetctReqID( )
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("select AAS_REQID + 1 as AAS_REQID from aas_reqidincrement ", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_reqidincrement");
                return dSet.Tables["aas_reqidincrement"];
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
        public DataTable FetchReq(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("SELECT a.arm_slno  ," +
               "  a.arm_main_code,a.arm_sub_code,a.arm_item_desc,b.ard_remarks FROM aas_reqirement_mast a  " +
              " LEFT OUTER JOIN aas_req_details b ON a.ARM_MAIN_CODE = ARD_MAIN_CODE and a.arm_slno=b.ard_req_slno and b.ard_req_collectid=" + objbo.collectId + "  order by a.arm_slno ,a.arm_main_code,a.arm_sub_code  ", conn);
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
        public DataTable FetchReq_Edit(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("select * from aas_req_collection where arc_req_collectid=" + objbo.collectId, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_collection");
                return dSet.Tables["aas_req_collection"];
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

        public Byte SaveUpdateDocupload(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_REQ_FILES_UPDATION", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_ARF_REQ_SLNO", OracleType.Int32).Value = objbo.uploadSLno;
            dCmd.Parameters.Add("V_ARF_REQ_COLLECTID", OracleType.Int32).Value = objbo.collectId;
            dCmd.Parameters.Add("V_ARF_DOCDESC", OracleType.VarChar).Value = objbo.DocDesc;
            dCmd.Parameters.Add("V_ARF_DOCNAME", OracleType.VarChar).Value = objbo.Docname;
            dCmd.Parameters.Add("V_ARC_FILEPATH", OracleType.VarChar).Value = objbo.filepath;
            dCmd.Parameters.Add("V_ARF_UPDT_STAT", OracleType.VarChar).Value = objbo.UpdtStatus;
            dCmd.Parameters.Add("V_ARF_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
            dCmd.Parameters.Add("V_ARF_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
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
        public Byte SaveRemarks(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("AAS_REQ_FILES_Remarks", conn);
            dCmd.CommandType = CommandType.StoredProcedure;
            dCmd.Parameters.Add("V_ARF_REQ_SLNO", OracleType.Int32).Value = objbo.uploadSLno;
            dCmd.Parameters.Add("V_ARF_REQ_COLLECTID", OracleType.Int32).Value = objbo.collectId;
            dCmd.Parameters.Add("V_ARF_QRY", OracleType.VarChar).Value = objbo.Remarks;
            dCmd.Parameters.Add("V_ARF_QRY_DT", OracleType.VarChar).Value = objbo.ReqDate;
            dCmd.Parameters.Add("V_ARF_UPDT_BY", OracleType.VarChar).Value = objbo.UpdtdBy;
            dCmd.Parameters.Add("V_ARF_UPDT_DT", OracleType.VarChar).Value = objbo.UpdtdDt;
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
        public DataTable FetchUpload(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select * from aas_req_files where ARF_REQ_COLLECTID=" + objbo.collectId + "  order by ARF_FILESRNUMBER  ", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_files");
                return dSet.Tables["aas_req_files"];
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

        public DataTable FetchFileNo(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select case when max(ARF_FILESRNUMBER)+1 is null then 0 else max(ARF_FILESRNUMBER)+1 end as ARF_FILESRNUMBER  from aas_req_files where ARF_REQ_COLLECTID=" + objbo.collectId, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_files");
                return dSet.Tables["aas_req_files"];
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
        public DataTable GetDocumentname(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand(" select  ARF_UPLOADFILE from aas_req_files where ARF_REQ_COLLECTID=" + objbo.collectId + " and ARF_FILESRNUMBER =" + objbo.uploadSLno , conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_files");
                return dSet.Tables["aas_req_files"];
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

        public Byte DeleteDoc(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("delete from aas_req_files where ARF_REQ_COLLECTID=" + objbo.collectId + " and ARF_FILESRNUMBER =" + objbo.uploadSLno, conn);
            dCmd.CommandType = CommandType.Text;
           

            try
            {
                dCmd.ExecuteNonQuery();
                return  1 ;
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
        public Byte DeleteSLno(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("update aas_req_files set ARF_FILESRNUMBER=ARF_FILESRNUMBER - 1 where ARF_FILESRNUMBER >" + objbo.uploadSLno + " and ARF_REQ_COLLECTID=" + objbo.collectId, conn);
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
        public DataTable FetchSerialNo(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("select case when max(ARQ_QUERY_SRNUMBER)+1 is null then 0 else max(ARQ_QUERY_SRNUMBER)+1 end as ARQ_QUERY_SRNUMBER  from aas_req_query where ARQ_REQ_COLLECTID=" + objbo.collectId, conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_query");
                return dSet.Tables["aas_req_query"];
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
        public DataTable FetchRemarks(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("SELECT ARQ_QUERY_SRNUMBER,ARQ_QUERY, to_char(ARQ_QUERY_DT,'dd-mm-yyyy') as ARQ_QUERY_DT from aas_req_query where ARQ_REQ_COLLECTID=" + objbo.collectId + "  order by ARQ_QUERY_SRNUMBER ", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_query");
                return dSet.Tables["aas_req_query"];
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
        public Byte DeleteRemarks(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("delete from aas_req_query where ARQ_REQ_COLLECTID=" + objbo.collectId + " and ARQ_QUERY_SRNUMBER =" + objbo.uploadSLno, conn);
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
        public Byte DeleteSLnoRem(Req_CollectionBO objbo)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("update aas_req_query set ARQ_QUERY_SRNUMBER=ARQ_QUERY_SRNUMBER - 1 where ARQ_QUERY_SRNUMBER >" + objbo.uploadSLno + " and ARQ_REQ_COLLECTID=" + objbo.collectId, conn);
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

        public DataTable DuplicateApplicationName(Int32 collectid, string appname)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("select q.arc_application_name  from aas_req_collection q where q.arc_application_name like '%" + appname + "%' and ARC_STATUS<>'I' ", conn);
            dCmd.CommandType = CommandType.Text;
            OracleDataAdapter dAd = new OracleDataAdapter(dCmd);
            DataSet dSet = new DataSet();

            try
            {
                dAd.Fill(dSet, "aas_req_query");
                return dSet.Tables["aas_req_query"];
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

        public Byte UpdateSLnoDelete(int slno)
        {
            OracleConnection conn = new OracleConnection(connStr);
            conn.Open();
            OracleCommand dCmd = new OracleCommand("update aas_req_files set ARF_FILESRNUMBER=ARF_FILESRNUMBER - 1 where ARF_FILESRNUMBER >" + slno, conn);
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
