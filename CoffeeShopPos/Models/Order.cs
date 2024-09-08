using CoffeeShopPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopPos.Models
{
    public class Order
    {
        private int _id;
        private DateTime _orderDate;
        private Cashier _cashier;
        private List<OrderItem> _orderItems;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public DateTime OrderDate
        {
            get => _orderDate;
            set => _orderDate = value;
        }

        public Cashier Cashier
        {
            get => _cashier;
            set => _cashier = value;
        }

        public List<OrderItem> OrderItems
        {
            get => _orderItems;
            set => _orderItems = value;
        }

    }
}
