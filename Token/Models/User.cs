using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Token.Models
{
    public class User
    {
        public string username { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string AccessCode { get; set; }
        public string ActionIp { get; set; }
        public string BrowserInfo { get; set; }
        public string SessionId { get; set; }
        public long Id { get; set; }
        public string RoleId { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public Role Role { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public List<Error> errors { get; set; }

    }
    public class Error
    {
        public string error_code { get; set; }
        public string error_message { get; set; }
    }
}