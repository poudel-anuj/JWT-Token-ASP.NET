using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Token.Models
{
    public class Admin
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string FullName { get; set; }
        public string RoleName { get; set; }
        public string EmailAddress { get; set; }
        public byte[] Password { get; set; }
        public Role Role { get; set; }
    }
}