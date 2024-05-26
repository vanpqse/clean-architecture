using Microsoft.AspNetCore.Identity;
using System;

namespace ProductFake.Infrastructure.Identity.Models
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole(string name) : base(name)
        {
        }
    }
}