namespace E_Commerce.Exceptions
{
    public class CartItemAlreadyExistsException : ApplicationException
    {
        public CartItemAlreadyExistsException() { }
        public CartItemAlreadyExistsException(string msg) : base(msg) { }
    }
}
