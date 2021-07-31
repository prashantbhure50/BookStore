using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IOrderBL
    {
        public bool AddToOrder(OrderModle order);
        public bool DeleteOrder(OrderModle order);
        public bool UpdateOrder(OrderModle order);
        IEnumerable<OrderModle> Get(int id);
    }
}
