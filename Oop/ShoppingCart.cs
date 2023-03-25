namespace Oop
{
    [Serializable]
    public class ShoppingCart
    {
        public uint TotalPrice
        {
            get
            {
                uint sum = 0;
                foreach (var pdt in Products) sum += pdt.Price;
                return sum;

                // Or use the simpler System.LINQ syntax
                // return (uint)Products.Sum(p => p.Price);
            }
        }

        public List<Product> Products = new List<Product> { };

        public Product this[int idx]
        {
            get { return Products[idx]; }
        }

        public Product GetProduct(int idx)
        {
            return Products[idx];
        }

        public override string ToString()
        {
            return $"TotalPrice: {TotalPrice}; # Products: {Products.Count}";
        }
    }
}
