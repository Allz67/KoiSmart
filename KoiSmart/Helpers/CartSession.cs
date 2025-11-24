using KoiSmart.Models;

namespace KoiSmart.Helpers
{
    public static class CartSession
    {
        private static List<CartItem> _items = new List<CartItem>();

        public static IReadOnlyList<CartItem> Items => _items;

        public static void AddToCart(Ikan ikan, int qty)
        {
            var existing = _items.FirstOrDefault(x => x.Ikan.IdIkan == ikan.IdIkan);

            if (existing != null)
                existing.Quantity += qty;
            else
                _items.Add(new CartItem { Ikan = ikan, Quantity = qty });
        }

        public static void RemoveItem(int ikanId)
        {
            _items.RemoveAll(x => x.Ikan.IdIkan == ikanId);
        }

        public static decimal GetTotal()
        {
            return _items.Sum(x => x.Subtotal);
        }

        public static void Clear()
        {
            _items.Clear();
        }
    }
}