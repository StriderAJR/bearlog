using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace Bearlog.Web.Models
{
    public class BearlogPrincipal : RolePrincipal, IPrincipal
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; set; }

        private string[] _roles;

        public BearlogPrincipal(IIdentity identity, BearlogPrincipalSerializeModel model) : base(identity)
        {
            _roles = model.Roles;
            Id = model.Id;
            FullName = model.Name;
            Email = model.Email;
            if (_roles != null) Array.Sort(_roles);
        }

        public bool IsInAnyRoles(params string[] roles)
        {
            return roles.Any(searchrole => Array.BinarySearch<string>(_roles, searchrole) > 0);
        }
    }

    public class BearlogPrincipalSerializeModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string[] Roles { get; set; }
    }
}