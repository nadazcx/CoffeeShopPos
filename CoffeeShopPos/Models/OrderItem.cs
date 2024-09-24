using System;
using System.ComponentModel;

namespace CoffeeShopPos.Models
{

    public class OrderItem : INotifyPropertyChanged
    {
        private int _id;
        private Product _product;
        private int _orderId;
        private Order _order;
        private int _quantity;
        private decimal _price;

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
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                    OnPropertyChanged(nameof(TotalPrice)); 
                }
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

        public decimal TotalPrice => Product.Price * Quantity;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}