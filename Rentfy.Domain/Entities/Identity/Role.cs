﻿using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Rentfy.Domain.Entities.Identity
{
    public class Role : IdentityRole<long>
    {
        public List<UserRole> UserRoles { get; private set; }

        public Role() { }
    }
}
