using System.Collections.Generic;

namespace StoreManagement.Models
{
    public class UserAuth
    {
        public UserAuth()
        {
            UserName = "Not authorized";
            BearerToken = string.Empty;
            IsAuthenticated = false;
            Claims = new List<UserClaim>();
        }
        public UserAuth(string userName, string bearerToken, bool isAuthenticated)
        {
            this.UserName = userName;
            this.BearerToken = bearerToken;
            this.IsAuthenticated = isAuthenticated;

        }
        public string UserName { get; set; }
        public string BearerToken { get; set; }
        public bool IsAuthenticated { get; set; }
        public List<UserClaim> Claims { get; set; }
    }
}