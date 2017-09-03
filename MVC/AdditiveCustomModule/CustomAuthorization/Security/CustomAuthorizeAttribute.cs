using MVC.AdditiveCustomModule.CustomAuthorization.AccessControlDataStore;
using MVC.AdditiveCustomModule.CustomAuthorization.ProfileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.AdditiveCustomModule.CustomAuthorization.Security
{
    //Custom Auth Implementation using AuthorizeAttribute
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(UserSessionPersistor.SessionUser))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        Controller = "CustomAuthorizeSession",
                        Action = "Login" //"AuthorizedCommonPage"
                    }));
            }
            else
            {
                UserProfileManager UserPManager = new UserProfileManager();
                UserProfile UProfile = UserPManager.FindUser(UserSessionPersistor.SessionUser);

                UserPrincipal UPrincipal = new UserPrincipal(UProfile);
                //UPrincipal.Identity.Name  //Gets the name of Current user
                if (!UPrincipal.IsInRole(Roles))// Roles is the AuthorizeAttribute class string property
                {
                    filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new
                    {
                        Controller = "CustomAuthnzSession",
                        Action = "NotAuthorized"//Not Authorized for this page
                    }));
                }
            }

            base.OnAuthorization(filterContext);
        }
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    base.HandleUnauthorizedRequest(filterContext);
        //}
    }
}