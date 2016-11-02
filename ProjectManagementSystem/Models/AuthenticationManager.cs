using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess.Entity;
using DataAccess.Service;

namespace ProjectManagementSystem.Models
{
    public class AuthenticationManager
    {
        public static Employee LoggedEmployee
        {
            get
            {
                Authorise authorise = null;

                if (HttpContext.Current != null && HttpContext.Current.Session["LoggedEmployee"] == null)
                {
                    HttpContext.Current.Session["LoggedEmployee"] = new Authorise();
                }

                authorise = (Authorise)HttpContext.Current.Session["LoggedUser"];
                return authorise.LoggedEmployee;
            }
        }

        public static void Authenticate(string email, string password)
        {
            Authorise authorise = null;

            if (HttpContext.Current != null && HttpContext.Current.Session["LoggedEmployee"] == null)
            {
                HttpContext.Current.Session["LoggedEmployee"] = new Authorise();
            }

            authorise = (Authorise)HttpContext.Current.Session["LoggedEmployee"];
            authorise.Authenticate(email, password);
        }
        public static void Logout()
        {
            HttpContext.Current.Session["LoggedEmployee"] = null;
        }
       }
    }
}