using OnlineCinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Domain.DomainModels
{
    class ShowOrder
    {
        public string UserId { get; set; }
        public EShopApplicationUser User { get; set; }

        public  ICollection<ProductInOrder> Products { get; set; }
    }
}
