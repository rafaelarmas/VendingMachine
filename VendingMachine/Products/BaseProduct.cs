namespace VendingMachine.Products
{
    public abstract class BaseProduct
    {
        protected double Price;

        public virtual double GetPrice()
        {
            return Price;
        }
    }
}
