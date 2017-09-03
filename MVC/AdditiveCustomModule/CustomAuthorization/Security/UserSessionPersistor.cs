using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.AdditiveCustomModule.CustomAuthorization.Security
{
    public class UserSessionPersistor
    {
        static string CurrentSessionUserKey = "UserSessionKey";
        public static string SessionUser
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var SessionUserVal = HttpContext.Current.Session[CurrentSessionUserKey];
                if (SessionUserVal != null)
                    return SessionUserVal as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session[CurrentSessionUserKey] = value;
            }
        }
    }
}