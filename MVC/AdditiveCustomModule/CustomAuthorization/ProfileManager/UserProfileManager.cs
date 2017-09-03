using MVC.AdditiveCustomModule.CustomAuthorization.AccessControlDataStore;
using MVC.AdditiveCustomModule.CustomAuthorization.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.AdditiveCustomModule.CustomAuthorization.ProfileManager
{
    public class UserProfileManager
    {
        CustomAuthEntityContext dbctx;
        public UserProfileManager() //Intializing few members[dbcontext] of class here so that it can be used anywhere again in memebers of class like inside methods
        {
            this.dbctx = new CustomAuthEntityContext();
        }

        //Have created partial classes for the Entity DynamicProxy/POCO generated class for data handling but not used here

        //Login Method for Authenticating
        public UserProfile AuthenticateUser(string EnteredUsername, string EnteredPassword)
        {
            UserProfile UserProfile = dbctx.UserProfiles
                .Where(s => s.Username.Equals(EnteredUsername) &
                s.Password.Equals(EnteredPassword) & s.UserActive.Equals(true) & s.LockedOut.Equals(false)).FirstOrDefault();
            return UserProfile;
        }

        //Finding and getting the UserProile details for Creating Pricipal for the user
        public UserProfile FindUser(string EnteredUsername)
        {
            UserProfile UserProfile = dbctx.UserProfiles.Where(s => s.Username.Equals(EnteredUsername)).FirstOrDefault();
            return UserProfile;
        }

        //Getting list of Roles in which User is existing
        public List<string> GetUserRoleIDs(string EnteredUsername)
        {
            List<string> RoleIDsList = dbctx.UserProfiles.Where(s => s.Username.Equals(EnteredUsername)).Select(s => s.RoleID.ToString()).ToList<string>();

            return RoleIDsList;
        }


    }
}
