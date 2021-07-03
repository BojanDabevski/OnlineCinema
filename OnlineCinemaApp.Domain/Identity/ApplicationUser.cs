


using Microsoft.AspNetCore.Identity;
using OnlineCinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCinemaApp.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        //novo(brisi ako zafrkava)
        public string Role { get; set; }

        public virtual ShoppingCart UserCart { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
