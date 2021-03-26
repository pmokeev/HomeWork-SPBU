using System;
using System.Collections.Generic;

namespace Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            var gr = Algorithm.KruskullsAlgorithm(FileFunctions.CreateGraph("../../../Graph.txt"));

            FileFunctions.WriteInFile(gr, "../../../Graph.txt");
        }
    }
}