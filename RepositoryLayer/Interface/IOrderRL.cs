using CommonLayer.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IOrderRL
    {
        public bool AddToOrder(OrderModle cart);
        public bool DeleteOrder(OrderModle id);
        public bool UpdateOrder(OrderModle cart);
        IEnumerable<OrderModle> Get();
    }
}
