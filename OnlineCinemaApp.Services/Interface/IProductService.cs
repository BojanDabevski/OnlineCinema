using OnlineCinemaApp.Domain.DomainModels;
using OnlineCinemaApp.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdeteExistingProduct(Product p);
        AddToShoppingCardDTO GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid id);
        bool AddToShoppingCart(AddToShoppingCardDTO item, string userID);
    }
}
