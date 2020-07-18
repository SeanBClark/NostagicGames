using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using additionalMethodsDAL.DAL;
using WebApplication1.DAL;
using WebApplication1;

namespace WebApplication1.BL
{
    public class userRegistrationBL
    {
        public void insertUser (string email, string password)
        {
            DAL.setUserMethods.insertUser(email, password);
        }
    }
}