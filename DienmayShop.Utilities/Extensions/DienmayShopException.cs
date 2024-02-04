namespace DienmayShop.Utilities.Extensions
{
    public class DienmayShopException : Exception
    {
        public DienmayShopException() { }
        public DienmayShopException(string message) : base(message) { }
        public DienmayShopException(string message, Exception inner) : base(message, inner) { }
    }
}
