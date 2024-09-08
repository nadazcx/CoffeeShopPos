using System;
using CoffeShopPos.Models;

namespace CoffeeShopPos.Models
{
    public  class Product
    {
        private int _id;
        private string _name;
        private decimal _price;
        private Category _category;
        private int _categoryId;

        public int CategoryId
        {
            get => _categoryId;
            set => _categoryId = value;
        }


        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public decimal Price
        {
            get => _price;
            set => _price = value;
        }

        public Category Category
        {
            get => _category;
            set => _category = value;
        }
    }
}