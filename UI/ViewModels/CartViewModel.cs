using DAL.Entities;

namespace UI.ViewModels
{
    public class CartViewModel
    {
        public List<CartItem> CartItems { get; set; } = new();
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; } = 0m;
        public decimal Tax { get; set; } = 0m;
        public decimal Total { get; set; }
    }

}
