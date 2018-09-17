using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

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
        public void displayWord()
        {
            int minIndex = 0;
            int minWeight = INFINITY;
            for (int i = 0; i < list.Count(); i++)
            {
                int weight = 0;
                int[] temp = list[i];
                for (int j = 0; j < temp.Length - 1; j++)
                {
                    weight += adjMat[temp[j], temp[j + 1]];
                }
                weight += adjMat[temp[temp.Length - 1], temp[0]];
                if (weight < minWeight)
                {
                    minWeight = weight;
                    minIndex = i;
                }
            }
            int[] min = list[minIndex];
            for (int j = 0; j < nVerts; j++)
            {
                Console.Write(" " + vertexList[min[j]].lable);
            }
            Console.Write(" " + vertexList[min[0]].lable);
            Console.WriteLine("(" + minWeight + ")");
        }
        public void travelingSalesman()
        {
            vertexArr = new int[nVerts];
            list = new List<int[]>();
            for (int i = 0; i < nVerts; i++)
            {
                vertexArr[i] = i;
            }
            doAnagram(vertexArr.Length);
        }
        public void doAnagram(int newSize)
        {
            if (newSize == 1)
            {
                for (int i = 0; i < nVerts - 1; i++)
                {
                    if (adjMat[vertexArr[i], vertexArr[i + 1]] == INFINITY)
                    {
                        return;
                    }
                }
                if (adjMat[vertexArr[nVerts - 1], vertexArr[0]] != INFINITY)
                {
                    int[] temp = new int[nVerts];
                    Array.Copy(vertexArr, 0, temp, 0, nVerts);
                    list.Add(temp);
                }
                return;
            }
            for (int j = 0; j < newSize; j++)
            {
                doAnagram(newSize - 1);
                rotate(newSize);
            }
        }
        public void rotate(int newSize)
        // rotate left all chars from position to end
        {
            int j;
            int position = nVerts - newSize;
            int temp = vertexArr[position];       // save first letter
            for (j = position + 1; j < nVerts; j++)
                // shift others left
                vertexArr[j - 1] = vertexArr[j];
            vertexArr[j - 1] = temp;                 // put first on right
        }
    }
}
