using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laf14_4
{
    class Graph
    {
        private readonly int MAX_VERTS = 20;
        private readonly int INFINITY = 1000000;
        private Vertex[] vertexList;
        private int nVerts;
        private int[,] adjMat;
        private int[] vertexArr;
        private List<int[]> list;
        public Graph()
        {
            adjMat = new int[MAX_VERTS, MAX_VERTS];
            vertexList = new Vertex[MAX_VERTS];
            nVerts = 0;
            for (int i = 0; i < MAX_VERTS; i++)
                for (int j = 0; j < MAX_VERTS; j++)
                    adjMat[i, j] = INFINITY;
        }
        public void addVertex(char lab)
        {
            vertexList[nVerts++] = new Vertex(lab);
        }
        public void addEdge(int start, int end, int weight)
        {
            adjMat[start, end] = weight;
        }
    }
}
