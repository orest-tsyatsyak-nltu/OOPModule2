using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Module2OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<Product, Product> products = new SortedList<Product, Product>();
            Product catsFood = new Product("Well fed cat", DateTime.Now.AddMonths(6), "Cats food company");
            products.Add(catsFood, catsFood);
            Product dogsFood = new Product("Well fed dog", DateTime.Now.AddMonths(9), "Dogs food company");
            products.Add(dogsFood, dogsFood);
            Product humanFood = new Product("Best tuna", DateTime.Now.AddDays(14), "Human food company");
            products.Add(humanFood, humanFood);

            byte[] serializedProducts = SerializeToBinary(products);
            SortedList<Product, Product> deserializedProducts = DeserializeFromBinary<SortedList<Product, Product>>(serializedProducts);

            foreach (var p in deserializedProducts)
            {
                Console.WriteLine(p);
            }
            Console.ReadLine();
        }

        public static byte[] SerializeToBinary<T>(T obj)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        public static T DeserializeFromBinary<T>(byte[] binaryData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(binaryData))
            {
                return (T)formatter.Deserialize(stream);
            }
        }
    }
}
