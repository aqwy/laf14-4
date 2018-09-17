using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf14_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph theGraph = new Graph();
            theGraph.addVertex('A'); // 0 (start)
            theGraph.addVertex('B'); // 1
            theGraph.addVertex('C'); // 2
            theGraph.addVertex('D'); // 3
            theGraph.addVertex('E'); // 4

            theGraph.addEdge(0, 1, 50); // AB 50
            theGraph.addEdge(0, 2, 50); // AC 50
            theGraph.addEdge(1, 0, 50); // BA 50
            theGraph.addEdge(3, 0, 80); // DA 80
            theGraph.addEdge(1, 2, 60); // BC 60
            theGraph.addEdge(1, 3, 90); // BD 90
            theGraph.addEdge(2, 3, 40); // CD 40
            theGraph.addEdge(3, 4, 20); // DE 20
            theGraph.addEdge(4, 0, 70); // EA 70
            theGraph.addEdge(4, 1, 50); // EB 50

            theGraph.travelingSalesman();
            theGraph.displayWord();
            Console.WriteLine("over!");

            Console.ReadLine();
        }
    }
}
