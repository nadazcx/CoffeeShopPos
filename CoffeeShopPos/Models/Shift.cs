using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopPos.Models;

namespace CoffeeShopPos.Models
{
    public class Shift
    {
        private int _id;
        private DateTime _startTime;
        private DateTime _endTime;
        private Cashier _cashier;

        public int Id
        {
            get => _id;
            set => _id = value;
        }
        public DateTime StartTime
        {
            get => _startTime;
            set => _startTime = value;
        }
        public DateTime EndTime
        {
            get => _endTime;
            set => _endTime = value;
        }
        public Cashier Cashier
        {
            get => _cashier;
            set => _cashier = value;
        }
    }
}
