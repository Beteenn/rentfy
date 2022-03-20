﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Contify.Domain.Entities.Identity
{
    public class User : IdentityUser<long>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public List<UserRole> UserRoles { get; private set; }

        public User() { }
    }
}