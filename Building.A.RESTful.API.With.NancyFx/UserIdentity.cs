using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class UserIdentity : IUserIdentity
    {
        internal const string HANDLEPERSON_PERMISSION = "HandlePerson";
        public string UserName { get; private set; }
        public Guid UserIdentifier { get; private set; }
        public IEnumerable<string> Claims { get; private set; }

        public UserIdentity(string userName, Guid userIdentifier, IEnumerable<string> claims)
        {
            UserName = userName;
            UserIdentifier = userIdentifier;
            Claims = claims;
        }

        public bool HasClaim(string claim)
        {
            return Claims.Contains(claim);
        }
    }
}
