using VendingMachine.Products;
using VendingMachine.States;

namespace VendingMachine
{
    public class VendingMachine
    {
        public BaseState CurrentState { get; set; }
        public BaseProduct CurrentProduct { get; private set; }

        public VendingMachine()
        {
            CurrentState = new NoCoinsInsertedState(this); 
        }

        public string SelectProduct(BaseProduct product)
        {
            CurrentProduct = product;
            return CurrentState.SelectProduct();
        }

        public string InsertCoin(double amount)
        {
            return CurrentState.InsertCoin(amount);
        }

        public string Cancel()
        {
            CurrentProduct = null;
            return CurrentState.Cancel();
        }
    }
}
