using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Customer(1, "A", "B");
            var b = new Customer(2, "A", "B");

            Console.WriteLine(a.Equals(b));
            Console.WriteLine(b.Equals(a));

            Console.WriteLine(a.CompareByLastName(b));
            Console.WriteLine(a.CompareTo(b));

            var aStruct = new CustomerStruct(1, "A", "B");
            var bStruct = new CustomerStruct(2, "A", "B");

            Console.WriteLine(aStruct.CompareByLastName(bStruct));
            Console.WriteLine(aStruct.CompareTo(bStruct));
            Console.Read();
        }
    }
}
