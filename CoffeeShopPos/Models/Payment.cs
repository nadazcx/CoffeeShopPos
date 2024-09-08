using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopPos.Models
{
    public class Payment
    {
        private int _id;
        private Order _order;
        private string _paymentMethod;
        private decimal _amountPaid;
        private DateTime _paymentDate;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

      public Order Order
        {
            get => _order;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Order), "Order is required.");
                _order = value;
            }
        }

        public string PaymentMethod
        {
            get => _paymentMethod;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException(nameof(PaymentMethod), "Payment Method is required.");
                _paymentMethod = value;
            }
        }

        public decimal AmountPaid
        {
            get => _amountPaid;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Amount Paid must be greater than zero.");
                _amountPaid = value;
            }
        }

        public DateTime PaymentDate
        {
            get => _paymentDate;
            set => _paymentDate = value;
        }



    }
}
