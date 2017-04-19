using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Products;

namespace VendingMachine.States
{
    public abstract class BaseState
    {
        public VendingMachine VendingMachine { get; set; }
        public abstract string SelectProduct();
        public abstract string InsertCoin(double amount);
        public abstract string Cancel();
    }
}
