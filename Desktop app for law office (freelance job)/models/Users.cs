using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.models
{
    public enum Role { Admin,User}

    public class Users
    {
       public  int Id { get; set; }
       public  string  UserName { get; set; }
       public  string  PhoneNumber { get; set; }
       public  string  Passwored { get; set; }
       public  Role Role { get; set; }
       public bool IsDeleted { get; set; } = false;
       public virtual List<Case_User> Case_UserList { get; set; }


    }
}
