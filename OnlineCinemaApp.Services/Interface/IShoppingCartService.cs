using OnlineCinemaApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string usedId, Guid id);
        bool orderNow(string userId);
        
    }
}
