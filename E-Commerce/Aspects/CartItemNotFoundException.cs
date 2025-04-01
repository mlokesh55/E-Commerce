namespace E_Commerce.Aspects
{
    public class CartItemNotFoundException : ApplicationException
    {
        public CartItemNotFoundException() { }
        public CartItemNotFoundException(string msg) : base(msg) { }
    }
}
