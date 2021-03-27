using System;
using System.Collections.Generic;
using System.IO;

namespace Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                FileFunctions.WriteInFile(Algorithm.KruskullsAlgorithm(FileFunctions.CreateGraph(args[0])), args[1]);
            }
            catch (DisconnectedNetworkException error)
            {
                Console.Error.WriteLine(error.Message);
            }
        }
    }
}