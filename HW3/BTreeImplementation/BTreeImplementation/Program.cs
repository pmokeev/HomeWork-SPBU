using System;

namespace BTreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new BTree(2);

            dict.Insert("1", "1");
            dict.Insert("2", "2");
            dict.Insert("3", "3");

            dict.Delete("3");

            dict.PrintElementsInTree();
        }
    }
}
