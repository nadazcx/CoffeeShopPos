using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopPos.Models
{
    public class Receipt
    {
        private int id;
        private Order order;
        private DateTime _printedAt;

        public int Id
        {
            get => id;
            set => id = value;
        }
        public Order Order
        {
            get => order;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Order), "Order is required.");
                order = value;
            }
        }
        public DateTime PrintedAt
        {
            get => _printedAt;
            set => _printedAt = value;
        }


    }
}
