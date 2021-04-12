using System;

namespace BTreeImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var dict = new BTree<string, string>(2);

            for (int i = 0; i < 15; i++)
            {
                dict.Add(i.ToString(), i.ToString());
            }

            dict.Remove("15");
        }
    }
}
