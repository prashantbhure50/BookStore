using BusinessLayer.Interface;
using CommonLayer.Database;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Service
{
    public class OrderBL:IOrderBL
    {
        IOrderRL orderRl;
        public OrderBL(IOrderRL orderRl)
        {
            this.orderRl = orderRl;
        }
        public bool AddToOrder(OrderModle order)
        {
            return this.orderRl.AddToOrder(order);
        }
        public bool DeleteOrder(OrderModle order)
        {
            return this.orderRl.DeleteOrder(order);
        }
        public bool UpdateOrder(OrderModle order)
        {
            return this.orderRl.UpdateOrder(order);
        }
        public IEnumerable<OrderModle> Get()
        {
            return this.orderRl.Get();
        }
    }
}
