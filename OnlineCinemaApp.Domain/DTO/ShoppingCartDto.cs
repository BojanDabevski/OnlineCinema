using OnlineCinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCinemaApp.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<ProductInShoppingCart> ProductInShoppingCart { get; set; }
        public double TotalPrice { get; set; }
    }
}
