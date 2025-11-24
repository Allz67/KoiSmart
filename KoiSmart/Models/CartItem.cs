using KoiSmart.Models;

namespace KoiSmart.Models
{
    public class CartItem
    {
        public Ikan Ikan { get; set; }
        public int Quantity { get; set; }

        public decimal Subtotal => Ikan.harga * Quantity;
    }
}