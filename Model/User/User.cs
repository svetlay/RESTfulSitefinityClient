using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SFWinformsClient.Model.User
{

           [DataContract]
    public class RolesOfUser
    {
                [DataMember]
        public string ProviderName { get; set; }
                [DataMember]
        public string RoleId { get; set; }
                [DataMember]
        public string RoleName { get; set; }
    }

           [DataContract]
    public class User
    {
                [DataMember]
        public bool AvatarImageSmallerWidth { get; set; }
                [DataMember]
        public string AvatarImageUrl { get; set; }
                [DataMember]
        public string AvatarThumbnailUrl { get; set; }
                [DataMember]
        public string Comment { get; set; }
                [DataMember]
        public DateTime CreationDate { get; set; }
                [DataMember]
        public string DisplayName { get; set; }
                [DataMember]
        public string Email { get; set; }
                [DataMember]
        public bool IsApproved { get; set; }
                [DataMember]
        public bool IsBackendUser { get; set; }
                [DataMember]
        public bool IsLockedOut { get; set; }
                [DataMember]
        public bool IsLoggedIn { get; set; }
                [DataMember]
        public object LastActivityDate { get; set; }
                [DataMember]
        public object LastLockoutDate { get; set; }
                [DataMember]
        public object LastLoginDate { get; set; }
                [DataMember]
        public DateTime LastPasswordChangedDate { get; set; }
                [DataMember]
        public object Password { get; set; }
                [DataMember]
        public object PasswordAnswer { get; set; }
                [DataMember]
        public string PasswordQuestion { get; set; }
                [DataMember]
        public object ProfileData { get; set; }
                [DataMember]
        public string ProviderName { get; set; }
                [DataMember]
        public string ProviderUserKey { get; set; }
                [DataMember]
        public string RoleNamesOfUser { get; set; }
                [DataMember]
        public List<RolesOfUser> RolesOfUser { get; set; }
                [DataMember]
        public string UserID { get; set; }
                [DataMember]
        public string UserName { get; set; }
                
    }
}
