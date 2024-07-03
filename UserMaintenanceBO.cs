using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BO
{
   public class UserMaintenanceBO
    {
        string m_StaffNo = string.Empty;
        string m_StaffName = string.Empty;
        string m_Dept = string.Empty;
        string m_Designation = string.Empty;
        string m_Role = string.Empty;
        string m_Pwd = string.Empty;
        string m_Pwd_hashed = string.Empty;
        string m_SecId = string.Empty;
        string m_WingId = string.Empty;
        string m_OldPwd = string.Empty;
        string m_NewPwd = string.Empty;
        string m_ConfirmPwd = string.Empty;
        string m_ValidFrom = string.Empty;
        string m_ValidTo = string.Empty;
        string m_Phone = string.Empty;
        string m_Mobile = string.Empty;
        string m_Email = string.Empty;
        string m_Status = string.Empty;
        string m_UpdtStatus = string.Empty;
        string m_Action = string.Empty;
        string m_UpdtBy = string.Empty;
        string m_UpdtDt = string.Empty;
        string m_AuditStat = string.Empty;
        string m_Section = string.Empty;
        Int32 _auditid = 0;
        string M_AUDIT_type = string.Empty;
        string m_salt = string.Empty;
        string m_salt_state = string.Empty;
        string m_user_lock = string.Empty;
        //public string M_AUDIT_type1
        //{
        //    get { return M_AUDIT_type1; }
        //    set { M_AUDIT_type1 = value; }
        //}
        public string Pwd_hashed
        {
            get { return m_Pwd_hashed; }
            set { m_Pwd_hashed = value; }
        }
        public string user_lock
        {
            get { return m_user_lock; }
            set { m_user_lock = value; }
        }
        public string salt
        {
            get { return m_salt; }
            set { m_salt = value; }
        }

       public string salt_state
        {
            get { return m_salt_state; }
            set { m_salt_state = value; }
        }
        public Int32 auditid
        {
            get { return _auditid; }
            set { _auditid = value; }
        }

        public string StaffNo
        {
            get { return m_StaffNo; }
            set { m_StaffNo = value; }
        }

        public string StaffName
        {
            get { return m_StaffName; }
            set { m_StaffName = value; }
        }


        public string Dept
        {
            get { return m_Dept; }
            set { m_Dept = value; }
        }


        public string WingId
        {
            get { return m_WingId; }
            set { m_WingId = value; }
        }
        public string SecId
        {
            get { return m_SecId; }
            set { m_SecId = value; }
        }

        public string Designation
        {
            get { return m_Designation; }
            set { m_Designation = value; }
        }

        public string Role
        {
            get { return m_Role; }
            set { m_Role = value; }
        }

        public string Pwd
        {
            get { return m_Pwd; }
            set { m_Pwd = value; }
        }

        public string OldPwd
        {
            get { return m_OldPwd; }
            set { m_OldPwd = value; }
        }

        public string NewPwd
        {
            get { return m_NewPwd; }
            set { m_NewPwd = value; }
        }

        public string ConfirmPwd
        {
            get { return m_ConfirmPwd; }
            set { m_ConfirmPwd = value; }
        }

        public string ValidFrom
        {
            get { return m_ValidFrom; }
            set { m_ValidFrom = value; }
        }

        public string ValidTo
        {
            get { return m_ValidTo; }
            set { m_ValidTo = value; }
        }

        public string Phone
        {
            get { return m_Phone; }
            set { m_Phone = value; }
        }

        public string Mobile
        {
            get { return m_Mobile; }
            set { m_Mobile = value; }
        }

        public string Email
        {
            get { return m_Email; }
            set { m_Email = value; }
        }

        public string Status
        {
            get { return m_Status; }
            set { m_Status = value; }
        }

        public string Updtstatus
        {
            get { return m_UpdtStatus; }
            set { m_UpdtStatus = value; }
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

        public string Audit_Stat
        {
            get { return m_AuditStat; }
            set { m_AuditStat = value; }
        }

        public string Section
        {
            get { return m_Section; }
            set { m_Section = value; }
        }
       

    }
}
