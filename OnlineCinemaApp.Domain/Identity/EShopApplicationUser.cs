using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Domain.Identity
{
    class EShopApplicationUser
    {
        public string NormalizedEmail { get; set; }
        public string Email { get; set; }

        public string NormalizedUserName { get; set; }

        public string UserName { get; set; }
    }
}
