using OnlineCinemaApp.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineCinemaApp.Services.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
        Order GetOrderDetails(BaseEntity model);
    }
}
