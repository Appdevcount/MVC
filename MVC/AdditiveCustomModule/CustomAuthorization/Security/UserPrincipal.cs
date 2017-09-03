using MVC.AdditiveCustomModule.CustomAuthorization.AccessControlDataStore;
using MVC.AdditiveCustomModule.CustomAuthorization.ProfileManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVC.AdditiveCustomModule.CustomAuthorization.Security
{
    //For creating Identity for the logged in User through IPrincipal Interfaces Implementations
    public class UserPrincipal : IPrincipal//from System.Security.Principal
    {
        UserProfile UserProfile;
        public UserPrincipal(UserProfile userprofile)
        {
            this.UserProfile = userprofile;
            this.Identity = new  GenericIdentity(UserProfile.Username);
        }

        public IIdentity Identity //IPrincipal Implementation
        {
            get; set;
        }
        
        public bool IsInRole(string Roles) //IPrincipal Implementation, Roles is the AuthorizeAttribute class string property passed as an argument
        {
            //List<string> AllowedRoleIDs = Roles.Split(new char[] { ',' }).ToList<string>();
            List<string> AllowedRoleIDs = Roles.Split(',').ToList<string>();
            UserProfileManager UserPManager = new UserProfileManager();
            bool IsAllowed = AllowedRoleIDs.Intersect(UserPManager.GetUserRoleIDs(UserSessionPersistor.SessionUser)).Count() > 0 ? true : false;
            //Indicating atleast one of the User roles must match with Allowed Roles
            return IsAllowed;
        }
    }
}