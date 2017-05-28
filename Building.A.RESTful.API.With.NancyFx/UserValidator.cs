using System;
using Nancy.Authentication.Basic;
using Nancy.Security;
using System.Collections.Generic;

namespace Building.A.RESTful.API.With.NancyFx
{
    public class UserValidator : IUserValidator
    {
        public IUserIdentity Validate(string username, string password)
        {
            // null == anonymous
            IUserIdentity ret = null;
            foreach (User user in UserRepository.Instance.GetAll())
                if (user.UserName == username && user.Password == password)
                    ret = new UserIdentity(user.UserName, user.Identifier, new List<string> { UserIdentity.HANDLEPERSON_PERMISSION });

            return ret;
        }
    }
}
