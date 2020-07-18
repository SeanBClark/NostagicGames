using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using additionalMethodsDAL.DAL;

namespace WebApplication1.BL
{
    public class userAccountManagementAdminBL
    {
        public List<DAL.Users> getUsers()
        {
            return DAL.getUserMethods.getUsers();
        }

        public bool loginUser(string email, string password)
        {
            return DAL.getUserMethods.userLogin(email, password);
        }

        public bool loginAdmin(string adminNo, string password)
        {
            return DAL.getUserMethods.adminLogin(adminNo, password);
        }

        public void updateUserStatus(int index, GridView gv, string status)
        {
            DAL.setUserMethods.updateUserStatus(index, gv, status);
        }

        public void insertAdmin(string adminNo, string password, string email)
        {
            DAL.setUserMethods.insertAdmin(adminNo, password, email);
        }
    }
}