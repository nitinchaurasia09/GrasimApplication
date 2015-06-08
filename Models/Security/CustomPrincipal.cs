using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace GrasimApplication.Models.Security
{
    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            if (rolesPrivelege.Any(r => r.Key == role))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool HasPermission(int permission)
        {
            if (rolesPrivelege.Any(r => r.Value.Contains(permission)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public CustomPrincipal(string Username)
        {
            this.Identity = new GenericIdentity(Username);
        }

        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string, List<int>> rolesPrivelege { get; set; }
        
    }

    public class CustomPrincipalSerializeModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Dictionary<string,List<int>> rolesPrivelege { get; set; }
        
    }
}