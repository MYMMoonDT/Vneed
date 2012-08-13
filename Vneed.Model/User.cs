using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vneed.Model
{
    public class User
    {
        public int UserID { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string Salt { set; get; }
        public string Email { set; get; }
        public int RoleID { set; get; }
        public UserAdditionalInfo AdditionalInfo { set; get; }
    }
}
