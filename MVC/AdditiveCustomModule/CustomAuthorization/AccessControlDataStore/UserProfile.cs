//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC.AdditiveCustomModule.CustomAuthorization.AccessControlDataStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserProfile
    {
        public long UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public Nullable<int> RetryAttempt { get; set; }
        public Nullable<bool> LockedOut { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> UserActive { get; set; }
        public Nullable<long> RoleID { get; set; }
    
        public virtual Role Role { get; set; }
    }
}
