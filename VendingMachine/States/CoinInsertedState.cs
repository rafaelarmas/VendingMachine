namespace VendingMachine.States
{
    class CoinInsertedState : BaseState
    {
        private double total;

        public CoinInsertedState(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
        }

        public override string Cancel()
        {
            // Return coins to customer.
            VendingMachine.CurrentState = new NoCoinsInsertedState(VendingMachine);
            return "INSERT COIN";
        }

        public override string InsertCoin(double amount)
        {
            total += amount;
            if (VendingMachine.CurrentProduct == null) return "SELECT PRODUCT";
            var balance = VendingMachine.CurrentProduct.GetPrice() - total;
            if (balance <= 0)
            {
                // Dispense product and return any remaining balance to customer.
                VendingMachine.CurrentState = new NoCoinsInsertedState(VendingMachine);
                return "THANK YOU";
            }
            return "PRICE " + balance.ToString("c");
        }

        public override string SelectProduct()
        {
            return "INSERT COIN";
        }
    }
}
