using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Token.Models
{
    public class Role
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedUTCDate { get; set; }
        public string CreatedBy { get; set; }
    }
}