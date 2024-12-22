using System.ComponentModel.Design;

namespace MSTAlgo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(4);
            graph.Add(0, 1, 10);
            graph.Add(0, 2, 6);
            graph.Add(0, 3, 5);
            graph.Add(1, 3, 15);
            graph.Add(2, 3, 4);

            graph.KMSTAlgo();



        }
    }

    class Edge : IComparable<Edge>
    {
        public int Source { get; }
        public int Destination { get; }
        public int Weight { get; }

        public Edge(int source, int destination, int weight)
        {
            Source = source;
            Destination = destination;
            Weight = weight;
        }



        public int CompareTo(Edge? other)
        {
            return Weight.CompareTo(other.Weight);

        }
    }

    class Graph
    {
        private int vertex;
        private List<Edge> edges;


        public Graph(int vertex)
        {
            this.vertex = vertex;
            edges = new List<Edge>();
        }


        public void Add(int s, int d, int w)
        {
            edges.Add(new Edge(s, d, w));
        }


        private int FindParent(int[] parent, int vertex)
        {
            if (parent[vertex] != vertex)
                parent[vertex] = FindParent(parent, parent[vertex]);
            return parent[vertex];

        }

        private void Union(int[] parent, int[] rank, int root1, int root2)
        {
            if (rank[root1] > rank[root2])
            {
                parent[root2] = root1;

            }
            else if (rank[root2] > rank[root1])
            {
                parent[root1] = root2;
            }
            else
            {
                parent[root2] = root1;
                rank[root1]++;
            }
        }


        public void KMSTAlgo()
        {
            edges.Sort();

            int[] parent = new int[vertex];
            int[] rank = new int[vertex];

            for (int i = 0; i < vertex; i++)
            {
                parent[i] = i;
                rank[i] = 0;

            }
            List<Edge> mst = new List<Edge>();
            int mstcost = 0;

            foreach (Edge edge in edges)
            {
                int root1 = FindParent(parent, edge.Source);
                int root2 = FindParent(parent, edge.Destination);
                if (root1 != root2)
                {
                    mst.Add(edge);
                    mstcost += edge.Weight;
                    Union(parent, rank, root1, root2);

                }

            }
            Console.WriteLine("edges of mts");
            foreach (var edge in mst)
            {
                Console.WriteLine($"{edge.Source} , {edge.Destination} , {edge.Weight}");


            }
            Console.WriteLine($"total cost  = {mstcost}");


        }

    }





}
