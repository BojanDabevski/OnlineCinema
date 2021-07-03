using OnlineCinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
       
    }
}
