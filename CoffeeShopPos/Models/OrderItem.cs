using System;

namespace CoffeeShopPos.Models
{
    public class OrderItem
    {
        private int _id;
        private Product _product;
        private int _orderId;
        private Order _order;
        private int _quantity;
        private decimal _price;

        public int OrderId
        {
            get => _orderId;
            set => _orderId = value;
        }

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public Product Product
        {
            get => _product;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(Product), "Product is required.");
                _product = value;
            }
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

        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Quantity must be greater than zero.");
                _quantity = value;
            }
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Price must be greater than zero.");
                _price = value;
            }
        }
    }
}