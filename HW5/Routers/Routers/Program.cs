using System;
using System.Collections.Generic;

namespace Routers
{
    class Program
    {
        static void Main(string[] args)
        {
            var gr = Algorithm.KruskullsAlgorithm(ReadGraph.CreateGraph("../../../Graph.txt"));

            ReadGraph.WriteInFile(gr, "../../../Graph.txt");
        }
    }
}