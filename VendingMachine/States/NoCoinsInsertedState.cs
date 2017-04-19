namespace VendingMachine.States
{
    class NoCoinsInsertedState : BaseState
    {
        public NoCoinsInsertedState(VendingMachine vendingMachine)
        {
            VendingMachine = vendingMachine;
        }

        public override string Cancel()
        {
            return "INSERT COIN";
        }

        public override string InsertCoin(double amount)
        {
            VendingMachine.CurrentState = new CoinInsertedState(VendingMachine);
            return VendingMachine.CurrentState.InsertCoin(amount);
        }

        public override string SelectProduct()
        {
            return "INSERT COIN";
        }
    }
}
