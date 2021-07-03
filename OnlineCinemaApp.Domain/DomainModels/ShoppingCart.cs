using OnlineCinemaApp.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCinemaApp.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
       
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<ProductInShoppingCart> Products { get; set; }
        public ShoppingCart() { }
    }
}
