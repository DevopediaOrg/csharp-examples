using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    public class Product
    {
        public readonly uint Id;
        public readonly uint Price;
        public uint Discount;
        public bool IsSold;

        public Product(uint id, uint price)
        {
            Id = id;
            Price = price;
        }

        public override string ToString()
        {
            return $"Id: {Id}; Price: {Price}; Discount: {Discount}; IsSold: {IsSold}";
        }
    }
}
